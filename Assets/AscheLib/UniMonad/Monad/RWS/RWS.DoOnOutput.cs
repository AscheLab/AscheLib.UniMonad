using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class DoOnOutputCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			Action<IEnumerable<TOutput>> _action;
			public DoOnOutputCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<IEnumerable<TOutput>> action) {
				_self = self;
				_action = action;
			}
			public RWSResult<TOutput, TState, TValue> Run(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> selfResult = _self.Run(environment, state);
				_action(selfResult.Output);
				return selfResult;
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> DoOnOutput<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Action<IEnumerable<TOutput>> action) {
			return new DoOnOutputCore<TEnvironment, TOutput, TState, TValue>(self, action);
		}
	}
}