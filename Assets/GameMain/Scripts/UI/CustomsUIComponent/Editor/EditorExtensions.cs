using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace SG1
{
    static class EditorExtensions
    {
        [MenuItem("GameObject/UI/ImageCompletion")]
        static void Completion()
        {
            GameObject go = new GameObject("ImageCompletion");
            go.AddComponent<ImageCompletion>();
            SetTransform(go);
        }

        [MenuItem("GameObject/UI/Textstroke")]
        static void Stroke()
        {
            GameObject go = new GameObject("Textstroke");
            go.AddComponent<Textstroke>();
            SetTransform(go);
        }

        /// <summary>
        /// 设施生成物体位置
        /// </summary>
        /// <param name="go"></param>
        static void SetTransform(GameObject go)
        {
            if (Selection.activeGameObject == null ||
                Selection.activeGameObject.GetComponentsInParent<Canvas>() == null)
            {
                GameObject canvas = GameObject.Find("Game Framework/Builtin/UI/UI Form Instances");
                if (!canvas)
                {
                    canvas = new GameObject("Canvas");
                    canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                    canvas.AddComponent<CanvasScaler>();
                    canvas.AddComponent<CustomGraphicRaycaster>();
                    canvas.transform.SetParent(Selection.activeGameObject.transform);
                }
                go.transform.SetParent(canvas.transform);
            }
            else
            {
                go.transform.SetParent(Selection.activeGameObject.transform);
            }
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            Selection.activeGameObject = go;
        }
    }
}