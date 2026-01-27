#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT

using System;
using GameFrameX.Advertisement.Runtime;
using GameFrameX.Runtime;
using StarkSDKSpace;
using TTSDK;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    public class DouYinMiniGameAdvertisementManager : BaseAdvertisementManager
    {
        private TTRewardedVideoAd _adManager;
        private string _adUnitId;
        private DouYinVideoAdCallback _douYinVideoAdCallback;

        public override void Initialize(string adUnitId, bool debug = false)
        {
            GameFrameworkGuard.NotNullOrEmpty(adUnitId, nameof(adUnitId));
            _adUnitId = adUnitId;
            _douYinVideoAdCallback = new DouYinVideoAdCallback();
        }

        void OnCloseCallback(bool isComplete, int count)
        {
            _douYinVideoAdCallback.ShowResult?.Invoke(isComplete);
            _douYinVideoAdCallback.ShowResult = null;
            _adManager.Destroy();
            _adManager = null;
        }

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

        public override void Show(Action<string> success, Action<string> fail, Action<bool> onShowResult, string customData = null)
        {
            OnShowResult = onShowResult;
            _douYinVideoAdCallback.SetShowCallback(success, fail);
            _douYinVideoAdCallback.ShowResult = onShowResult;
            _adManager.OnClose += OnCloseCallback;
            _adManager.Show();
        }

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