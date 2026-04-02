using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ff14bot;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using Kupo.Helpers;
using TreeSharp;
using Action = TreeSharp.Action;

namespace Kupo.Rotations
{
    public class BlueMage : KupoRoutine
    {
        public override string Name => "Kupo [" + GetType().Name + "]";
        public override float PullRange => 25f;
        public override ClassJobType[] Class => new[] { ClassJobType.BlueMage };

        private static BattleCharacter Target => Core.Player.CurrentTarget as BattleCharacter;

        private static int EnemyCount =>
            GameObjectManager.GetObjectsOfType<BattleCharacter>()
                .Count(u => !u.IsDead && u.CanAttack && u.InCombat && u.Distance2D(Core.Me) <= 8f);

        private static bool IsAoE => EnemyCount >= 3;

        private static bool IsReady(string spellName)
        {
            if (!ActionManager.HasSpell(spellName)) return false;
            var data = DataManager.GetSpellData(spellName);
            return data != null && data.Cooldown.TotalMilliseconds < 100;
        }

        private static bool HasBuff(string aura) => Core.Me.HasAura(aura);
        private static bool TargetHasDebuff(string aura) => Target?.HasAura(aura) ?? false;

        private bool ShouldInterrupt =>
            Target != null &&
            Target.SpellCastInfo.IsCasting &&
            Target.SpellCastInfo.Interruptible &&
            Target.SpellCastInfo.CurrentCastTime.TotalMilliseconds >= 500;

        [Behavior(BehaviorType.PreCombatBuffs)]
        public Composite CreatePreCombatBuffs()
        {
            return new PrioritySelector(
                Spell.Cast("Aetherial Mimicry",
                    r => ActionManager.HasSpell("Aetherial Mimicry") && !HasBuff("Aetheric Mimicry: DPS")),
                Spell.Cast("Toad Oil",
                    r => ActionManager.HasSpell("Toad Oil") && !HasBuff("Toad Oil"))
            );
        }

        [Behavior(BehaviorType.CombatBuffs)]
        public Composite CreateCombatBuffs()
        {
            return new PrioritySelector(SummonChocobo());
        }

        [Behavior(BehaviorType.Rest)]
        public Composite CreateRest()
        {
            return DefaultRestBehavior(r => Core.Player.CurrentManaPercent);
        }

        [Behavior(BehaviorType.Pull)]
        public Composite CreatePull()
        {
            return new PrioritySelector(ctx => Core.Player.CurrentTarget as BattleCharacter,
                new Decorator(ctx => ctx != null, new PrioritySelector(
                    new Decorator(ctx => !RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement),
                        new PrioritySelector(
                            CommonBehaviors.MoveToLos(ctx => ctx as GameObject),
                            CommonBehaviors.MoveAndStop(
                                ctx => (ctx as GameObject).Location,
                                ctx => Core.Player.CombatReach + PullRange + (ctx as GameObject).CombatReach,
                                true, "Moving to unit")
                        )),
                    Spell.PullCast(r => "Sticky Tongue",
                        r => ActionManager.HasSpell("Sticky Tongue")
                          && ActionManager.LastSpell.Name != "Sticky Tongue"
                          && Core.Target.Distance2D(Core.Me) >= 5f),
                    Spell.PullCast(r => "Water Cannon",
                        r => !ActionManager.HasSpell("Sticky Tongue"))
                )));
        }

        [Behavior(BehaviorType.Heal)]
        public Composite CreateHeal()
        {
            return new PrioritySelector(
                Spell.Cast("White Wind",
                    r => ActionManager.HasSpell("White Wind") && Core.Me.CurrentHealthPercent <= 50),
                Spell.Cast("Exuviation",
                    r => ActionManager.HasSpell("Exuviation")
                      && (HasBuff("Paralysis") || HasBuff("Poison") || HasBuff("Blind"))),
                Spell.Cast("Gobskin",
                    r => ActionManager.HasSpell("Gobskin") && IsReady("Gobskin")
                      && Core.Me.CurrentHealthPercent <= 75)
            );
        }

