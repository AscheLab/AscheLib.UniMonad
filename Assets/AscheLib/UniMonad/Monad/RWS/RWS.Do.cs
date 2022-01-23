using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class DoCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			Action<RWSResult<TOutput, TState, TValue>> _action;
			public DoCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<RWSResult<TOutput, TState, TValue>> action) {
				_self = self;
				_action = action;
			}
			public RWSResult<TOutput, TState, TValue> Run(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> selfResult = _self.Run(environment, state);
				_action(selfResult);
				return selfResult;
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> Do<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<RWSResult<TOutput, TState, TValue>> action) {
			return new DoCore<TEnvironment, TOutput, TState, TValue>(self, action);
		}
	}
}