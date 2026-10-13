<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X - DouYin Mini Game Advertisement

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

DouYin Mini Game ad adapter layer for the GameFrameX advertisement component. Built on [StarkSDK](https://github.com/gameframex/GameFrameX), it wraps rewarded video ad loading, display, and lifecycle management. This package self-registers into the main package's `AdvertisementRegistry` via `DouYinMiniGameAdvertisementBootstrap` at the `BeforeSceneLoad` stage (when the macros `UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT` are not enabled the code is stripped and registration does not happen; referencing the package is registering); initialization is injected with a strongly-typed config through the factory closure.

## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.advertisement.douyinminigame": "1.3.1"
     }
   }
   ```

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.

### Channel Registration & Configuration

Assign `DouYinMiniGameAdvertisementBootstrap.Config` at startup (before the first ad call):

```csharp
using GameFrameX.Advertisement.Runtime;

// Inject the channel config at startup (before the first ad call)
DouYinMiniGameAdvertisementBootstrap.Config = new DouYinMiniGameAdvertisementConfig
{
    adUnitId = "your ad unit id",
    isDebug = false,
};

// Then use AdvertisementComponent as usual; or explicitly route to this channel
var manager = AdvertisementRegistry.ResolveManager("douyinminigame");
```

The channel `ChannelId` constant is `"douyinminigame"`; `AdvertisementRegistry.ResolveManager("douyinminigame")` routes explicitly to this channel.
## Usage Examples

This package is a sub-component of `com.gameframex.unity.advertisement` and does not expose public APIs directly. Use the main advertisement package for unified access:

- Main package: [com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## Architecture

### Features

- Rewarded video ad loading and display
- Ad load/show success and failure callbacks
- Automatic valid-view detection on ad close
- IL2CPP code stripping protection (`Preserve` attribute + `CroppingHelper`)
- Conditional compilation (`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME` + `ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT`)

### Dependencies

| Dependency | Description |
|:-----------|:------------|
| `com.gameframex.unity.advertisement` | Main ad package, provides `BaseAdvertisementManager` base class |
| `starksdk.dll` | ByteDance StarkSDK runtime library |
| `ttsdk.dll` | ByteDance TTSDK runtime library |

### Project Structure

```
Runtime/
├── DouYinMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # Ad manager, inherits BaseAdvertisementManager
│   └── DouYinVideoAdCallback.cs                # Video ad callback handler
├── GameFrameXAdvertisementDouYinMiniGameCroppingHelper.cs  # Anti-stripping helper
└── GameFrameX.Advertisement.DouYinMiniGame.Runtime.asmdef   # Assembly definition
```

### Main Classes

- **`DouYinMiniGameAdvertisementManager`**: DouYin Mini Game ad manager, with the `ChannelId = "douyinminigame"` constant.
- **`DouYinMiniGameAdvertisementConfig`**: Strongly-typed channel config with the `adUnitId` field, injected via `DouYinMiniGameAdvertisementBootstrap.Config`.
- **`DouYinMiniGameAdvertisementBootstrap`**: Channel startup registration; self-registers into the main package's `AdvertisementRegistry` at `BeforeSceneLoad`, with a startup-time `Config` static property.

### Breaking Changes (v2.1)

- **Macro-selected ad unit ID fields removed**: the serialized "WebGL DouYin ad unit ID" field on `AdvertisementComponent` has been removed; `adUnitId` is now injected via `DouYinMiniGameAdvertisementBootstrap.Config`;
- **Main package Inspector type dropdown removed**: channel discovery is now unified through the main package's `AdvertisementRegistry`.

## Platform Support

- Code compiles only when `UNITY_WEBGL`, `ENABLE_DOUYIN_MINI_GAME`, and `ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT` are defined.
- The DouYin official SDK does not fully implement rewarded ad show success/failure callbacks; some callbacks may not fire.

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)
- [Changelog](./CHANGELOG.md)


## Dependencies

| Package | Description |
|---------|-------------|
| (无) | - |


## Community & Support

- QQ Group: 467608841 / 233840761

## Changelog

See [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.advertisement.douyinminigame/releases) for changelog.
## License

[MIT](./LICENSE.md)
