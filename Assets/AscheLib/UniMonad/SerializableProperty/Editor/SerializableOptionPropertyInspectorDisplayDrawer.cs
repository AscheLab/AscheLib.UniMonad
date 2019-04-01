using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AscheLib;
using UnityEditor;

namespace AscheLib.UniMonad {
	[CustomPropertyDrawer (typeof(DrawableSerializableOptionBase), true)]
	public class SerializableOptionPropertyInspectorDisplayDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			label = EditorGUI.BeginProperty(position, label, property);
			SerializedProperty isJustProperty = property.FindPropertyRelative("_isJust");
			SerializedProperty valueProperty = property.FindPropertyRelative("_value");
			Rect headerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			Rect toggleRect = new Rect(position.x + 1.4f, position.y + 1.4f, EditorGUIUtility.singleLineHeight - 1.4f, EditorGUIUtility.singleLineHeight - 1.4f);
			Rect backgroundRect = new Rect(position.x, position.y, position.width, GetPropertyHeight(property, label));
			GUI.Box(backgroundRect, GUIContent.none, new GUIStyle("ShurikenEffectBg"));
			GUI.Box(headerRect, label, new GUIStyle("ShurikenModuleTitle"));
			isJustProperty.boolValue = GUI.Toggle(toggleRect, isJustProperty.boolValue, GUIContent.none, new GUIStyle("ShurikenCheckMark"));
			GUI.Label(headerRect, string.Format("Option<{0}>", valueProperty.type), new GUIStyle("RightLabel"));
			bool tempGUIEnabled = GUI.enabled;
			GUI.enabled = isJustProperty.boolValue;
			if(isJustProperty.boolValue) {
				Rect valueRect = new Rect(position.x + 13, position.y + headerRect.height, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, position.height - headerRect.height);
				EditorGUI.PropertyField(valueRect, valueProperty, true);
			}
			else {
				Rect noneRect = new Rect(position.x + 13, position.y + headerRect.height, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, EditorGUIUtility.singleLineHeight);
				GUI.Label(noneRect, "(None)");
			}
			GUI.enabled = tempGUIEnabled;
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			var headerHeight = EditorGUIUtility.singleLineHeight;
			if(property.FindPropertyRelative("_isJust").boolValue) {
				var valueHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_value"), label);
				return headerHeight + valueHeight + EditorGUIUtility.standardVerticalSpacing;
			}
			else {
				var noneHeight = EditorGUIUtility.singleLineHeight;
				return headerHeight + noneHeight + EditorGUIUtility.standardVerticalSpacing;
			}
		}
	}
}