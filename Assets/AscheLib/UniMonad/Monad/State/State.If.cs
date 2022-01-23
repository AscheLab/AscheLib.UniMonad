using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class IfCore<TState, TValue> : IStateMonad<TState, TValue> {
			IStateMonad<TState, TValue> _self;
			IStateMonad<TState, TValue> _elseSource;
			Func<StateResult<TState, TValue>, bool> _selector;
			public IfCore(IStateMonad<TState, TValue> self, IStateMonad<TState, TValue> elseSource, Func<StateResult<TState, TValue>, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public StateResult<TState, TValue> Run(TState state) {
				StateResult<TState, TValue> result = _self.Run(state);
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.Run(state);
				}
			}
		}
		public static IStateMonad<TState, TValue> If<TState, TValue>(this IStateMonad<TState, TValue> self, IStateMonad<TState, TValue> elseSource, Func<StateResult<TState, TValue>, bool> selector) {
			return new IfCore<TState, TValue>(self, elseSource, selector);
		}
	}
}