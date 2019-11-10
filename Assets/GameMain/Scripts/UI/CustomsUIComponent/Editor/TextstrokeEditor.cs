using UnityEditor;
using UnityEditor.UI;

namespace SG1
{
	[CustomEditor(typeof(Textstroke),true)]
	[CanEditMultipleObjects]
	public class TextstrokeEditor : TextEditor
	{
		private SerializedProperty m_OutlineEffectColor;

		private SerializedProperty m_OutlineEffectDistance ;

		private SerializedProperty m_OutlineUseGraphicAlpha;

		private SerializedProperty m_ShadowEffectColor;

		private SerializedProperty m_ShadowEffectDistance;

		private SerializedProperty m_ShadowUseGraphicAlpha;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_OutlineEffectColor = serializedObject.FindProperty("m_OutlineEffectColor");
			m_OutlineEffectDistance = serializedObject.FindProperty("m_OutlineEffectDistance");
			m_OutlineUseGraphicAlpha = serializedObject.FindProperty("m_OutlineUseGraphicAlpha");
			m_ShadowEffectColor = serializedObject.FindProperty("m_ShadowEffectColor");
			m_ShadowEffectDistance = serializedObject.FindProperty("m_ShadowEffectDistance");
			m_ShadowUseGraphicAlpha = serializedObject.FindProperty("m_ShadowUseGraphicAlpha");
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			EditorGUILayout.Space();
			serializedObject.Update();
			
			EditorGUILayout.PropertyField(m_OutlineEffectColor);
			EditorGUILayout.PropertyField(m_OutlineEffectDistance);
			EditorGUILayout.PropertyField(m_OutlineUseGraphicAlpha);
			EditorGUILayout.PropertyField(m_ShadowEffectColor);
			EditorGUILayout.PropertyField(m_ShadowEffectDistance);
			EditorGUILayout.PropertyField(m_ShadowUseGraphicAlpha);
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}