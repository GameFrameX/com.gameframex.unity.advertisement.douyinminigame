#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT
using System;
using StarkSDKSpace;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    /// <summary>
    /// 抖音视频广告回调处理器，处理广告的加载、展示、错误和关闭事件。
    /// </summary>
    /// <remarks>
    /// DouYin video ad callback handler, processing ad load, show, error, and close events.
    /// </remarks>
    [Preserve]
    internal class DouYinVideoAdCallback : StarkAdManager.VideoAdCallback
    {
        private Action<string> loadSuccess;
        private Action<string> loadFail;
        private Action<string> showSuccess;
        private Action<string> showFail;
        /// <summary>
        /// 获取或设置广告展示结果回调。
        /// </summary>
        /// <remarks>
        /// Gets or sets the ad show result callback.
        /// </remarks>
        /// <value>展示结果回调，参数为是否观看完成 / Show result callback, parameter indicates whether watching was completed</value>
        [Preserve] public Action<bool> ShowResult { get; set; }

        /// <summary>
        /// 视频广告加载完成时回调。
        /// </summary>
        /// <remarks>
        /// Callback when the video ad has finished loading.
        /// </remarks>
        [Preserve]
        public void OnVideoLoaded()
        {
            loadSuccess?.Invoke(null);
        }

        /// <summary>
        /// 视频广告成功展示时回调。
        /// </summary>
        /// <remarks>
        /// Callback when the video ad is successfully shown.
        /// </remarks>
        /// <param name="timestamp">展示时间戳 / Show timestamp</param>
        [Preserve]
        public void OnVideoShow(long timestamp)
        {
            showSuccess?.Invoke(timestamp.ToString());
        }

        /// <summary>
        /// 广告发生错误时回调，同时通知加载和展示的失败回调。
        /// </summary>
        /// <remarks>
        /// Callback when an ad error occurs, notifying both load and show failure callbacks.
        /// </remarks>
        /// <param name="errCode">错误码 / Error code</param>
        /// <param name="errorMessage">错误信息 / Error message</param>
        [Preserve]
        public void OnError(int errCode, string errorMessage)
        {
            loadFail?.Invoke(errorMessage);
            showFail?.Invoke(errorMessage);
        }

        /// <summary>
        /// 视频广告关闭时回调，根据观看时长判断是否为有效观看。
        /// </summary>
        /// <remarks>
        /// Callback when the video ad is closed, determining valid viewing based on watch duration.
        /// </remarks>
        /// <param name="watchedTime">实际观看时长（秒） / Actual watch duration in seconds</param>
        /// <param name="effectiveTime">有效观看时长阈值（秒） / Effective watch duration threshold in seconds</param>
        /// <param name="duration">视频总时长（秒） / Total video duration in seconds</param>
        [Preserve]
        public void OnVideoClose(int watchedTime, int effectiveTime, int duration)
        {
            ShowResult?.Invoke(watchedTime >= effectiveTime);
            ShowResult = null;
        }

        /// <summary>
        /// 设置广告加载的成功和失败回调。
        /// </summary>
        /// <remarks>
        /// Sets the success and failure callbacks for ad loading.
        /// </remarks>
        /// <param name="success">加载成功回调 / Load success callback</param>
        /// <param name="fail">加载失败回调，参数为错误信息 / Load failure callback, parameter is the error message</param>
        [Preserve]
        public void SetLoadCallback(Action<string> success, Action<string> fail)
        {
            loadSuccess = success;
            loadFail = fail;
        }

        /// <summary>
        /// 设置广告展示的成功和失败回调。
        /// </summary>
        /// <remarks>
        /// Sets the success and failure callbacks for ad display.
        /// </remarks>
        /// <param name="success">展示成功回调 / Show success callback</param>
        /// <param name="fail">展示失败回调，参数为错误信息 / Show failure callback, parameter is the error message</param>
        [Preserve]
        public void SetShowCallback(Action<string> success, Action<string> fail)
        {
            showSuccess = success;
            showFail = fail;
        }
    }
}
#endif