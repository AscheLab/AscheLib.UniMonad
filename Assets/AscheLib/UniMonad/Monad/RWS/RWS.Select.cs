using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class SelectCore<TEnvironment, TOutput, TState, TValue, TResult> : IRWSMonad<TEnvironment, TOutput, TState, TResult>
			where TState : class {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			Func<TValue, TResult> _selector;
			public SelectCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Func<TValue, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TResult> Run(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> selfResult = _self.Run(environment, state);
				return RWSResult.Create(_selector(selfResult.Value), selfResult.Output, selfResult.State ?? state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TResult> Select<TEnvironment, TOutput, TState, TValue, TResult>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Func<TValue, TResult> selector)
			where TState : class {
			return new SelectCore<TEnvironment, TOutput, TState, TValue, TResult>(self, selector);
		}
	}
}