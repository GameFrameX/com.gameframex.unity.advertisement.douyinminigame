<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X - 抖音小游戏广告

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

独立游戏前后端一体化解决方案 · 独立游戏开发者的圆梦大使

<br />

[文档](https://gameframex.doc.alianblank.com) · [快速开始](#quick-start) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | **简体中文** | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 项目简介

GameFrameX 广告组件的抖音小游戏适配层，基于 [StarkSDK](https://github.com/gameframex/GameFrameX) 封装激励视频广告的加载、展示与生命周期管理。

## 快速开始

**方式一：修改 `manifest.json`**

```json
{
  "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
}
```

**方式二：Unity Package Manager**

打开 `Window > Package Manager`，点击 `+` 选择 `Add package from git URL`，输入：

```
https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git
```

**方式三：手动安装**

将本仓库克隆到 Unity 项目的 `Packages/` 目录下即可自动识别。

## 使用示例

本包为 `com.gameframex.unity.advertisement` 的子组件，不直接对外暴露接口。请通过主广告包统一调用：

- 主广告包：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## 架构概览

### 功能特性

- 激励视频广告加载与展示
- 广告加载/展示成功与失败回调
- 广告关闭时自动判断有效观看
- IL2CPP 代码裁剪防护（`Preserve` 属性 + `CroppingHelper`）
- 条件编译（`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME`）

### 依赖

| 依赖 | 说明 |
|:-----|:-----|
| `com.gameframex.unity.advertisement` | 广告主包，提供 `BaseAdvertisementManager` 基类 |
| `starksdk.dll` | 字节跳动 StarkSDK 运行时库 |
| `ttsdk.dll` | 字节跳动 TTSDK 运行时库 |

### 项目结构

```
Runtime/
├── DouYinMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # 广告管理器，继承 BaseAdvertisementManager
│   └── DouYinVideoAdCallback.cs                # 视频广告回调处理器
├── GameFrameXAdvertisementDouYinMiniGameCroppingHelper.cs  # 防裁剪辅助类
└── GameFrameX.Advertisement.DouYinMiniGame.Runtime.asmdef   # 程序集定义
```

## 平台支持

- 代码仅在 `UNITY_WEBGL` 且定义了 `ENABLE_DOUYIN_MINI_GAME` 宏时编译。
- 抖音官方 SDK 的激励广告接口未完整实现播放成功/失败的回调，部分回调可能不会触发。

## 文档与资源

- [文档](https://gameframex.doc.alianblank.com)
- [更新日志](./CHANGELOG.md)

## 开源协议

[MIT](./LICENSE.md)
