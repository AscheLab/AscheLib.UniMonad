using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_EitherMonad : MonoBehaviour {
	// Generate EitherMonad to get value from Dictionary
	IEitherMonad<Exception, TValue> EitherValue<TKey, TValue>(Dictionary<TKey, TValue> source, TKey key) {
		if(source.ContainsKey(key))
			return Either.ReturnRight<Exception, TValue>(source[key]);
		else
			return Either.ReturnLeft<Exception, TValue>(new Exception(key.ToString() + " key does not exist in dictionary"));
	}

	// EitherMonad usage example 1 : Get the value of the key from Dictionary
	public void Example1() {
		Dictionary<string, string> param = new Dictionary<string, string>() {
			{"param1", "value1"},
			{"param2", "value2"},
			{"param3", "value3"},
		};
		//success
		EitherValue(param, "param1")
			.Execute(
				right => Debug.Log(right),
				left => Debug.LogException(left));
		// If you want to execute only when successful, write like this
		//EitherValue(param, "param1").Execute(right => Debug.Log(right));

		//failed
		EitherValue(param, "param4")
			.Execute(
				right => Debug.Log(right),
				left => Debug.LogException(left));
	}

	// EitherMonad usage example 2 : Works only when multiple OptionMonad are all successful
	public void Example2() {
		Dictionary<string, string> param = new Dictionary<string, string>() {
			{"param1", "value1"},
			{"param2", "value2"},
			{"param3", "value3"},
		};
		//success
		var composedEither1 = from p1 in EitherValue(param, "param1")
							  from p2 in EitherValue(param, "param2")
							  from p3 in EitherValue(param, "param3")
							  select p1 + " " + p2 + " " + p3;
		composedEither1
			.Execute(
				right => Debug.Log(right),
				left => Debug.LogException(left));
		// If you want to execute only when successful, write like this
		//composedEither1.Execute(right => Debug.Log(right));

		//failed
		var composedEither2 = from p1 in EitherValue(param, "param1")
							  from p2 in EitherValue(param, "param2")
							  from p4 in EitherValue(param, "param4")   //param4 key does not exist in dictionary
							  select p1 + " " + p2 + " " + p4;
		composedEither2
			.Execute(
				right => Debug.Log(right),
				left => Debug.LogException(left));
	}

	private void OnGUI() {
		if(GUILayout.Button("EitherMonad usage example 1")) {
			Example1();
		}
		if(GUILayout.Button("EitherMonad usage example 2")) {
			Example2();
		}
	}
}