using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class ReturnCore<TState, TValue> : IStateMonad<TState, TValue> {
			TValue _value;
			public ReturnCore(TValue value) {
				_value = value;
			}
			public StateResult<TState, TValue> RunState(TState state) {
				return new StateResult<TState, TValue>(state, _value);
			}
		}
		public static IStateMonad<TState, TValue> Return<TState, TValue>(TValue value = default(TValue)) {
			return new ReturnCore<TState, TValue>(value);
		}
	}
}