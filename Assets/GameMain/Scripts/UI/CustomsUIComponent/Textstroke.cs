using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SG1
{
    [AddComponentMenu("UI/Textstroke", 112)]
    public class Textstroke : Text
    {
        [SerializeField] private Color m_OutlineEffectColor = new Color(0f, 0f, 0f, 0.5f);

        [SerializeField] private Vector2 m_OutlineEffectDistance = new Vector2(1f, -1f);

        [SerializeField] private bool m_OutlineUseGraphicAlpha = true;

        [SerializeField] private Color m_ShadowEffectColor = new Color(0f, 0f, 0f, 0.5f);

        [SerializeField] private Vector2 m_ShadowEffectDistance = new Vector2(1f, -1f);

        [SerializeField] private bool m_ShadowUseGraphicAlpha = true;


        public Color OutlineEffectColor
        {
            get { return m_OutlineEffectColor; }
            set
            {
                m_OutlineEffectColor = value;
                SetAllDirty();
            }
        }

        public Color ShadowEffectColor
        {
            get { return m_ShadowEffectColor; }
            set
            {
                m_ShadowEffectColor = value;
                SetAllDirty();
            }
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            base.OnPopulateMesh(toFill);
            ModifyMesh(toFill);
        }
        /// <summary>
        /// 绘制单个Shadow
        /// </summary>
        /// <param name="verts"></param>
        /// <param name="color"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="useGraphicAlpha"></param>
        protected void ApplyShadowZeroAlloc(List<UIVertex> verts, Color32 color, int start, int end, float x, float y,
            bool useGraphicAlpha)
        {
            UIVertex vt;

            var neededCapacity = verts.Count + end - start;
            if (verts.Capacity < neededCapacity)
                verts.Capacity = neededCapacity;

            for (int i = start; i < end; ++i)
            {
                vt = verts[i];
                verts.Add(vt);

                Vector3 v = vt.position;
                v.x += x;
                v.y += y;
                vt.position = v;
                var newColor = color;
                if (useGraphicAlpha)
                    newColor.a = (byte) ((newColor.a * verts[i].color.a) / 255);
                vt.color = newColor;
                verts[i] = vt;
            }
        }

        /// <summary>
        /// 绘制Shadow
        /// </summary>
        /// <param name="vh"></param>
        private void ModifyMesh(VertexHelper vh)
        {
            if (!IsActive())
                return;
            
            var output = UIEffectListPool<UIVertex>.Get();
            vh.GetUIVertexStream(output);

            int len = output.Count;

            var neededCpacity = output.Count * 6;
            if (output.Capacity < neededCpacity)
                output.Capacity = neededCpacity;

//			Shadow

            ApplyShadowZeroAlloc(output, m_ShadowEffectColor, 0, output.Count, m_ShadowEffectDistance.x,
                m_ShadowEffectDistance.y, m_ShadowUseGraphicAlpha);

//			Outline

            var start = len;
            var end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, m_OutlineEffectDistance.x,
                m_OutlineEffectDistance.y, m_OutlineUseGraphicAlpha);

            start = end;
            end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, m_OutlineEffectDistance.x,
                -m_OutlineEffectDistance.y, m_OutlineUseGraphicAlpha);

            start = end;
            end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, -m_OutlineEffectDistance.x,
                m_OutlineEffectDistance.y, m_OutlineUseGraphicAlpha);

            start = end;
            end = output.Count;
            ApplyShadowZeroAlloc(output, m_OutlineEffectColor, start, output.Count, -m_OutlineEffectDistance.x,
                -m_OutlineEffectDistance.y, m_OutlineUseGraphicAlpha);

            vh.Clear();
            vh.AddUIVertexTriangleStream(output);
            UIEffectListPool<UIVertex>.Release(output);
        }
    }
}