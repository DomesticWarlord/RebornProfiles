# Panda Farmer WPF Main Scenario Quest Profiles

> [!WARNING]
> **Under Construction**
>
> These profiles have not been completely tested and may contain errors, incomplete automation, or other issues. Monitor them while they run and be prepared to complete steps manually or stop the bot if unexpected behavior occurs.


These OrderBot profiles automate the Final Fantasy XIV Main Scenario Quest line from A Realm Reborn through Dawntrail.

## Requirements

- RebornBuddy with OrderBot
- PandaFarmerWPF installed in the RebornBuddy **Plugins** folder
- Other plugins named by a profile, such as Duty Mechanic, SideStep, or Platypus Hooks, when the related feature is enabled

PandaFarmerWPF **must be installed** because these profiles use OrderBot tags and supporting code supplied by the plugin. An active Panda Farmer subscription is **not required** to load and run these XML profiles manually.

## Installing PandaFarmerWPF

1. Close RebornBuddy.
2. [Download PandaFarmerWPF](https://sts.llamamagic.net/PandaFarmerWPF/PandaFarmerWPF.zip).
3. Open the downloaded ZIP file.
4. Extract the **PandaFarmerWPF** folder into RebornBuddy's **Plugins** folder.
5. Confirm the resulting layout resembles:

       RebornBuddy/
       └── Plugins/
           └── PandaFarmerWPF/
               ├── PandaFarmerWPF.dll
               └── ...

6. Start RebornBuddy.
7. Open the Plugins window and confirm PandaFarmerWPF is present. Enable it when using plugin-level features such as automatic companion skill assignment.

Avoid creating an extra nested folder such as **Plugins/PandaFarmerWPF/PandaFarmerWPF/**. RebornBuddy must find the plugin files directly inside the first **PandaFarmerWPF** folder.

## Using the Profiles

Each expansion is stored in its own numbered folder. Load the XML for the expansion you want through OrderBot. The profile checks quest completion and resumes at the first applicable quest, so it does not need to begin at the expansion's first quest.

Before loading a profile, open the XML in a text editor and review the entities near the top. Boolean options accept **True** or **False**. Keep entity values inside quotation marks.

## User Settings

These entities are intended to be configured by the user.

| Entity | Values | Description |
| --- | --- | --- |
| **SkipCutscenes** | True / False | Enables OrderBot's cutscene-skipping setting. Some cutscenes cannot be skipped by the game. |
| **AutoEquip** | True / False | Enables automatic equipment handling so useful quest rewards and opened coffer gear can be equipped. Can only equip from Armoury Chest |
| **CloseHowTos** | True / False | Automatically closes tutorial, guide, job HUD notice, achievement, and similar informational windows that can clog the UI. |
| **EnablePlatypus** | True / False | Enables Platypus Hooks when the profile starts. Leave this False if Platypus Hooks is not installed or needed. Highly recommended as Platypus is responsible for self repairing as well as releasing upon death. |
| **KillHuntMobs** | True / False | Allows nearby valid Hunting Log targets to be selected and killed while questing. |
| **BuyGysahlGreens** | True / False | Allows the profile to purchase Gysahl Greens when needed so the companion chocobo can remain available. |
| **AssignCompanionSkillPoints** | True / False | Spends available companion skill points when the profile contains the companion skill assignment step. PandaFarmerWPF must be enabled for plugin-level automatic assignment. |
| **CompanionRole** | Defender, Healer, or Attacker | Selects the companion skill tree used by AssignCompanionSkillPoints. |
| **DiscardInventoryClutter** | True / False | Discards specifically listed low-value quest items. It does not indiscriminately clear the inventory. |
| **GrandCompanyChoice** | 0, 1, or 2 | This is only present in A Realm Reborn and allows and you to choose which Grand Company to join during the MSQ. 0 = Order of the Twin Adder, 1 = Maelstrom, and 2 = Immortal Flames. |
Not every entity is used by every expansion. Shared headers keep settings consistent across the profile set.

## Panda Farmer Settings

These settings control Panda Farmer-specific features. **DoClassQuests, UseCarry, OnlyNonDutySupport, and CarryName only apply when using Panda Farmer with an active subscription.** They do not change the behavior of the free, manually loaded quest profile by themselves.

| Entity | Values | Description |
| --- | --- | --- |
| **DoClassQuests** | True / False | With an active Panda Farmer subscription, runs the current class or job quest helper at supported points in the MSQ. |
| **UseCarry** | True / False | With an active Panda Farmer subscription, enables Panda Farmer Auto Party carry handling for supported duties. The carry character must be configured and ready. |
| **OnlyNonDutySupport** | True / False | With an active Panda Farmer subscription and carry mode enabled, limits Auto Party use to duties that cannot be completed with Duty Support. |
| **CarryName** | Character's first name | With an active Panda Farmer subscription and carry mode enabled, identifies the carry character. Enter only the first name, for example Arelia. |

## Internal Entities

These aliases represent quest IDs, map IDs, NPC IDs, or destination IDs. They make conditions easier to read and support patch-content maintenance.

Do **not** change these values unless maintaining the profile against a verified game-data change.

| Entity | ID | Purpose |
| --- | ---: | --- |
| **TheBackroom** | 1207 | Map ID used for Dawntrail travel logic. |
| **EarthenSkyHideout** | 1171 | Map ID used for Dawntrail travel logic. |
| **AlexandriaCrater** | 1334 | Map ID used for Dawntrail travel logic. |
| **Treno** | 1328 | Map ID used for Dawntrail travel logic. |
| **ContainmentComplex10_29** | 1299 | Map ID used for late Dawntrail quest travel. |
| **SeekersofEternity** | 70842 | Quest ID alias for the patch MSQ endpoint. |
| **PromiseofTomorrow** | 70909 | Quest ID alias for the patch MSQ endpoint. |
| **WiththeWinds** | 70962 | Quest ID alias used by the post-Dawntrail quest chain. |
| **ThroughtheThunder** | 70963 | Quest ID alias used by the post-Dawntrail quest chain. |
| **BeyondtheMountains** | 70964 | Quest ID alias used by the post-Dawntrail quest chain. |
| **AroundtheCity** | 70965 | Quest ID alias used by the post-Dawntrail quest chain. |
| **ToWork** | 70966 | Quest ID alias used by the post-Dawntrail quest chain. |
| **InHerHeart** | 70967 | Quest ID alias used by the post-Dawntrail quest chain. |
| **TowardTrouble** | 70968 | Quest ID alias used by the post-Dawntrail quest chain. |
| **WhereWeCallHome** | 70969 | Quest ID alias used by the post-Dawntrail quest chain. |
| **IntotheMist** | 70970 | Quest ID alias used by the post-Dawntrail quest chain. |
| **BrotherdDutyDestination** | Profile-defined NPC ID | Selects the applicable destination NPC during the related Dawntrail quest. |
| **ShadyHoobigo** | 1046659 | NPC ID alias used by Dawntrail quest logic. |
| **Wawkesa** | 1046654 | NPC ID alias used by Dawntrail quest logic. |

## Free Profile Use and Active Subscriptions

### No Active Subscription

You may install PandaFarmerWPF and manually load these XML profiles in OrderBot without an active Panda Farmer subscription. The plugin installation is still required so RebornBuddy can resolve the Panda Farmer OrderBot tags used by the profiles.

### With an Active Subscription

An active Panda Farmer subscription unlocks the full PandaFarmerWPF application workflow, including:

- Starting supported activities from the translated PandaFarmerWPF interface instead of manually editing and loading XML files
- Building MSQ profiles from remotely maintained quest sections using selected MSQ settings
- Duty Leveling with selectable unlocked jobs, early-level Hunting Log and class quest support, stop-at-level handling, and leveling summaries
- Dungeon Farming with separate dungeon, trial, and raid selection, queue settings, and configurable run counts
- Miscellaneous profile generation for supported activities such as Aether Currents, Facet quests, role quests, class unlocks, Grand Company ranking, achievements, and other maintained profiles
- Auto Party carry mode, including cross-world coordination, whitelisting, duty requests, request queues, and carry-session summaries
- Automatic class/job selection, class quest handling, optional unlock controls where supported, companion skill assignment, and other UI-managed profile options
- Product-key-validated start buttons, profile-generation status, session caching for remote profile sections, and automatic loading and starting of generated profiles

The exact available activities may change as PandaFarmerWPF and the remote profile collection are updated.

## Troubleshooting

### Panda Farmer tags are unknown

Confirm PandaFarmerWPF is installed directly under **RebornBuddy/Plugins/PandaFarmerWPF**, restart RebornBuddy, and verify that the plugin appears in the Plugins window.

### A profile does not start at the beginning

This is expected. The profiles use completed-quest checks and begin at the first quest applicable to the current character.

### A feature does not run

Confirm its entity is set to True, the supporting plugin is installed when required, and the character meets the quest, level, duty, and unlock requirements.

### A profile stops for manual input

Some solo duties, game prompts, or newly released encounters may intentionally use a user dialog until reliable automation is available.

## Required Manual MSQ Steps

The profiles stop and display a message when a required duty or interaction cannot be completed reliably. The following steps are currently documented as requiring manual attention. See the [Panda Farmer manual steps documentation](https://llamamagic.net/plugins/pandafarmer/#2x-a-realm-reborn-manual-steps) for the maintained online list.

### 2.x: A Realm Reborn

- **You Have Selected Regicide** (level 50): complete the 8-player trial **Thornmarch (Hard)**.
- **Lord of the Whorl** (level 50): complete the 8-player trial **The Whorleater (Hard)**.
- **Levin an Impression** (level 50): complete the 8-player trial **The Striking Tree (Hard)**.
- **The Instruments of Our Deliverance** (level 50): complete the 8-player trial **Akh Afah Amphitheater (Hard)**.
- **Ifrit Bleeds, We Can Kill It** (level 50): complete the 8-player trial **The Bowl of Embers (Hard)**.
- **In For Garuda Awakening** (level 50): complete the 8-player trial **The Howling Eye (Hard)**.
- **In a Titan Spot** (level 50): complete the 8-player trial **The Navel (Hard)**.
- **An Uninvited Ascian** (level 50): complete the 8-player trial **The Chrysalis**.
- **The Steps of Faith** (level 50): complete the solo duty.
- **The Labyrinth of the Ancients** (level 50): complete the 24-player raid **Labyrinth of the Ancients**.
- **Syrcus Tower** (level 50): complete the 24-player raid **Syrcus Tower**.
- **The World of Darkness** (level 50): complete the 24-player raid **The World of Darkness**.

### 3.x: Heavensward

- **Lord of the Hive** (level 53): complete the 8-player trial **Thok ast Thok (Hard)**.
- **Bolt, Chain, and Island** (level 57): complete the 8-player trial **The Limitless Blue (Hard)**.
- **Heavensward** (level 60): complete the 8-player trial **The Singularity Reactor**.
- **An End to the Song** (level 60): complete the 8-player trial **The Final Steps of Faith**.
- **The Beast That Mourned at the Heart of the Mountain** (level 60): complete the 8-player trial **The Navel (Hard)**.
- **Fly Free, My Pretty** (level 60): complete the solo duty.

### 4.x: Stormblood

- **It's Probably a Trap** (level 61): complete the solo duty.
- **The Lord of the Revel** (level 63): complete the 8-player trial **The Pool of Tribute**.
- **In the Footsteps of Bardam the Brave** (level 65): complete the 4-player dungeon **Bardam's Mettle**.
- **Naadam** (level 66): complete the solo duty.
- **The Lady of Bliss** (level 67): complete the 8-player trial **Emanation**.
- **The Resonant** (level 69): complete the solo duty.
- **Stormblood** (level 70): complete the 8-player trial **The Royal Menagerie**.
- **The Mad King's Trove** (level 70): swim underwater to unlock the dungeon.
- **The Primary Agreement** (level 70): complete the 8-player trial **Castrum Fluminis**.
- **Emissary of the Dawn** (level 70): complete the solo duty.
- **The Will of the Moon** (level 70): complete the solo duty.
- **A Requiem for Heroes** (level 70): complete the solo duty.

### 5.x: Shadowbringers

- **Acht-la Ormh Inn** (level 73): complete the 8-player trial **The Dancing Plague**.
- **Full Steam Ahead** (level 77): complete the solo duty.
- **Extinguishing the Last Light** (level 79): complete the 8-player trial **The Crown of the Immaculate**.
- **Shadowbringers** (level 80): complete the 4-player dungeon **Amaurot**.
- **Shadowbringers** (level 80): complete the 8-player trial **The Dying Gasp**.
- **A Grand Adventure** (level 80): complete the 4-player dungeon **The Grand Cosmos**.
- **Vows of Virtue, Deeds of Cruelty** (level 80): complete the solo duty.
- **The Converging Light** (level 80): complete the 4-player dungeon **The Heroes' Gauntlet**.
- **Hope's Confluence** (level 80): complete the 8-player trial **The Seat of Sacrifice**.
- **Like Master, Like Pupil** (level 80): complete the 4-player dungeon **Matoya's Relict**.
- **The Great Ship Vylbrand** (level 80): complete the solo duty.
- **The Flames of War** (level 80): complete the 4-player dungeon **Paglth'an**.
- **Death Unto Dawn** (level 80): complete the solo duty.

### 6.x: Endwalker

- **A Frosty Reception** (level 82): complete the required partial solo duty.
- **In from the Cold** (level 83): complete the solo duty.
- **The Martyr** (level 83): complete the 8-player trial **The Dark Inside**.
- **As the Heavens Burn** (level 88): complete the solo duty.
- **Her Children, One and All** (level 89): complete the 4-player dungeon **The Aitiascope**.
- **Her Children, One and All** (level 89): complete the 8-player trial **The Mothercrystal**.
- **Endwalker** (level 90): complete the 8-player trial **The Final Day**.
- **Endwalker** (level 90): complete the solo duty.
- **Alzadaal's Legacy** (level 90): complete the 4-player dungeon **Alzadaal's Legacy**.
- **The Wind Rises** (level 90): complete the 8-player trial **The Storm's Crown**.

### 7.x: Dawntrail

- **A Father First** (level 92): complete the solo duty and its quick-time event.
- **The High Luminary** (level 93): complete the 4-player duty **Worqor Zormor**.
- **Taking a Stand** (level 94): complete the role-playing solo duty as Wuk Lamat.
- **The Feat of the Brotherhood** (level 95): complete the solo duty.
- **Road to the Golden City** (level 95): complete the 4-player duty **The Skydeep Cenote**.
- **All Aboard** (level 97): complete the 4-player duty **Vanguard**.
- **The Protector and the Destroyer** (level 98): complete the solo duty.
- **The Resilient Son** (level 99): complete the 4-player duty **Origenics**.
- **The Resilient Son** (level 99): complete the 8-player trial **Everkeep**.
- **Dreams of a New Day** (level 100): complete the solo duty.
- **Dawntrail** (level 100): complete the 4-player duty **Alexandria**.
- **Dawntrail** (level 100): complete the 8-player trial **The Interphos**.

The profiles include automation for Worqor Zormor, The Skydeep Cenote, Vanguard, Origenics, Everkeep, and Alexandria. Their mechanics are not fully optimized and may not be reliable on non-tank jobs. A tank may queue automatically; other roles may be stopped so the duty can be completed manually before continuing.
