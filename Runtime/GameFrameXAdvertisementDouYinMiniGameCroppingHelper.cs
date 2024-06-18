using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.Advertisement.DouYinMiniGame.Runtime
{
    [Preserve]
    public class GameFrameXAdvertisementDouYinMiniGameCroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
#if UNITY_WEBGL && ENABLE_DOUYIN_MINI_GAME && ENABLE_DOUYIN_MINI_GAME_ADVERTISEMENT
            _ = typeof(DouYinMiniGameAdvertisementManager);
#endif
        }
    }
}