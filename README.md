# [RebornProfiles][0]

[![Download][1]][2]
[![Discord][3]][4]
[![](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=GitHub&color=%23fe8e86)](https://github.com/sponsors/domesticwarlord86)
[![Donate][5]][6]


**RebornProfiles** is a collection of various OrderBot scripts for [RebornBuddy][7].

## Installation

### Prerequisites

- [RebornBuddy][7] with active license (paid)
- [ExBuddy][8] (free)
- [Lisbeth][9] with active license (paid)
- [LlamaLibrary][10] (free)
- Better combat routine, such as [Magitek][11] (free)

### Automatic Setup (recommended)

The easiest way to install LlamaLibrary is to install the [updateBuddy](https://loader.updatebuddy.net/UpdateBuddy.zip) plugin. It would be installed in the **/plugins** folder of your rebornBuddy folder as such:
```
RebornBuddy
└── Plugins
    └── updateBuddy
        ├── git2-a2bde63.dll
        ├── LibGit2Sharp.dll
        ├── Loader.cs
        └── UpdateBuddy.dll
```

It will automatically install the files into the correct folders and keep them up to date.

### Manual Setup

If you prefer manual setup instead of automatic,

1. Download the [latest version][2].
2. On the `.zip` file, right click > `Properties` > `Unblock` > `Apply`.
3. Unzip all contents into `RebornBuddy\Profiles\` so it looks like this:

```
RebornBuddy
└── Profiles
    └── RebornProfiles
        ├── README.md
        └── ...
```

4. Start RebornBuddy as normal.

## Usage

To load an OrderBot script:

1. Start RebornBuddy and set the BotBase dropdown to `Order Bot`.
2. Click `Load Profile` and navigate to `RebornBuddy\Profiles\RebornProfiles\`.
3. Select the desired `.xml` script from the appropriate subfolder.
4. Back in RebornBuddy, click `Start`.
5. Watch for notifications in the client and logs -- some profiles require intervention!

## Troubleshooting

For live volunteer support, join the [Project BR Discord][4] channel `#support`.

When asking for help, always include:

- which script you loaded,
- what you tried to do,
- what went wrong,
- relevant logs from the `RebornBuddy\Logs\` folder.

No need to ask if anyone's around or for permission to ask -- just go for it!

## Want more?

If you're interested in more of my work, check out [LlamaMagic](https://llamamagic.net/plugins/pandafarmer/). There you can find all of my more advanced plugins that give you an easy to use interface for my various OrderBot profiles. Including one click MSQ support. Duty Leveling for your various jobs. As well as farming nearly every Duty Support dungeon in the game. Check it out!

<!-- ## Looking to Donate? ❤️

[![Donate via Ko-Fi](https://i.imgur.com/bXUIjNA.png)][6] -->

[0]: https://github.com/domesticwarlord86/RebornProfiles "RebornProfiles on GitHub"
[1]: https://img.shields.io/badge/-Download-brightgreen
[2]: https://github.com/domesticwarlord86/RebornProfiles/archive/refs/heads/main.zip "Download"
[3]: https://img.shields.io/badge/Discord-7389D8?logo=discord&logoColor=ffffff&labelColor=6A7EC2
[4]: https://discord.gg/CucSWEhJSZ "Discord"
[5]: https://shields.io/badge/-Buy%20me%20a%20coffee-FF5E5B?logo=kofi&logoColor=ffffff&labelColor=FF5E5B
[6]: https://ko-fi.com/domesticwarlord86 "Donate via Ko-Fi"
[7]: https://www.rebornbuddy.com/ "RebornBuddy"
[8]: https://github.com/LlamaMagic/ExBuddy "ExBuddy"
[9]: https://www.siune.io/ "Lisbeth"
[10]: https://github.com/nt153133/__LlamaLibrary "LlamaLibrary"
[11]: https://discord.gg/rDsFbKr "Magitek Discord"
[12]: https://github.com/Zimgineering/repoBuddy "RepoBuddy"
