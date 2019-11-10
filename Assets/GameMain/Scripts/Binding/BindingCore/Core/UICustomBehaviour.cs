using UnityEngine.EventSystems;

namespace SG1
{
    public abstract class UICustomBehaviour : UIBehaviour
    {
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            OnEditorValue();
        }

        protected override void Reset()
        {
            OnValidate();
        }
#endif

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        protected virtual void OnEditorValue()
        {
        }
    }
}