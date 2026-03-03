#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT
using System;
using StarkSDKSpace;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    [Preserve]
    internal class DouYinVideoAdCallback : StarkAdManager.VideoAdCallback
    {
        private Action<string> loadSuccess;
        private Action<string> loadFail;
        private Action<string> showSuccess;
        private Action<string> showFail;
        [Preserve] public Action<bool> ShowResult { get; set; }

        [Preserve]
        public void OnVideoLoaded()
        {
            loadSuccess?.Invoke(null);
        }

        [Preserve]
        public void OnVideoShow(long timestamp)
        {
            showSuccess?.Invoke(timestamp.ToString());
        }

        [Preserve]
        public void OnError(int errCode, string errorMessage)
        {
            loadFail?.Invoke(errorMessage);
            showFail?.Invoke(errorMessage);
        }

        [Preserve]
        public void OnVideoClose(int watchedTime, int effectiveTime, int duration)
        {
            ShowResult?.Invoke(watchedTime >= effectiveTime);
            ShowResult = null;
        }

        [Preserve]
        public void SetLoadCallback(Action<string> success, Action<string> fail)
        {
            loadSuccess = success;
            loadFail = fail;
        }

        [Preserve]
        public void SetShowCallback(Action<string> success, Action<string> fail)
        {
            showSuccess = success;
            showFail = fail;
        }
    }
}
#endif