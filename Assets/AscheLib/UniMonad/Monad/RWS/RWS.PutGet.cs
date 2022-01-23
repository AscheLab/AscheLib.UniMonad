using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class PutGetCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, TState> {
			TState _state;
			public PutGetCore(TState state) {
				_state = state;
			}
			public RWSResult<TOutput, TState, TState> Run(TEnvironment environment, TState state) {
				return RWSResult.Create(_state, new TOutput[0], _state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TState> PutGet<TEnvironment, TOutput, TState>(TState state) {
			return new PutGetCore<TEnvironment, TOutput, TState>(state);
		}
	}
}