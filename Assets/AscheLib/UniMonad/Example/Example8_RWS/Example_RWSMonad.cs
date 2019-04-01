using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_RWSMonad : MonoBehaviour {
	// ReadOnly class that holds the number of calls
	public class SampleState {
		public int Count { private set; get; }
		public SampleState(int count) {
			Count = count;
		}
	}

	// Prepare a state that has never been called
	SampleState defaultState = new SampleState(0);

	// RWSMonad usage example 1 : Realize the contents performed in each Example 1 of WriterMonad, ReaderMonad, and StateMonad with one RWSMonad
	public void Example1() {
		var checkCount = from currentState in RWS.Get<DateTime, string, SampleState>()
						 from date in RWS.Ask<DateTime, string, SampleState>()
						 from _ in RWS.Tell<DateTime, string, SampleState>(date.ToString("yyyy/MM/dd HH:mm:ss"))
						 from greeting in RWS.Tell<DateTime, string, SampleState, string>(currentState.Count == 0 ? "Nice to meet you" : "Hello", string.Format("currentState.Count = {0}", currentState.Count))
						 from comment in RWS.Return<DateTime, string, SampleState, string>(greeting + ", Monad world!")
						 from __ in RWS.Tell<DateTime, string, SampleState>("Add count")
						 from putAddCount in RWS.Put<DateTime, string, SampleState>(new SampleState(currentState.Count + 1))
						 select comment;

		var result1State = checkCount.Execute(
			new DateTime(2000, 1, 1, 10, 20, 30),
			defaultState,
			value => Debug.Log(value),
			outPut => {
				foreach(var log in outPut) {
					Debug.Log(string.Format("Log[{0}]", log));
				}
			});

		var result2State = checkCount.Execute(
			DateTime.UtcNow,
			result1State,
			value => Debug.Log(value),
			outPut => {
				foreach(var log in outPut) {
					Debug.Log(string.Format("Log[{0}]", log));
				}
			});

		Debug.Log(string.Format("It has been called {0} times", result2State.Count));
	}

	private void OnGUI() {
		if(GUILayout.Button("RWSMonad usage example 1")) {
			Example1();
		}
	}
}