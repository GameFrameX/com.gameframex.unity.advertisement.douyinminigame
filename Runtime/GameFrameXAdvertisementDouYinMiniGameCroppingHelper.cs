using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    /// <summary>
    /// 抖音小游戏广告防裁剪辅助类，通过引用关键类型确保 IL2CPP 裁剪时保留必要代码。
    /// </summary>
    /// <remarks>
    /// DouYin Mini Game ad anti-stripping helper, ensuring necessary code is preserved during IL2CPP stripping by referencing key types.
    /// </remarks>
    [Preserve]
    public class GameFrameXAdvertisementDouYinMiniGameCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT
            _ = typeof(DouYinMiniGameAdvertisementManager);
            _ = typeof(DouYinVideoAdCallback);
#endif
        }
    }
}