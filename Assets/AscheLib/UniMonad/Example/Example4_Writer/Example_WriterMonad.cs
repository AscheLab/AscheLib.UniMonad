using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_WriterMonad : MonoBehaviour {
	// WriterMonad usage example 1 : Perform calculations while keeping the log in WriterMonad, and display the log
	public void Example1() {
		var writer = from num1 in Writer.Tell(2, "num1 = 2")
					 from num2 in Writer.Tell(5, "num2 = 5")
					 from num3 in Writer.Tell(10, "num3 = 10")
					 from result in Writer.Return<string, int>(num1 * num2 + num3)
					 from resultLog in Writer.Tell(string.Format("num1 * num2 + num3 = {0}", result))
					 select result;
		writer.Execute(
			value => Debug.Log(value),
			outPut => {
				foreach(var log in outPut) {
					Debug.Log(string.Format("Log[{0}]", log));
				}
			});
	}

	private void OnGUI() {
		if(GUILayout.Button("WriterMonad usage example 1")) {
			Example1();
		}
	}
}