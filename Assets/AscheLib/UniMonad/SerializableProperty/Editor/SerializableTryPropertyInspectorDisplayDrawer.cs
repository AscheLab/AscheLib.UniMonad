using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AscheLib;
using UnityEditor;

namespace AscheLib.UniMonad {
	[CustomPropertyDrawer (typeof(DrawableSerializableTryBase), true)]
	public class SerializableTryPropertyInspectorDisplayDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			label = EditorGUI.BeginProperty(position, label, property);
			SerializedProperty isSucceededProperty = property.FindPropertyRelative("_isSucceeded");
			SerializedProperty succeededValueProperty = property.FindPropertyRelative("_succeededValue");
			SerializedProperty faultedMessageProperty = property.FindPropertyRelative("_faultedMessage");
			Rect headerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
			Rect toggleRect = new Rect(position.x + 1.4f, position.y + 1.4f, EditorGUIUtility.singleLineHeight - 1.4f, EditorGUIUtility.singleLineHeight - 1.4f);
			Rect backgroundRect = new Rect(position.x, position.y, position.width, GetPropertyHeight(property, label));
			GUI.Box(backgroundRect, GUIContent.none, new GUIStyle("ShurikenEffectBg"));
			GUI.Box(headerRect, label, new GUIStyle("ShurikenModuleTitle"));
			isSucceededProperty.boolValue = GUI.Toggle(toggleRect, isSucceededProperty.boolValue, GUIContent.none, new GUIStyle("ShurikenCheckMark"));
			GUI.Label(headerRect, string.Format("Try<{0}>", succeededValueProperty.type), new GUIStyle("RightLabel"));
			if(isSucceededProperty.boolValue) {
				Rect valueRect = new Rect(position.x + 13, position.y + headerRect.height, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, position.height - headerRect.height);
				EditorGUI.PropertyField(valueRect, succeededValueProperty, true);
			}
			else {
				Rect faultedMessageRect = new Rect(position.x + 13, position.y + headerRect.height, position.width - 13 - EditorGUIUtility.standardVerticalSpacing, EditorGUIUtility.singleLineHeight);
				EditorGUI.PropertyField(faultedMessageRect, faultedMessageProperty, true);
			}
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			var headerHeight = EditorGUIUtility.singleLineHeight;
			if(property.FindPropertyRelative("_isSucceeded").boolValue) {
				var valueHeight = EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_succeededValue"), label);
				return headerHeight + valueHeight + EditorGUIUtility.standardVerticalSpacing;
			}
			else {
				var noneHeight = EditorGUIUtility.singleLineHeight;
				return headerHeight + noneHeight + EditorGUIUtility.standardVerticalSpacing;
			}
		}
	}
}