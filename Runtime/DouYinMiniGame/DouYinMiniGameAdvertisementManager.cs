#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT

using System;
using GameFrameX.Advertisement.Runtime;
using GameFrameX.Runtime;
using StarkSDKSpace;
using TTSDK;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    /// <summary>
    /// 抖音小游戏激励视频广告管理器，负责广告的加载、展示和生命周期管理。
    /// </summary>
    /// <remarks>
    /// DouYin Mini Game rewarded video ad manager, responsible for ad loading, display, and lifecycle management.
    /// </remarks>
    [Preserve]
    public class DouYinMiniGameAdvertisementManager : BaseAdvertisementManager
    {
        private TTRewardedVideoAd _adManager;
        private string _adUnitId;
        private DouYinVideoAdCallback _douYinVideoAdCallback;

        /// <summary>
        /// 初始化广告管理器，设置广告单元Id和回调对象。
        /// </summary>
        /// <remarks>
        /// Initializes the ad manager, setting the ad unit ID and callback object.
        /// </remarks>
        /// <param name="adUnitId">广告单元Id / Ad unit ID</param>
        /// <param name="debug">是否启用调试模式 / Whether to enable debug mode</param>
        /// <exception cref="ArgumentNullException">当 <paramref name="adUnitId"/> 为空或 null 时抛出 / Thrown when <paramref name="adUnitId"/> is null or empty</exception>
        [Preserve]
        public override void Initialize(string adUnitId, bool debug = false)
        {
            GameFrameworkGuard.NotNullOrEmpty(adUnitId, nameof(adUnitId));
            _adUnitId = adUnitId;
            _douYinVideoAdCallback = new DouYinVideoAdCallback();
        }

        /// <summary>
        /// 广告关闭回调，处理观看结果并销毁广告实例。
        /// </summary>
        /// <remarks>
        /// Ad close callback, handles the viewing result and destroys the ad instance.
        /// </remarks>
        /// <param name="isComplete">视频是否观看完成 / Whether the video was watched to completion</param>
        /// <param name="count">观看时长计数 / Watch duration count</param>
        [Preserve]
        void OnCloseCallback(bool isComplete, int count)
        {
            _douYinVideoAdCallback.ShowResult?.Invoke(isComplete);
            _douYinVideoAdCallback.ShowResult = null;
            _adManager.Destroy();
            _adManager = null;
        }

        /// <summary>
        /// 播放激励视频广告，自动加载并展示。
        /// </summary>
        /// <remarks>
        /// Plays a rewarded video ad, automatically loading and displaying it.
        /// </remarks>
        /// <param name="playResult">播放结果回调，参数为是否观看完成 / Play result callback, parameter indicates whether watching was completed</param>
        /// <param name="customData">自定义数据，传递给广告服务端 / Custom data passed to the ad server</param>
        [Preserve]
        public override void Play(Action<bool> playResult, string customData = null)
        {
            void AdLoadSuccess(string isSuccess)
            {
                Show((s) => { Log.Debug(s); }, (f) => { Log.Error(f); }, playResult, customData);
            }

            Load(AdLoadSuccess, AdLoadFail);

            void AdLoadFail(string obj)
            {
                playResult?.Invoke(false);
            }
        }

        /// <summary>
        /// 使用播放选项播放激励视频广告。
        /// </summary>
        /// <remarks>
        /// Plays a rewarded video ad using the specified play options.
        /// </remarks>
        /// <param name="option">广告播放选项，包含成功、失败和展示结果回调 / Ad play options containing success, failure, and show result callbacks</param>
        public override void Play(AdvertisementPlayOption option)
        {
#pragma warning disable CS0618
            Load((s) =>
            {
                Show(option.OnSuccess, option.OnFail, option.OnShowResult, option.customData);
            }, (fail) =>
            {
                Debug.Log($"[DouYinMiniGame] Play Load Fail: {fail}");
                option.OnFail?.Invoke(fail);
                option.OnShowResult?.Invoke(false);
            }, option.extraData);
#pragma warning restore CS0618
        }

        /// <summary>
        /// 展示已加载的激励视频广告。
        /// </summary>
        /// <remarks>
        /// Shows the loaded rewarded video ad.
        /// </remarks>
        /// <param name="success">展示成功回调 / Show success callback</param>
        /// <param name="fail">展示失败回调，参数为错误信息 / Show failure callback, parameter is the error message</param>
        /// <param name="onShowResult">展示结果回调，参数为是否观看完成 / Show result callback, parameter indicates whether watching was completed</param>
        /// <param name="customData">自定义数据 / Custom data</param>
        [Preserve]
        public override void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult, string customData = null)
        {
            OnShowResult = onShowResult;
            _douYinVideoAdCallback.SetShowCallback(success, fail);
            _douYinVideoAdCallback.ShowResult = onShowResult;
            _adManager.OnClose += OnCloseCallback;
            _adManager.Show();
        }

        /// <summary>
        /// 加载激励视频广告，如果已存在则复用现有实例。
        /// </summary>
        /// <remarks>
        /// Loads a rewarded video ad, reusing the existing instance if available.
        /// </remarks>
        /// <param name="success">加载成功回调 / Load success callback</param>
        /// <param name="fail">加载失败回调，参数为错误信息 / Load failure callback, parameter is the error message</param>
        /// <param name="customData">自定义数据 / Custom data</param>
        [Preserve]
        public override void Load(Action<string> success, Action<string> fail, string customData = null)
        {
            if (_adManager != null)
            {
                _adManager.OnLoad += () => { success?.Invoke(""); };
                return;
            }

            _adManager = TT.CreateRewardedVideoAd(_adUnitId);
            _douYinVideoAdCallback.SetLoadCallback(success, fail);
            _adManager.OnLoad += () => { success?.Invoke(""); };
            _adManager.Load();
        }
    }
}

#endif