using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class PutCore<TState> : IStateMonad<TState, Unit> {
			TState _state;
			public PutCore(TState state) {
				_state = state;
			}
			public StateResult<TState, Unit> Run(TState state) {
				return StateResult.Create(_state, Unit.Default);
			}
		}
		public static IStateMonad<TState, Unit> Put<TState>(TState state) {
			return new PutCore<TState>(state);
		}
	}
}