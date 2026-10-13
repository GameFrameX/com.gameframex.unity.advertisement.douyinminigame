#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT

// ==========================================================================================
//   GameFrameX 组织及其衍生项目的版权、商标、专利及其他相关权利
//   GameFrameX organization and its derivative projects' copyrights, trademarks, patents, and related rights
//   均受中华人民共和国及相关国际法律法规保护。
//   are protected by the laws of the People's Republic of China and relevant international regulations.
//   使用本项目须严格遵守相关法律法规及开源许可证之规定。
//   Usage of this project must strictly comply with applicable laws, regulations, and open-source licenses.
//   本项目采用 MIT 许可证与 Apache License 2.0 双许可证分发，
//   This project is dual-licensed under the MIT License and Apache License 2.0,
//   完整许可证文本请参见源代码根目录下的 LICENSE 文件。
//   please refer to the LICENSE file in the root of the source tree for the full license text.
//   禁止利用本项目实施任何危害国家安全、破坏社会秩序、
//   It is prohibited to use this project to engage in any activities that endanger national security, disrupt social order,
//   侵犯他人合法权益等法律法规所禁止的行为！
//   or infringe upon the legitimate rights and interests of others, as prohibited by laws and regulations!
//   因基于本项目二次开发所产生的一切法律纠纷与责任，
//   Any disputes or liabilities arising from secondary development based on this project
//   本项目组织及贡献者概不承担。
//   shall be borne solely by the developer; the project organization and contributors assume no responsibility.
//   GitHub 仓库：https://github.com/GameFrameX
//   GitHub Repository: https://github.com/GameFrameX
//   Gitee  仓库：https://gitee.com/GameFrameX
//   Gitee Repository:  https://gitee.com/GameFrameX
//   CNB  仓库：https://cnb.cool/GameFrameX
//   CNB Repository:  https://cnb.cool/GameFrameX
//   官方文档：https://gameframex.doc.alianblank.com/
//   Official Documentation: https://gameframex.doc.alianblank.com/
//  ==========================================================================================

using GameFrameX.Advertisement.Runtime;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    /// <summary>
    /// 抖音小游戏渠道启动注册
    /// </summary>
    /// <remarks>
    /// 在 BeforeSceneLoad 阶段将渠道注册进 <see cref="AdvertisementRegistry"/>；未安装本包或宏未启用时代码被裁剪，注册不会发生（引用即注册）。
    /// 渠道配置（adUnitId，由 AdvertisementComponent 宏选字段下沉而来）为启动期强类型配置：游戏侧在首次广告调用前对
    /// <see cref="Config"/> 赋值即可；管理器在首次被注册表解析时才实例化，配置注入发生在工厂闭包内。
    /// </remarks>
    [UnityEngine.Scripting.Preserve]
    internal static class DouYinMiniGameAdvertisementBootstrap
    {
        /// <summary>
        /// 获取或设置抖音小游戏渠道配置（启动期由游戏侧赋值，默认值为空配置）
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public static DouYinMiniGameAdvertisementConfig Config { get; set; } = new DouYinMiniGameAdvertisementConfig();

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        [UnityEngine.Scripting.Preserve]
        private static void Register()
        {
            AdvertisementRegistry.Register(new AdvertisementChannelRegistration(
                DouYinMiniGameAdvertisementManager.ChannelId,
                "抖音小游戏",
                () =>
                {
                    var manager = new DouYinMiniGameAdvertisementManager();
                    manager.Initialize(Config ?? new DouYinMiniGameAdvertisementConfig());
                    return manager;
                }));
        }
    }
}

#endif
