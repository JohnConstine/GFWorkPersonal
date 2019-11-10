using GameFramework;
using GameFramework.Resource;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using GameEntry = StarForce.GameEntry;

namespace SG1
{
    public class ImageSetSizeBinding : UGUIImageBinding
    {
        protected override void ApplyNewValue(string newValue)
        {
            if (!string.IsNullOrEmpty(newValue))
            {
                GameEntry.Resource.LoadAsset(newValue, typeof(Sprite), LoadAssetCallbacks);
            }
        }

        protected override void OnLoadAssetSuccess(string assetname, object asset, float duration, object userdata)
        {
            Sprite sprite = asset as Sprite;
            if (sprite != null && Image != null)
            {
                Image.sprite = sprite;
                Image.SetNativeSize();
            }
        }
    }
}