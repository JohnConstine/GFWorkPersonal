using System;
using GameFramework.DataTable;
using GameFramework.Resource;
using StarForce;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using GameEntry = StarForce.GameEntry;

namespace SG1
{
    [RequireComponent(typeof(Image))]
    [DisallowMultipleComponent]
    public class ImageIndexBinding : TextLoadAssetBinding
    {
        [SerializeField, InspectorReadOnly] private Image m_Image;

        protected override void ApplyNewValue(string value)
        {
            if (value == "")
            {
                return;
            }
            
            GameEntry.Resource.LoadAsset(value, typeof(Sprite),
                Constant.AssetPriority.ArmorAsset, LoadAssetCallbacks, this);
            m_Image.enabled = false;
        }

        protected override void OnEditorValue()
        {
            base.OnEditorValue();
            if (m_Image == null)
            {
                m_Image = GetComponent<Image>();
            }
        }

        protected override void OnLoadAssetSuccess(string assetname, object asset, float duration, object userdata)
        {
            if (!ReferenceEquals(this, userdata))
            {
                return;
            }

            if (asset == null)
            {
                Log.Error("Asset is invalid.");
                return;
            }

            m_Image.sprite = (Sprite) asset;
            m_Image.enabled = true;
        }

        protected override void OnLoadAssetFailure(string assetname, LoadResourceStatus status, string errormessage, object userdata)
        {
            base.OnLoadAssetFailure(assetname, status, errormessage, userdata);
            Log.Info(errormessage);
        }
    }
}