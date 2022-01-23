using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class PutCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, Unit> {
			TState _state;
			public PutCore(TState state) {
				_state = state;
			}
			public RWSResult<TOutput, TState, Unit> Run(TEnvironment environment, TState state) {
				return RWSResult.Create(Unit.Default, new TOutput[0], _state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, Unit> Put<TEnvironment, TOutput, TState>(TState state) {
			return new PutCore<TEnvironment, TOutput, TState>(state);
		}
	}
}