using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_TryMonad : MonoBehaviour {
	// Generate TryMonad to get value from Dictionary
	public ITryMonad<TValue> TryValue<TKey, TValue>(Dictionary<TKey, TValue> source, TKey key) {
		if(source.ContainsKey(key))
			return Try.Return(source[key]);
		else
			return Try.Throw<TValue>(new Exception(key.ToString() + " key does not exist in dictionary"));
	}

	// TryMonad usage example 1 : Get the value of the key from Dictionary
	public void Example1() {
		Dictionary<string, string> param = new Dictionary<string, string>() {
			{"x", "100"},
			{"y", "200"},
		};
		//success
		TryValue(param, "x")
			.Select(v => int.Parse(v))
			.Execute(
				value => Debug.Log(value),
				ex => Debug.LogException(ex));
		// If you want to execute only when successful, write like this
		//TryValue(param, "x").Select(v => int.Parse(v)).Execute(value => Debug.Log(value));

		//failed
		TryValue(param, "z")
			.Select(v => int.Parse(v))
			.Execute(
				value => Debug.Log(value),
				ex => Debug.LogException(ex));
	}

	// TryMonad usage example 2 : Works only when multiple OptionMonad are all successful
	public void Example2() {
		Dictionary<string, string> param = new Dictionary<string, string>() {
			{"x", "100"},
			{"y", "200"},
		};
		//success
		var try1 = from x in TryValue(param, "x").Select(v => int.Parse(v))
				   from y in TryValue(param, "y").Select(v => int.Parse(v))
				   select new Vector2(x, y);
		try1.Execute(
			value => Debug.Log(value),
			ex => Debug.LogException(ex));
		// If you want to execute only when successful, write like this
		//try1.Execute(value => Debug.Log(value));

		//failed
		var try2 = from x in TryValue(param, "x").Select(v => int.Parse(v))
				   from y in TryValue(param, "y").Select(v => int.Parse(v))
				   from z in TryValue(param, "z").Select(v => int.Parse(v))         //z key does not exist in dictionary
				   select new Vector3(x, y, z);
		try2.Execute(
			value => Debug.Log(value),
			ex => Debug.LogException(ex));
	}

	private void OnGUI() {
		if(GUILayout.Button("TryMonad usage example 1")) {
			Example1();
		}
		if(GUILayout.Button("TryMonad usage example 2")) {
			Example2();
		}
	}
}