using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IStateMonad<TState, TValue> {
		StateResult<TState, TValue> Run(TState state);
	}
	public class StateResult<TState, TValue> {
		public TState State { private set; get; }
		public TValue Value { private set; get; }
		public StateResult(TState state, TValue value) {
			Value = value;
			State = state;
		}
	}
	public static class StateResult {
		public static StateResult<TState, TValue> Create<TState, TValue>(TState state, TValue value) {
			return new StateResult<TState, TValue>(state, value);
		}
	}

	public static partial class State {

	}
}