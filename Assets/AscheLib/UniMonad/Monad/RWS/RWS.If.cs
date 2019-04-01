using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class IfCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _elseSource;
			Func<RWSResult<TOutput, TState, TValue>, bool> _selector;
			public IfCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, IRWSMonad<TEnvironment, TOutput, TState, TValue> elseSource, Func<RWSResult<TOutput, TState, TValue>, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TValue> RunRWS(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> result = _self.RunRWS(environment, state);
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.RunRWS(environment, state);
				}
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> If<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, IRWSMonad<TEnvironment, TOutput, TState, TValue> elseSource, Func<RWSResult<TOutput, TState, TValue>, bool> selector) {
			return new IfCore<TEnvironment, TOutput, TState, TValue>(self, elseSource, selector);
		}
	}
}