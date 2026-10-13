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

GameFrameX 廣告組件的抖音小遊戲適配層，基於 [StarkSDK](https://github.com/gameframex/GameFrameX) 封裝激勵影片廣告的載入、展示與生命週期管理。本包通過 `DouYinMiniGameAdvertisementBootstrap` 在 `BeforeSceneLoad` 階段自註冊進主包 `AdvertisementRegistry`（宏 `UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT` 未啟用時代碼被裁剪，註冊不會發生；引用即註冊）；初始化由工廠閉包注入強型別配置。

## 快速開始

### 安裝

選擇以下任一方式：

1. 編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
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

   `scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

2. 直接在 `manifest.json` 的 `dependencies` 節點下添加以下內容：
   ```json
   {
      "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
   }
   ```
3. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加庫，地址為：`https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git`
4. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。

### 渠道註冊與配置

在啟動期（首次廣告呼叫前）對 `DouYinMiniGameAdvertisementBootstrap.Config` 賦值：

```csharp
using GameFrameX.Advertisement.Runtime;

// 啟動期（首次廣告呼叫前）注入渠道配置
DouYinMiniGameAdvertisementBootstrap.Config = new DouYinMiniGameAdvertisementConfig
{
    adUnitId = "你的廣告位ID",
    isDebug = false,
};

// 之後照常使用 AdvertisementComponent；或顯式路由到本渠道
var manager = AdvertisementRegistry.ResolveManager("douyinminigame");
```

渠道 `ChannelId` 常量值為 `"douyinminigame"`，可通過 `AdvertisementRegistry.ResolveManager("douyinminigame")` 顯式路由到本渠道。
## 使用範例

本套件為 `com.gameframex.unity.advertisement` 的子組件，不直接對外暴露介面。請透過主廣告套件統一呼叫：

- 主廣告套件：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## 架構概覽

### 功能特性

- 激勵影片廣告載入與展示
- 廣告載入/展示成功與失敗回呼
- 廣告關閉時自動判斷有效觀看
- IL2CPP 程式碼裁剪防護（`Preserve` 屬性 + `CroppingHelper`）
- 條件編譯（`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME` + `ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT`）

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

### 主要類

- **`DouYinMiniGameAdvertisementManager`**: 抖音小遊戲廣告管理器，含 `ChannelId = "douyinminigame"` 常量。
- **`DouYinMiniGameAdvertisementConfig`**: 渠道強型別配置，含 `adUnitId`（廣告位ID）欄位，經 `DouYinMiniGameAdvertisementBootstrap.Config` 注入。
- **`DouYinMiniGameAdvertisementBootstrap`**: 渠道啟動註冊，`BeforeSceneLoad` 階段自註冊進主包 `AdvertisementRegistry`，含啟動期 `Config` 靜態屬性。

### 破壞性變更（v2.1）

- **宏選廣告位ID欄位已移除**：`AdvertisementComponent` 上的「WebGL 抖音 廣告位ID」序列化欄位已刪除，`adUnitId` 改經 `DouYinMiniGameAdvertisementBootstrap.Config` 注入；
- **主包 Inspector 類型下拉已移除**：渠道發現統一收斂到主包 `AdvertisementRegistry`。

## 平台支援

- 程式碼僅在 `UNITY_WEBGL` 且定義了 `ENABLE_DOUYIN_MINI_GAME` 與 `ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT` 巨集時編譯。
- 抖音官方 SDK 的激勵廣告介面未完整實作播放成功/失敗的回呼，部分回呼可能不會觸發。

## 文檔與資源

- [文檔](https://gameframex.doc.alianblank.com)
- [更新日誌](./CHANGELOG.md)


## 依賴

| 套件 | 說明 |
|------|------|
| (无) | - |


## 社區與支援

- QQ群: 467608841 / 233840761

## 更新日誌

查看 [Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.advertisement.douyinminigame/releases) 了解更新日誌。
## 開源協議

[MIT](./LICENSE.md)
