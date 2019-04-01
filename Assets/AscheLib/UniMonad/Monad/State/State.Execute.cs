using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		public static TState Execute<TState, TValue>(this IStateMonad<TState, TValue> self, TState state) {
			return self.RunState(state).State;
		}
		public static TState Execute<TState, TValue>(this IStateMonad<TState, TValue> self, TState state, Action<TValue> onValue) {
			StateResult<TState, TValue> result = self.RunState(state);
			onValue(result.Value);
			return result.State;
		}
	}
}