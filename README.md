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

DouYin Mini Game ad adapter layer for the GameFrameX advertisement component. Built on [StarkSDK](https://github.com/gameframex/GameFrameX), it wraps rewarded video ad loading, display, and lifecycle management.

## Quick Start

**Option 1: Edit `manifest.json`**

```json
{
  "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
}
```

**Option 2: Unity Package Manager**

Open `Window > Package Manager`, click `+` and select `Add package from git URL`:

```
https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git
```

**Option 3: Manual Install**

Clone this repository into your Unity project's `Packages/` directory. It will be detected automatically.

## Usage Examples

This package is a sub-component of `com.gameframex.unity.advertisement` and does not expose public APIs directly. Use the main advertisement package for unified access:

- Main package: [com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## Architecture

### Features

- Rewarded video ad loading and display
- Ad load/show success and failure callbacks
- Automatic valid-view detection on ad close
- IL2CPP code stripping protection (`Preserve` attribute + `CroppingHelper`)
- Conditional compilation (`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME`)

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

## Platform Support

- Code compiles only when `UNITY_WEBGL` and `ENABLE_DOUYIN_MINI_GAME` are defined.
- The DouYin official SDK does not fully implement rewarded ad show success/failure callbacks; some callbacks may not fire.

## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)
- [Changelog](./CHANGELOG.md)

## License

[MIT](./LICENSE.md)
