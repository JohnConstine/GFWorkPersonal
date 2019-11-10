using UnityEditor;
using UnityEditor.UI;

namespace SG1
{
	[CustomEditor(typeof(SliderClick),true)]
	[CanEditMultipleObjects]
	public class SliderClickEditor : SliderEditor
	{
		private SerializedProperty m_SliderColor;
		private SerializedProperty m_Slider;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_SliderColor = serializedObject.FindProperty("m_SliderColor");
			m_Slider = serializedObject.FindProperty("m_Slider");
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			EditorGUILayout.Space();
			serializedObject.Update();
			
			EditorGUILayout.PropertyField(m_SliderColor);
			EditorGUILayout.PropertyField(m_Slider);
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}