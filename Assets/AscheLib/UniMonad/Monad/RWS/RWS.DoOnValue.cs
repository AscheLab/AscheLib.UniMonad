using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class DoOnValueCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			Action<TValue> _action;
			public DoOnValueCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<TValue> action) {
				_self = self;
				_action = action;
			}
			public RWSResult<TOutput, TState, TValue> RunRWS(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> selfResult = _self.RunRWS(environment, state);
				_action(selfResult.Value);
				return selfResult;
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> DoOnValue<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<TValue> action) {
			return new DoOnValueCore<TEnvironment, TOutput, TState, TValue>(self, action);
		}
	}
}