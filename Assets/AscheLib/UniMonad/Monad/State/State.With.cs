using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class WithCore<TState, TValue> : IStateMonad<TState, TValue> {
			IStateMonad<TState, TValue> _self;
			Func<TState, TState> _selector;
			public WithCore(IStateMonad<TState, TValue> self, Func<TState, TState> selector) {
				_self = self;
				_selector = selector;
			}
			public StateResult<TState, TValue> RunState(TState state) {
				StateResult<TState, TValue> result = _self.RunState(state);
				return StateResult.Create(_selector(result.State), result.Value);
			}
		}
		public static IStateMonad<TState, TValue> With<TState, TValue>(this IStateMonad<TState, TValue> self, Func<TState, TState> selector) {
			return new WithCore<TState, TValue>(self, selector);
		}
	}
}