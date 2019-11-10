using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace SG1
{
    [Serializable]
    public class SliderClick : Slider
    {
        [SerializeField] private Color m_SliderColor;
        [SerializeField] private Image m_Slider;

        private Color m_Color;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (m_Slider == null)
            {
                return;
            }

            m_Color = m_Slider.color;
            m_Slider.color = m_SliderColor;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            if (m_Slider == null)
            {
                return;
            }

            m_Slider.color = m_Color;
        }
    }
}