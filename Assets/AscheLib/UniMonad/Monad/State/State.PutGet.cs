using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class PutGetCore<TState> : IStateMonad<TState, TState> {
			TState _state;
			public PutGetCore(TState state) {
				_state = state;
			}
			public StateResult<TState, TState> Run(TState state) {
				return StateResult.Create(_state, _state);
			}
		}
		public static IStateMonad<TState, TState> PutGet<TState>(TState state) {
			return new PutGetCore<TState>(state);
		}
	}
}