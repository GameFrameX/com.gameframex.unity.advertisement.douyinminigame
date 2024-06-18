#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT
using System;
using StarkSDKSpace;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    internal class DouYinVideoAdCallback : StarkAdManager.VideoAdCallback
    {
        private Action<string> loadSuccess;
        private Action<string> loadFail;
        private Action<string> showSuccess;
        private Action<string> showFail;
        public Action<bool> ShowResult { get; set; }

        public void OnVideoLoaded()
        {
            loadSuccess?.Invoke(null);
        }

        public void OnVideoShow(long timestamp)
        {
            showSuccess?.Invoke(timestamp.ToString());
        }

        public void OnError(int errCode, string errorMessage)
        {
            loadFail?.Invoke(errorMessage);
            showFail?.Invoke(errorMessage);
        }

        public void OnVideoClose(int watchedTime, int effectiveTime, int duration)
        {
            ShowResult?.Invoke(watchedTime >= effectiveTime);
            ShowResult = null;
        }

        public void SetLoadCallback(Action<string> success, Action<string> fail)
        {
            loadSuccess = success;
            loadFail = fail;
        }

        public void SetShowCallback(Action<string> success, Action<string> fail)
        {
            showSuccess = success;
            showFail = fail;
        }
    }
}
#endif