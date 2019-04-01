using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AscheLib.UniMonad;

public class Example_StateMonad : MonoBehaviour {
	// ReadOnly class that holds the number of calls
	public class SampleState {
		public int Count { private set; get; }
		public SampleState(int count) {
			Count = count;
		}
	}

	// Prepare a state that has never been called
	SampleState defaultState = new SampleState(0);

	// StateMonad usage example 1 : Generate StateMonad that changes the operation according to the state of the number of calls
	public void Example1() {
		var checkCount = from currentState in State.Get<SampleState>()
						 from greeting in State.Return<SampleState, string>(currentState.Count == 0 ? "Nice to meet you" : "Hello")
						 from comment in State.Return<SampleState, string>(greeting + ", Monad world!" + "\n" + "Count:" + currentState.Count)
						 from putAddCount in State.Put(new SampleState(currentState.Count + 1))
						 select comment;
		var resultState1 = checkCount.Execute(defaultState, value => Debug.Log(value));
		var resultState2 = checkCount.Execute(resultState1, value => Debug.Log(value));
		var resultState3 = checkCount.Execute(resultState2, value => Debug.Log(value));
		Debug.Log(string.Format("It has been called {0} times", resultState3.Count));
	}

	private void OnGUI() {
		if(GUILayout.Button("StateMonad usage example 1")) {
			Example1();
		}
	}
}