#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT

using System;
using GameFrameX.Advertisement.Runtime;
using StarkSDKSpace;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    public class DouYinMiniGameAdvertisementManager : BaseAdvertisementManager
    {
        private StarkAdManager _adManager;
        private string _adUnitId;
        private DouYinVideoAdCallback _douYinVideoAdCallback;

        public override void Initialize(string adUnitId)
        {
            GameFrameworkGuard.NotNullOrEmpty(adUnitId, nameof(adUnitId));
            _adUnitId = adUnitId;
            _adManager = StarkSDK.API.GetStarkAdManager();
            _douYinVideoAdCallback = new DouYinVideoAdCallback();
            _adManager.SetVideoAdCallBack(_douYinVideoAdCallback);
        }

        void OnCloseCallback(bool isComplete)
        {
            _douYinVideoAdCallback.ShowResult?.Invoke(isComplete);
            _douYinVideoAdCallback.ShowResult = null;
        }

        public override void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult)
        {
            OnShowResult = onShowResult;
            _douYinVideoAdCallback.SetShowCallback(success, fail);
            _douYinVideoAdCallback.ShowResult = onShowResult;
            _adManager.ShowVideoAdWithId(_adUnitId, OnCloseCallback, (errorCode, errorMsg) => { fail?.Invoke(errorMsg); });
        }


        public override void Load(Action<string> success, Action<string> fail)
        {
            _douYinVideoAdCallback.SetLoadCallback(success, fail);
        }
    }
}
#endif