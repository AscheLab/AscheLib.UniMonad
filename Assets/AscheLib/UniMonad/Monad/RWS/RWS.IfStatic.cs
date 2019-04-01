using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class IfStaticCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _thenSource;
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> thenSource, IRWSMonad<TEnvironment, TOutput, TState, TValue> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TValue> RunRWS(TEnvironment environment, TState state) {
				if(_selector()) {
					return _thenSource.RunRWS(environment, state);
				}
				else {
					return _elseSource.RunRWS(environment, state);
				}
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> If<TEnvironment, TOutput, TState, TValue>(IRWSMonad<TEnvironment, TOutput, TState, TValue> thenSource, IRWSMonad<TEnvironment, TOutput, TState, TValue> elseSource, Func<bool> selector) {
			return new IfStaticCore<TEnvironment, TOutput, TState, TValue>(thenSource, elseSource, selector);
		}
	}
}