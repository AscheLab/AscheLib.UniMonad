using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class GetReturnNoArgumentCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, TState> {
			public GetReturnNoArgumentCore() {

			}
			public RWSResult<TOutput, TState, TState> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(state, new TOutput[0], state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TState> Get<TEnvironment, TOutput, TState>() {
			return new GetReturnNoArgumentCore<TEnvironment, TOutput, TState>();
		}

		private class GetReturnSelectCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, TState> {
			Func<TState, TState> _selector;
			public GetReturnSelectCore(Func<TState, TState> selector) {
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TState> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(state, new TOutput[0], _selector(state));
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TState> Get<TEnvironment, TOutput, TState>(Func<TState, TState> selector) {
			return new GetReturnSelectCore<TEnvironment, TOutput, TState>(selector);
		}
	}
}