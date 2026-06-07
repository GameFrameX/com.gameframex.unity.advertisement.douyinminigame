<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X - 抖音ミニゲーム広告

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#quick-start) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>
## プロジェクト概要

GameFrameX 広告コンポーネントの抖音ミニゲーム適配レイヤー。[StarkSDK](https://github.com/gameframex/GameFrameX) をベースに、リワード動画広告の読み込み、表示、ライフサイクル管理をラップしています。

## クイックスタート

**方法1：`manifest.json` を編集**

```json
{
  "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
}
```

**方法2：Unity Package Manager**

`Window > Package Manager` を開き、`+` をクリックして `Add package from git URL` を選択：

```
https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git
```

**方法3：手動インストール**

このリポジトリを Unity プロジェクトの `Packages/` ディレクトリにクローンすると自動的に認識されます。

## 使用例

このパッケージは `com.gameframex.unity.advertisement` のサブコンポーネントであり、公開 API を直接公開しません。メイン広告パッケージから統一的にアクセスしてください：

- メインパッケージ：[com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## アーキテクチャ

### 機能

- リワード動画広告の読み込みと表示
- 広告の読み込み/表示の成功・失敗コールバック
- 広告クローズ時の有効視聴自動判定
- IL2CPP コードストリッピング対策（`Preserve` 属性 + `CroppingHelper`）
- 条件付きコンパイル（`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME`）

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

## プラットフォーム対応

- コードは `UNITY_WEBGL` と `ENABLE_DOUYIN_MINI_GAME` が定義されている場合のみコンパイルされます。
- 抖音公式 SDK のリワード広告インターフェースは表示成功/失敗のコールバックを完全に実装しておらず、一部のコールバックが発火しない場合があります。

## ドキュメントとリソース

- [ドキュメント](https://gameframex.doc.alianblank.com)
- [変更履歴](./CHANGELOG.md)

## ライセンス

[MIT](./LICENSE.md)
