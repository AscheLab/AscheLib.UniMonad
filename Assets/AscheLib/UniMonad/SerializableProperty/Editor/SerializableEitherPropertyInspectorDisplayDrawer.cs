using UnityEngine;
using UnityEditor;

namespace AscheLib.UniMonad {
	using Utility = SerializablePropertyInspectorDisplayDrawerUtility;

	[CustomPropertyDrawer (typeof(DrawableSerializableEitherBase), true)]
	public class SerializableEitherPropertyInspectorDisplayDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			label = EditorGUI.BeginProperty(position, label, property);
			var leftProperty = property.FindPropertyRelative("_left");
			var rightProperty = property.FindPropertyRelative("_right");
			var isRightProperty = property.FindPropertyRelative("_isRight");
			Utility.DrawToggleHeader(property, isRightProperty, position, label, GetPropertyHeight(property, label));
			if (isRightProperty.boolValue) {
				Utility.DrawValueProperty(rightProperty, position);
			}
			else {
				Utility.DrawValueProperty(leftProperty, position);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if(property.FindPropertyRelative("_isRight").boolValue) {
				var rightHeight = Utility.GetObjectPropertyHeight(property.FindPropertyRelative("_right"), label);
				return Utility.HeaderHeight + rightHeight + EditorGUIUtility.standardVerticalSpacing;
			}
			else {
				var leftHeight = Utility.GetObjectPropertyHeight(property.FindPropertyRelative("_left"), label);
				return Utility.HeaderHeight + leftHeight + EditorGUIUtility.standardVerticalSpacing;
			}
		}
	}
}