using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace SG1
{
    [RequireComponent(typeof(Textstroke))]
    [DisallowMultipleComponent]
    public class UGUITextstokeBinding : ColorBinding
    {
        [SerializeField, InspectorReadOnly] private Textstroke m_Text;

        public Textstroke Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        protected override bool Bind()
        {
            if (!base.Bind())
            {
                m_Text.ShadowEffectColor = Color.white;
                m_Text.OutlineEffectColor = Color.white;
            }

            return PropertyFound;
        }

        protected override void ApplyNewValue(Color newValue)
        {
            m_Text.ShadowEffectColor = newValue;
            m_Text.OutlineEffectColor = newValue;
        }

        protected override void OnEditorValue()
        {
            base.OnEditorValue();
            if (m_Text == null)
            {
                m_Text = GetComponent<Textstroke>();
            }
        }
    }
}