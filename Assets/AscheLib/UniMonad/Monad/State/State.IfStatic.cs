using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class IfStaticCore<TState, TValue> : IStateMonad<TState, TValue> {
			IStateMonad<TState, TValue> _thenSource;
			IStateMonad<TState, TValue> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IStateMonad<TState, TValue> thenSource, IStateMonad<TState, TValue> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public StateResult<TState, TValue> RunState(TState state) {
				if(_selector()) {
					return _thenSource.RunState(state);
				}
				else {
					return _elseSource.RunState(state);
				}
			}
		}
		public static IStateMonad<TState, TValue> If<TState, TValue>(IStateMonad<TState, TValue> thenSource, IStateMonad<TState, TValue> elseSource, Func<bool> selector) {
			return new IfStaticCore<TState, TValue>(thenSource, elseSource, selector);
		}
	}
}