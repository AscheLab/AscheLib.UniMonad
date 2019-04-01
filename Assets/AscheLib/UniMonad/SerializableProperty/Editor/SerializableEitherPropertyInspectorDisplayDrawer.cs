using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AscheLib;
using UnityEditor;

namespace AscheLib.UniMonad {
	[CustomPropertyDrawer (typeof(DrawableSerializableEitherBase), true)]
	public class SerializableEitherPropertyInspectorDisplayDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			label = EditorGUI.BeginProperty(position, label, property);
			SerializedProperty leftProperty = property.FindPropertyRelative("_left");
			SerializedProperty rightProperty = property.FindPropertyRelative("_right");
			SerializedProperty isRightProperty = property.FindPropertyRelative("_isRight");
			Rect headerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			Rect toggleRect = new Rect(position.x + 1.4f, position.y + 1.4f, EditorGUIUtility.singleLineHeight - 1.4f, EditorGUIUtility.singleLineHeight - 1.4f);
			Rect backgroundRect = new Rect(position.x, position.y, position.width, GetPropertyHeight(property, label));
			GUI.Box(backgroundRect, GUIContent.none, new GUIStyle("ShurikenEffectBg"));
			GUI.Box(headerRect, label, new GUIStyle("ShurikenModuleTitle"));
			isRightProperty.boolValue = GUI.Toggle(toggleRect, isRightProperty.boolValue, GUIContent.none, new GUIStyle("ShurikenCheckMark"));
			GUI.Label(headerRect, string.Format("Either<{0}, {1}>", leftProperty.type, rightProperty.type), new GUIStyle("RightLabel"));
			Rect valueRect = new Rect(position.x + 13, position.y + headerRect.height, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, position.height - headerRect.height);
			if(isRightProperty.boolValue) {
				EditorGUI.PropertyField(valueRect, rightProperty, true);
			}
			else {
				EditorGUI.PropertyField(valueRect, leftProperty, true);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			var headerHeight = EditorGUIUtility.singleLineHeight;
			if(property.FindPropertyRelative("_isRight").boolValue) {
				var rightHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_right"), label);
				return headerHeight + rightHeight + EditorGUIUtility.standardVerticalSpacing;
			}
			else {
				var leftHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_left"), label);
				return headerHeight + leftHeight + EditorGUIUtility.standardVerticalSpacing;
			}
		}
	}
}