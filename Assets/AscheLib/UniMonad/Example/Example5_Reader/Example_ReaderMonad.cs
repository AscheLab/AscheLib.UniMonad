using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_ReaderMonad : MonoBehaviour {
	// ReaderMonad usage example 1 : Generate ReaderMonad to convert DateTime generated from different environment to the same format string
	public void Example1() {
		var getDateString = from date in Reader.Ask<DateTime>()
							select date.ToString("yyyy/MM/dd HH:mm:ss");

		getDateString.Execute(
			new DateTime(2000, 1, 1, 10, 20, 30),
			value => Debug.Log(value));
		getDateString.Execute(
			DateTime.UtcNow,
			value => Debug.Log(value));
	}

	private void OnGUI() {
		if(GUILayout.Button("ReaderMonad usage example 1")) {
			Example1();
		}
	}
}