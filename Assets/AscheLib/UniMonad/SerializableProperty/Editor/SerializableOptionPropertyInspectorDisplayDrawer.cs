using UnityEngine;
using UnityEditor;

namespace AscheLib.UniMonad {
	using Utility = SerializablePropertyInspectorDisplayDrawerUtility;

	[CustomPropertyDrawer (typeof(DrawableSerializableOptionBase), true)]
	public class SerializableOptionPropertyInspectorDisplayDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			label = EditorGUI.BeginProperty(position, label, property);
			var isJustProperty = property.FindPropertyRelative("_isJust");
			var valueProperty = property.FindPropertyRelative("_value");
			Utility.DrawToggleHeader(property, isJustProperty, position, label, GetPropertyHeight(property, label));
			var tempGUIEnabled = GUI.enabled;
			GUI.enabled = isJustProperty.boolValue;
			if(isJustProperty.boolValue) {
				Utility.DrawValueProperty(valueProperty, position);
			}
			else {
				Rect noneRect = new Rect(position.x + 13, position.y + Utility.HeaderHeight, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, EditorGUIUtility.singleLineHeight);
				GUI.Label(noneRect, "(None)");
			}
			GUI.enabled = tempGUIEnabled;
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if(property.FindPropertyRelative("_isJust").boolValue) {
				var valueHeight = Utility.GetObjectPropertyHeight(property.FindPropertyRelative("_value"), label);
				return Utility.HeaderHeight + valueHeight + EditorGUIUtility.standardVerticalSpacing;
			}
			else {
				var noneHeight = EditorGUIUtility.singleLineHeight;
				return Utility.HeaderHeight + noneHeight + EditorGUIUtility.standardVerticalSpacing;
			}
		}
	}
}