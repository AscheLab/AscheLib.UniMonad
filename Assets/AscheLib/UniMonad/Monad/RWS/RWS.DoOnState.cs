using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class DoOnStateCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			Action<TState> _action;
			public DoOnStateCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<TState> action) {
				_self = self;
				_action = action;
			}
			public RWSResult<TOutput, TState, TValue> Run(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> selfResult = _self.Run(environment, state);
				_action(selfResult.State);
				return selfResult;
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> DoOnState<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<TState> action) {
			return new DoOnStateCore<TEnvironment, TOutput, TState, TValue>(self, action);
		}
	}
}