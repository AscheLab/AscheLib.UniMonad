using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_IOMonad : MonoBehaviour {
	// IOMonad usage example 1 : Generate IOMonad to convert DateTime generated from current UTC time to string.
	public void Example1() {
		var getDateString = from date in IO.Create(() => DateTime.UtcNow)
							select date.ToString("yyyy/MM/dd HH:mm:ss");
		getDateString.Execute(value => Debug.Log(value));
	}

	private void OnGUI() {
		if(GUILayout.Button("IOMonad usage example 1")) {
			Example1();
		}
	}
}