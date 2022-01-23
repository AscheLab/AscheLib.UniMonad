using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class DoOnStateCore<TState, TValue> : IStateMonad<TState, TValue> {
			IStateMonad<TState, TValue> _self;
			Action<TState> _action;
			public DoOnStateCore(IStateMonad<TState, TValue> self, Action<TState> action) {
				_self = self;
				_action = action;
			}
			public StateResult<TState, TValue> Run(TState state) {
				StateResult<TState, TValue> result = _self.Run(state);
				_action(result.State);
				return result;
			}
		}
		public static IStateMonad<TState, TValue> DoOnState<TState, TValue>(this IStateMonad<TState, TValue> self, Action<TState> action) {
			return new DoOnStateCore<TState, TValue>(self, action);
		}
	}
}