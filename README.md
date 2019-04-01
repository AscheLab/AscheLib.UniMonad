# AscheLib.UniMonad
Created by Syunta Washidu (AscheLab)

## What's UniMonad?
UniMonad is a library that allows you to use Monad on Unity

## Using for UniMonad
```csharp
using AscheLib.UniMonad;
```

### Example OptionMonad
```csharp
// Generate OptionMonad to get value from Dictionary
IOptionMonad<TValue> OptionValue<TKey, TValue>(Dictionary<TKey, TValue> source, TKey key) {
	if(source.ContainsKey(key))
		return Option.Just(source[key]);
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
```

### Example EitherMonad
```csharp
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
```

### Example TryMonad
```csharp
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
```

### Example WriterMonad
```csharp
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
```

### Example ReaderMonad
```csharp
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
```

### Example IOMonad
```csharp
// IOMonad usage example 1 : Generate IOMonad to convert DateTime generated from current UTC time to string.
public void Example1() {
	var getDateString = from date in IO.Create(() => DateTime.UtcNow)
						select date.ToString("yyyy/MM/dd HH:mm:ss");
	getDateString.Execute(value => Debug.Log(value));
}
```

### Example StateMonad
```csharp
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
```

### Example RWSMonad
```csharp
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
```


### Example SerializableProperty
```csharp
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
```

## License
This library is under the MIT License.