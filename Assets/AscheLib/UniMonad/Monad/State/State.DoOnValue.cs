using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class DoOnValueCore<TState, TValue> : IStateMonad<TState, TValue> {
			IStateMonad<TState, TValue> _self;
			Action<TValue> _action;
			public DoOnValueCore(IStateMonad<TState, TValue> self, Action<TValue> action) {
				_self = self;
				_action = action;
			}
			public StateResult<TState, TValue> RunState(TState state) {
				StateResult<TState, TValue> result = _self.RunState(state);
				_action(result.Value);
				return result;
			}
		}
		public static IStateMonad<TState, TValue> DoOnValue<TState, TValue>(this IStateMonad<TState, TValue> self, Action<TValue> action) {
			return new DoOnValueCore<TState, TValue>(self, action);
		}
	}
}