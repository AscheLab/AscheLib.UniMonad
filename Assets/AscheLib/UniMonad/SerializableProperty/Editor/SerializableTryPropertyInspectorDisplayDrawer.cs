using UnityEngine;
using UnityEditor;

namespace AscheLib.UniMonad {
	using Utility = SerializablePropertyInspectorDisplayDrawerUtility;

	[CustomPropertyDrawer (typeof(DrawableSerializableTryBase), true)]
	public class SerializableTryPropertyInspectorDisplayDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			label = EditorGUI.BeginProperty(position, label, property);
			var isSucceededProperty = property.FindPropertyRelative("_isSucceeded");
			var succeededValueProperty = property.FindPropertyRelative("_succeededValue");
			var faultedMessageProperty = property.FindPropertyRelative("_faultedMessage");
			Utility.DrawToggleHeader(property, isSucceededProperty, position, label, GetPropertyHeight(property, label));
			if (isSucceededProperty.boolValue) {
				Utility.DrawValueProperty(succeededValueProperty, position);
			}
			else {
				var faultedMessageRect = new Rect(position.x + 13, position.y + Utility.HeaderHeight, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, EditorGUIUtility.singleLineHeight);
				EditorGUI.PropertyField(faultedMessageRect, faultedMessageProperty, true);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			if(property.FindPropertyRelative("_isSucceeded").boolValue) {
				var valueHeight = Utility.GetObjectPropertyHeight(property.FindPropertyRelative("_succeededValue"), label);
				return Utility.HeaderHeight + valueHeight + EditorGUIUtility.standardVerticalSpacing;
			}
			else {
				var noneHeight = EditorGUIUtility.singleLineHeight;
				return Utility.HeaderHeight + noneHeight + EditorGUIUtility.standardVerticalSpacing;
			}
		}
	}
}