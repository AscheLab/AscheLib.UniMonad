using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class DoCore<TState, TValue> : IStateMonad<TState, TValue> {
			IStateMonad<TState, TValue> _self;
			Action<StateResult<TState, TValue>> _action;
			public DoCore(IStateMonad<TState, TValue> self, Action<StateResult<TState, TValue>> action) {
				_self = self;
				_action = action;
			}
			public StateResult<TState, TValue> Run(TState state) {
				StateResult<TState, TValue> result = _self.Run(state);
				_action(result);
				return result;
			}
		}
		public static IStateMonad<TState, TValue> Do<TState, TValue>(this IStateMonad<TState, TValue> self, Action<StateResult<TState, TValue>> action) {
			return new DoCore<TState, TValue>(self, action);
		}
	}
}