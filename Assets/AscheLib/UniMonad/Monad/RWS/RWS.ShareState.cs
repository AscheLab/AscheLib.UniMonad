using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class ShareStateCore<TEnvironment, TOutput, TState, TValue> : IReaderMonad<TEnvironment, RWSResult<TOutput, TState, TValue>> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			TState _state;
			public ShareStateCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TState state) {
				_self = self;
				_state = state;
			}
			public RWSResult<TOutput, TState, TValue> RunReader(TEnvironment environment) {
				return _self.RunRWS(environment, _state);
			}
		}
		public static IReaderMonad<TEnvironment, RWSResult<TOutput, TState, TValue>> ShareState<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TState state) {
			return new ShareStateCore<TEnvironment, TOutput, TState, TValue>(self, state);
		}
	}
}