        [Behavior(BehaviorType.Combat)]
        public Composite CreateCombat()
        {
            return new PrioritySelector(ctx => Core.Player.CurrentTarget as BattleCharacter,
                new Decorator(ctx => ctx != null,
                    new PrioritySelector(

                        new Decorator(ctx => !RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement),
                            new PrioritySelector(
                                CommonBehaviors.MoveToLos(ctx => ctx as GameObject),
                                CommonBehaviors.MoveAndStop(
                                    ctx => (ctx as GameObject).Location,
                                    ctx => Core.Player.CombatReach + 4f,
                                    true, "Moving to unit")
                            )),

                        Spell.Cast("Flying Sardine", r => ShouldInterrupt),

                        Spell.Cast("Lucid Dreaming",
                            r => ActionManager.HasSpell("Lucid Dreaming") && Core.Player.CurrentManaPercent < 70),
                        Spell.Cast("Blood Drain",
                            r => ActionManager.HasSpell("Blood Drain") && IsReady("Blood Drain")
                              && Core.Player.CurrentManaPercent < 25),

                        Spell.Cast("Toad Oil",
                            r => ActionManager.HasSpell("Toad Oil") && !HasBuff("Toad Oil")),

                        new Decorator(r => IsAoE,
                            new PrioritySelector(
                                Spell.Cast("Whistle",
                                    r => ActionManager.HasSpell("Whistle") && IsReady("Whistle")
                                      && !HasBuff("Boost") && !HasBuff("Harmonized")),
                                Spell.Cast("Surpanakha",
                                    r => ActionManager.HasSpell("Surpanakha") && IsReady("Surpanakha")
                                      && Core.Me.IsFacing(Core.Target) && Core.Target.Distance2D(Core.Me) <= 10f),
                                Spell.Cast("Tingle",
                                    r => ActionManager.HasSpell("Tingle") && IsReady("Tingle")
                                      && !HasBuff("Tingling") && Core.Target.Distance2D(Core.Me) <= 6f),
                                Spell.Cast("Whistle",
                                    r => ActionManager.HasSpell("Whistle") && HasBuff("Tingling") && !HasBuff("Boost")),
                                Spell.Cast("Triple Trident",
                                    r => HasBuff("Tingling") && HasBuff("Harmonized") && Core.Target.Distance2D(Core.Me) <= 6f),
                                Spell.Cast("Ram's Voice",
                                    r => ActionManager.HasSpell("Ram's Voice") && IsReady("Ram's Voice")
                                      && Core.Target.Distance2D(Core.Me) <= 8f && !TargetHasDebuff("Deep Freeze")),
                                Spell.Cast("Ultravibration",
                                    r => ActionManager.HasSpell("Ultravibration") && IsReady("Ultravibration")
                                      && TargetHasDebuff("Deep Freeze")),
                                Spell.Cast("Bad Breath",
                                    r => ActionManager.HasSpell("Bad Breath")
                                      && ActionManager.LastSpell.Name != "Bad Breath"
                                      && Core.Me.IsFacing(Core.Target) && Core.Target.Distance2D(Core.Me) <= 8f
                                      && !TargetHasDebuff("Poison")),
                                Spell.Cast("Plaincracker",
                                    r => ActionManager.HasSpell("Plaincracker") && Core.Target.Distance2D(Core.Me) <= 4f),
                                Spell.Cast("1000 Needles",
                                    r => ActionManager.HasSpell("1000 Needles") && IsReady("1000 Needles")
                                      && ActionManager.LastSpell.Name != "1000 Needles"
                                      && Target.CurrentHealthPercent > 20),
                                Spell.Cast("Water Cannon", r => true)
                            )),

                        Spell.Cast("Off-guard",
                            r => ActionManager.HasSpell("Off-guard") && IsReady("Off-guard")
                              && !TargetHasDebuff("Off-guard") && Target.CurrentHealthPercent > 5),

                        Spell.Cast("Bad Breath",
                            r => ActionManager.HasSpell("Bad Breath")
                              && ActionManager.LastSpell.Name != "Bad Breath"
                              && Core.Me.IsFacing(Core.Target) && Core.Target.Distance2D(Core.Me) <= 8f
                              && !TargetHasDebuff("Poison") && Target.CurrentHealthPercent > 10),

                        Spell.Cast("Tingle",
                            r => ActionManager.HasSpell("Tingle") && IsReady("Tingle")
                              && !HasBuff("Tingling") && Core.Target.Distance2D(Core.Me) <= 6f
                              && Target.CurrentHealthPercent > 15),

                        Spell.Cast("Whistle",
                            r => ActionManager.HasSpell("Whistle") && HasBuff("Tingling")
                              && !HasBuff("Boost") && IsReady("Whistle")),

                        Spell.Cast("Triple Trident",
                            r => HasBuff("Tingling") && HasBuff("Harmonized") && Core.Target.Distance2D(Core.Me) <= 6f),

                        Spell.Cast("Surpanakha",
                            r => ActionManager.HasSpell("Surpanakha") && IsReady("Surpanakha")
                              && Core.Me.IsFacing(Core.Target) && Core.Target.Distance2D(Core.Me) <= 10f),

                        Spell.Cast("Abyssal Transfixion",
                            r => ActionManager.HasSpell("Abyssal Transfixion") && IsReady("Abyssal Transfixion")
                              && !TargetHasDebuff("Deep Freeze")),

                        Spell.Cast("1000 Needles",
                            r => ActionManager.HasSpell("1000 Needles") && IsReady("1000 Needles")
                              && ActionManager.LastSpell.Name != "1000 Needles"
                              && Target.CurrentHealthPercent > 20),

                        Spell.Cast("Water Cannon", r => true)
                    )));
        }
    }
}
