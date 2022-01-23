using UnityEngine;
using System;
using System.Collections;
using AscheLib.UniMonad;

public class Example_SerializableProperty : MonoBehaviour {
	// ReadOnly class displayed in Inspector
	[Serializable]
	public class Human {
		[SerializeField]
		public string _name;
		[SerializeField]
		public string _job;
		[SerializeField]
		public int _age;

		public Human(string name, string job, int age) {
			_name = name;
			_job = job;
			_age = age;
		}
	}

#if UNITY_2020_1_OR_NEWER
	// Display IOptionMonad<Human> on Inspector
	[SerializeField]
	SerializableOptionProperty<Human> _optionTest = new SerializableOptionProperty<Human>(new Human("John", "programmer", 24), true);

	// Display IEitherMonad<string, Vector3> on Inspector
	[SerializeField]
	SerializableEitherProperty<string, Vector3> _eitherTest = new SerializableEitherProperty<string, Vector3>("this is left", new Vector3(), true);

	// Display ITryMonad<Human> on Inspector
	[SerializeField]
	SerializableTryProperty<Human> _tryTest = new SerializableTryProperty<Human>(new Human("John", "programmer", 24), "Nothing data", true);
#else
	// Prepare Inspector viewable OptionManad class for Human class
	[Serializable]
	public class HumanSerializableOptionProperty : SerializableOptionPropertyBase<Human> {
		public HumanSerializableOptionProperty(Human value, bool isNone) : base (value, isNone) {}
	}

	// Prepare Inspector viewable TryManad class for Human class
	[Serializable]
	public class HumanSerializableTryProperty : SerializableTryPropertyBase<Human> {
		public HumanSerializableTryProperty(Human succeededValue, string faultedMessage, bool isNone) : base (succeededValue, faultedMessage, isNone ) {}
	}

	// Display IOptionMonad<Human> on Inspector
	[SerializeField]
	HumanSerializableOptionProperty _optionTest = new HumanSerializableOptionProperty(new Human("John", "programmer", 24), true);

	// Display IEitherMonad<string, Vector3> on Inspector
	[SerializeField]
	LeftStringRightVector3SerializableEitherProperty _eitherTest = new LeftStringRightVector3SerializableEitherProperty("this is left", new Vector3(), true);

	// Display ITryMonad<Human> on Inspector
	[SerializeField]
	HumanSerializableTryProperty _tryTest = new HumanSerializableTryProperty(new Human("John", "programmer", 24), "Nothing data", true);
#endif
	// SerializableProperty usage example 1 : Edit the value in Inspector which doesn't know if it exists or not and use it as OptionMonad
	public void Example1 () {
		_optionTest.Execute(v => Debug.Log(string.Format("I'm {0}, {1} years old {2}.", v._name, v._age, v._job)));
	}

	// SerializableProperty usage example 2 : Edit the value in Inspector that you do not know whether it is correct and use it as EitherMonad. Vector3 if correct, string if not correct
	public void Example2 () {
		_eitherTest.Execute(
			r => Debug.Log(string.Format("Right:{0}", r)),
			l => Debug.Log(string.Format("Left:{0}", l)));
	}

	// SerializableProperty usage example 3 : Edit the value in Inspector which is unknown whether it exists or not and use it as TryMonad. Exception error messages can be edited in the Inspector
	public void Example3 () {
		_tryTest.Execute(v => Debug.Log(string.Format("I'm {0}, {1} years old {2}.", v._name, v._age, v._job)));
	}

	private void OnGUI () {
		if(GUILayout.Button("SerializableProperty usage example 1")) {
			Example1();
		}
		if(GUILayout.Button("SerializableProperty usage example 2")) {
			Example2();
		}
		if(GUILayout.Button("SerializableProperty usage example 3")) {
			Example3();
		}
	}
}