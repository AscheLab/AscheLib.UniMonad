using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class CreateCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			Func<TEnvironment, TState, RWSResult<TOutput, TState, TValue>> _func;
			public CreateCore(Func<TEnvironment, TState, RWSResult<TOutput, TState, TValue>> func) {
				_func = func;
			}
			public RWSResult<TOutput, TState, TValue> Run(TEnvironment environment, TState state) {
				return _func(environment, state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> Create<TEnvironment, TOutput, TState, TValue>(Func<TEnvironment, TState, RWSResult<TOutput, TState, TValue>> func) {
			return new CreateCore<TEnvironment, TOutput, TState, TValue>(func);
		}
	}
}