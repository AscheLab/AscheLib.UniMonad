using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class GetReturnNoArgumentCore<TState> : IStateMonad<TState, TState> {
			public GetReturnNoArgumentCore() {

			}
			public StateResult<TState, TState> Run(TState state) {
				return StateResult.Create(state, state);
			}
		}
		public static IStateMonad<TState, TState> Get<TState>() {
			return new GetReturnNoArgumentCore<TState>();
		}

		private class GetReturnSelectCore<TState> : IStateMonad<TState, TState> {
			Func<TState, TState> _selector;
			public GetReturnSelectCore(Func<TState, TState> selector) {
				_selector = selector;
			}
			public StateResult<TState, TState> Run(TState state) {
				return StateResult.Create(state, _selector(state));
			}
		}
		public static IStateMonad<TState, TState> Get<TState>(Func<TState, TState> selector) {
			return new GetReturnSelectCore<TState>(selector);
		}
	}
}