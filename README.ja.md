<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X - 抖音ミニゲーム広告

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#quick-start) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>

## プロジェクト概要

GameFrameX 広告コンポーネントの抖音ミニゲーム適配レイヤー。[StarkSDK](https://github.com/gameframex/GameFrameX) をベースに、リワード動画広告の読み込み、表示、ライフサイクル管理をラップしています。本パッケージは `DouYinMiniGameAdvertisementBootstrap` によって `BeforeSceneLoad` ステージでメインパッケージの `AdvertisementRegistry` に自己登録します（`UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT` マクロが有効でない場合コードはストリップされ、登録は行われません。参照することが登録です）。初期化はファクトリクロージャー経由で強く型付けされた設定を注入します。

## クイックスタート

### インストール

以下のいずれかの方法を選択してください：

1. Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：
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

   `scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

2. `manifest.json` の `dependencies` に直接追加：
   ```json
   {
      "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
   }
   ```
3. Unity の **Package Manager** で **Git URL** を使用して追加：`https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git`
4. リポジトリを Unity プロジェクトの `Packages` ディレクトリにクローンしてください。自動的に読み込まれます。

### チャネル登録と設定

起動時（初回の広告呼び出し前）に `DouYinMiniGameAdvertisementBootstrap.Config` を設定してください：

```csharp
using GameFrameX.Advertisement.Runtime;

// 起動時（初回の広告呼び出し前）にチャネル設定を注入
DouYinMiniGameAdvertisementBootstrap.Config = new DouYinMiniGameAdvertisementConfig
{
    adUnitId = "広告ユニットID",
    isDebug = false,
};

// その後は通常どおり AdvertisementComponent を使用。または明示的にルーティング
var manager = AdvertisementRegistry.ResolveManager("douyinminigame");
```

チャネルの `ChannelId` 定数は `"douyinminigame"` で、`AdvertisementRegistry.ResolveManager("douyinminigame")` で本チャネルへ明示的にルーティングできます。
## 使用例

このパッケージは `com.gameframex.unity.advertisement` のサブコンポーネントであり、公開 API を直接公開しません。メイン広告パッケージから統一的にアクセスしてください：

- メインパッケージ：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## アーキテクチャ

### 機能

- リワード動画広告の読み込みと表示
- 広告の読み込み/表示の成功・失敗コールバック
- 広告クローズ時の有効視聴自動判定
- IL2CPP コードストリッピング対策（`Preserve` 属性 + `CroppingHelper`）
- 条件付きコンパイル（`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME` + `ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT`）

### 依存関係

| 依存関係 | 説明 |
|:---------|:-----|
| `com.gameframex.unity.advertisement` | メイン広告パッケージ、`BaseAdvertisementManager` 基底クラスを提供 |
| `starksdk.dll` | ByteDance StarkSDK ランタイムライブラリ |
| `ttsdk.dll` | ByteDance TTSDK ランタイムライブラリ |

### プロジェクト構成

```
Runtime/
├── DouYinMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # 広告マネージャー、BaseAdvertisementManager を継承
│   └── DouYinVideoAdCallback.cs                # 動画広告コールバックハンドラー
├── GameFrameXAdvertisementDouYinMiniGameCroppingHelper.cs  # ストリッピング防止ヘルパー
└── GameFrameX.Advertisement.DouYinMiniGame.Runtime.asmdef   # アセンブリ定義
```

### 主要なクラス

- **`DouYinMiniGameAdvertisementManager`**: 抖音ミニゲーム広告マネージャー。`ChannelId = "douyinminigame"` 定数を持ちます。
- **`DouYinMiniGameAdvertisementConfig`**: `adUnitId`（広告ユニットID）フィールドを持つ強く型付けされたチャネル設定。`DouYinMiniGameAdvertisementBootstrap.Config` 経由で注入。
- **`DouYinMiniGameAdvertisementBootstrap`**: チャネルの起動時登録。`BeforeSceneLoad` ステージでメインパッケージの `AdvertisementRegistry` に自己登録し、起動時の `Config` 静的プロパティを持ちます。

### 破壊的変更（v2.1）

- **マクロ選択の広告ユニットIDフィールドの削除**：`AdvertisementComponent` の「WebGL 抖音 広告ユニットID」シリアライズフィールドは削除され、`adUnitId` は `DouYinMiniGameAdvertisementBootstrap.Config` 経由で注入されます；
- **メインパッケージの Inspector タイプドロップダウンの削除**：チャネル発見はメインパッケージの `AdvertisementRegistry` に統一されました。

## プラットフォーム対応

- コードは `UNITY_WEBGL` と `ENABLE_DOUYIN_MINI_GAME`、`ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT` が定義されている場合のみコンパイルされます。
- 抖音公式 SDK のリワード広告インターフェースは表示成功/失敗のコールバックを完全に実装しておらず、一部のコールバックが発火しない場合があります。

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)
- [変更履歴](./CHANGELOG.md)


## 依存関係

| パッケージ | 説明 |
|----------|------|
| (无) | - |


## コミュニティとサポート

- QQグループ: 467608841 / 233840761

## 変更履歴

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.advertisement.douyinminigame/releases) で変更履歴を確認してください。
## ライセンス

[MIT](./LICENSE.md)
