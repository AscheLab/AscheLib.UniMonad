using UnityEngine;
using UnityEditor;

namespace AscheLib.UniMonad {
	internal static class SerializablePropertyInspectorDisplayDrawerUtility {
		public static float HeaderHeight = EditorGUIUtility.singleLineHeight;

		public static void DrawToggleHeader(SerializedProperty property, SerializedProperty toggleProperty, Rect position, GUIContent label, float propertyHeight) {
			var headerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			var toggleRect = new Rect(position.x + 1.4f, position.y + 1.4f, EditorGUIUtility.singleLineHeight - 1.4f, EditorGUIUtility.singleLineHeight - 1.4f);
			var backgroundRect = new Rect(position.x, position.y, position.width, propertyHeight);
			GUI.Box(backgroundRect, GUIContent.none, new GUIStyle("ShurikenEffectBg"));
			GUI.Box(headerRect, label, new GUIStyle("ShurikenModuleTitle"));
			toggleProperty.boolValue = GUI.Toggle(toggleRect, toggleProperty.boolValue, GUIContent.none, new GUIStyle("ShurikenCheckMark"));
		}

		public static void DrawValueProperty (SerializedProperty valueProperty, Rect position) {
			var valueRect = new Rect(position.x + 13, position.y + HeaderHeight, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, position.height - HeaderHeight);
			EditorGUI.PropertyField(valueRect, valueProperty, true);
		}

		public static float GetObjectPropertyHeight (SerializedProperty objectProperty, GUIContent label) {
			var height = EditorGUI.GetPropertyHeight(objectProperty, label, true);
			return height;
		}
	}
}