# 基于`抖音SDK` 的二次封装

该库主要服务于 `https://github.com/AlianBlank/GameFrameX` 作为子库使用。

# 使用主包进行使用。

该包是广告播放的子组件。不对外开放接口。请使用主包使用 `com.gameframex.unity.advertisement` github : https://github.com/AlianBlank/com.gameframex.unity.advertisement

# 使用方式(三种方式)
1. 直接在 `manifest.json` 文件中添加以下内容
   ```json
      {"com.gameframex.unity.advertisement.douyinminigame": "https://github.com/AlianBlank/com.gameframex.unity.advertisement.douyinminigame.git"}
    ```
2. 在Unity 的`Packages Manager` 中使用`Git URL` 的方式添加库,地址为：https://github.com/AlianBlank/com.gameframex.unity.advertisement.douyinminigame.git

3. 直接下载仓库放置到Unity 项目的`Packages` 目录下。会自动加载识别

# 改动功能

1. 增加 `GameFrameXAdvertisementDouYinMiniGameCroppingHelper` 防裁剪脚本