<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X - 抖音小遊戲廣告

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#quick-start) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 項目簡介

GameFrameX 廣告組件的抖音小遊戲適配層，基於 [StarkSDK](https://github.com/gameframex/GameFrameX) 封裝激勵影片廣告的載入、展示與生命週期管理。

## 快速開始

**方式一：修改 `manifest.json`**

```json
{
  "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
}
```

**方式二：Unity Package Manager**

開啟 `Window > Package Manager`，點擊 `+` 選擇 `Add package from git URL`，輸入：

```
https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git
```

**方式三：手動安裝**

將本倉庫克隆到 Unity 專案的 `Packages/` 目錄下即可自動識別。

## 使用範例

本套件為 `com.gameframex.unity.advertisement` 的子組件，不直接對外暴露介面。請透過主廣告套件統一呼叫：

- 主廣告套件：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## 架構概覽

### 功能特性

- 激勵影片廣告載入與展示
- 廣告載入/展示成功與失敗回呼
- 廣告關閉時自動判斷有效觀看
- IL2CPP 程式碼裁剪防護（`Preserve` 屬性 + `CroppingHelper`）
- 條件編譯（`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME`）

### 依賴

| 依賴 | 說明 |
|:-----|:-----|
| `com.gameframex.unity.advertisement` | 廣告主套件，提供 `BaseAdvertisementManager` 基類 |
| `starksdk.dll` | 字節跳動 StarkSDK 執行時庫 |
| `ttsdk.dll` | 字節跳動 TTSDK 執行時庫 |

### 專案結構

```
Runtime/
├── DouYinMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # 廣告管理器，繼承 BaseAdvertisementManager
│   └── DouYinVideoAdCallback.cs                # 影片廣告回呼處理器
├── GameFrameXAdvertisementDouYinMiniGameCroppingHelper.cs  # 防裁剪輔助類
└── GameFrameX.Advertisement.DouYinMiniGame.Runtime.asmdef   # 組件定義
```

## 平台支援

- 程式碼僅在 `UNITY_WEBGL` 且定義了 `ENABLE_DOUYIN_MINI_GAME` 巨集時編譯。
- 抖音官方 SDK 的激勵廣告介面未完整實作播放成功/失敗的回呼，部分回呼可能不會觸發。

## 文檔與資源

- [文檔](https://gameframex.doc.alianblank.com)
- [更新日誌](./CHANGELOG.md)

## 開源協議

[MIT](./LICENSE.md)
