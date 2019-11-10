using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

#pragma warning disable 0649
namespace SG1
{
    [RequireComponent(typeof(Textstroke))]
    [DisallowMultipleComponent]
    public class ActiveTextstokeBinding : BooleanBinding
    {
        [SerializeField] private Color m_ActiveColor;
        [SerializeField] private Color m_DeActiveColor;
        [SerializeField, InspectorReadOnly] private Textstroke m_Textstroke;

        protected override void ApplyNewValue(bool newValue)
        {
            m_Textstroke.ShadowEffectColor = newValue ? m_ActiveColor : m_DeActiveColor;
            m_Textstroke.OutlineEffectColor = newValue ? m_ActiveColor : m_DeActiveColor;
        }


        protected override void OnEditorValue()
        {
            base.OnEditorValue();
            if (m_Textstroke == null)
            {
                m_Textstroke = GetComponent<Textstroke>();
            }
        }
    }
}