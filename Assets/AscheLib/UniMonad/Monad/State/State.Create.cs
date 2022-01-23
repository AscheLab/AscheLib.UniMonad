using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class CreateCore<TState, TValue> : IStateMonad<TState, TValue> {
			Func<TState, StateResult<TState, TValue>> _func;
			public CreateCore(Func<TState, StateResult<TState, TValue>> func) {
				_func = func;
			}
			public StateResult<TState, TValue> Run(TState state) {
				return _func(state);
			}
		}
		public static IStateMonad<TState, TValue> Create<TState, TValue>(Func<TState, StateResult<TState, TValue>> func) {
			return new CreateCore<TState, TValue>(func);
		}
	}
}