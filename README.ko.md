<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X - 도우인 미니 게임 광고

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.advertisement.douyinminigame)](https://github.com/GameFrameX/com.gameframex.unity.advertisement.douyinminigame/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#quick-start) · QQ 그룹: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>

## 프로젝트 개요

GameFrameX 광고 컴포넌트의 도우인 미니 게임 어댑터 레이어입니다. [StarkSDK](https://github.com/gameframex/GameFrameX)를 기반으로 리워드 동영상 광고의 로드, 표시 및 라이프사이클 관리를 래핑합니다.

## 빠른 시작

### 설치

다음 방법 중 하나를 선택하세요:

1. Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:
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

   `scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

2. `manifest.json`의 `dependencies`에 직접 추가:
   ```json
   {
      "com.gameframex.unity.advertisement.douyinminigame": "https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git"
   }
   ```
3. Unity의 **Package Manager**에서 **Git URL**을 사용하여 추가: `https://github.com/gameframex/com.gameframex.unity.advertisement.douyinminigame.git`
4. 리포지토리를 Unity 프로젝트의 `Packages` 디렉토리에 클론하세요. 자동으로 로드됩니다.
## 사용 예시

이 패키지는 `com.gameframex.unity.advertisement`의 하위 컴포넌트로, 공개 API를 직접 노출하지 않습니다. 메인 광고 패키지를 통해 통일적으로 접근하세요:

- 메인 패키지: [com.gameframex.unity.advertisement](https://github.com/gameframex/com.gameframex.unity.advertisement)

## 아키텍처

### 기능

- 리워드 동영상 광고 로드 및 표시
- 광고 로드/표시 성공 및 실패 콜백
- 광고 닫기 시 유효 시청 자동 판정
- IL2CPP 코드 스트리핑 방지 (`Preserve` 속성 + `CroppingHelper`)
- 조건부 컴파일 (`UNITY_WEBGL` + `ENABLE_DOUYIN_MINI_GAME`)

### 의존성

| 의존성 | 설명 |
|:-------|:-----|
| `com.gameframex.unity.advertisement` | 메인 광고 패키지, `BaseAdvertisementManager` 기본 클래스 제공 |
| `starksdk.dll` | ByteDance StarkSDK 런타임 라이브러리 |
| `ttsdk.dll` | ByteDance TTSDK 런타임 라이브러리 |

### 프로젝트 구조

```
Runtime/
├── DouYinMiniGame/
│   ├── DouYinMiniGameAdvertisementManager.cs   # 광고 관리자, BaseAdvertisementManager 상속
│   └── DouYinVideoAdCallback.cs                # 동영상 광고 콜백 핸들러
├── GameFrameXAdvertisementDouYinMiniGameCroppingHelper.cs  # 스트리핑 방지 헬퍼
└── GameFrameX.Advertisement.DouYinMiniGame.Runtime.asmdef   # 어셈블리 정의
```

## 플랫폼 지원

- 코드는 `UNITY_WEBGL` 및 `ENABLE_DOUYIN_MINI_GAME`이 정의된 경우에만 컴파일됩니다.
- 도우인 공식 SDK의 리워드 광고 인터페이스는 표시 성공/실패 콜백을 완전히 구현하지 않아, 일부 콜백이 트리거되지 않을 수 있습니다.

## 문서 및 자료

- [문서](https://gameframex.doc.alianblank.com)
- [변경 로그](./CHANGELOG.md)


## 의존성

| 패키지 | 설명 |
|--------|------|
| (无) | - |


## 커뮤니티 및 지원

- QQ 그룹: 467608841 / 233840761

## 변경 로그

[Releases](https://github.com/GameFrameX/gameframex/com.gameframex.unity.advertisement.douyinminigame/releases)에서 변경 로그를 확인하세요.
## 라이선스

[MIT](./LICENSE.md)
