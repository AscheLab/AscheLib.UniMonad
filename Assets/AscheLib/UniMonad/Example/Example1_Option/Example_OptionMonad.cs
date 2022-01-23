using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_OptionMonad : MonoBehaviour {
	// Generate OptionMonad to get value from Dictionary
	IOptionMonad<TValue> OptionValue<TKey, TValue>(Dictionary<TKey, TValue> source, TKey key) {
		if(source.ContainsKey(key))
			return Option.Return(source[key]);
		else
			return Option.None<TValue>();
	}

	// OptionMonad usage example 1 : Get the value of the key from Dictionary
	public void Example1() {
		Dictionary<string, string> param = new Dictionary<string, string>() {
			{"param1", "value1"},
			{"param2", "value2"},
			{"param3", "value3"},
		};
		//success
		OptionValue(param, "param1")
			.Execute(
				value => Debug.Log(value),
				() => Debug.Log("param1 key does not exist in dictionary"));
		// If you want to execute only when successful, write like this
		//OptionValue(param, "param1").Execute(value => Debug.Log(value));

		//failed
		OptionValue(param, "param4")
			.Execute(
				value => Debug.Log(value),
				() => Debug.Log("param4 key does not exist in dictionary"));
	}

	// OptionMonad usage example 2 : Works only when multiple OptionMonad are all successful
	public void Example2() {
		Dictionary<string, string> param = new Dictionary<string, string>() {
			{"param1", "value1"},
			{"param2", "value2"},
			{"param3", "value3"},
		};
		//success
		var composedOption1 = from p1 in OptionValue(param, "param1")
							  from p2 in OptionValue(param, "param2")
							  from p3 in OptionValue(param, "param3")
							  select p1 + " " + p2 + " " + p3;
		composedOption1
			.Execute(
				value => Debug.Log(value),
				() => Debug.Log("composedOption1 is None"));
		// If you want to execute only when successful, write like this
		//composedOption1.Execute(value => Debug.Log(value));

		//failed
		var composedOption2 = from p1 in OptionValue(param, "param1")
							  from p2 in OptionValue(param, "param2")
							  from p4 in OptionValue(param, "param4")   //param4 key does not exist in dictionary
							  select p1 + " " + p2 + " " + p4;
		composedOption2
			.Execute(
				value => Debug.Log(value),
				() => Debug.Log("composedOption2 is None"));
	}

	private void OnGUI() {
		if(GUILayout.Button("OptionMonad usage example 1")) {
			Example1();
		}
		if(GUILayout.Button("OptionMonad usage example 2")) {
			Example2();
		}
	}
}