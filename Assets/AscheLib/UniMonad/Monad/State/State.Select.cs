using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class SelectCore<TState, TValue, TResult> : IStateMonad<TState, TResult> {
			IStateMonad<TState, TValue> _self;
			Func<TValue, TResult> _selector;
			public SelectCore(IStateMonad<TState, TValue> self, Func<TValue, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public StateResult<TState, TResult> RunState(TState state) {
				StateResult<TState, TValue> result = _self.RunState(state);
				return StateResult.Create(result.State, _selector(result.Value));
			}
		}
		public static IStateMonad<TState, TResult> Select<TState, TValue, TResult>(this IStateMonad<TState, TValue> self, Func<TValue, TResult> selector) {
			return new SelectCore<TState, TValue, TResult>(self, selector);
		}
	}
}