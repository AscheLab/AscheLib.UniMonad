using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class ShareEnvironmentCore<TEnvironment, TOutput, TState, TValue> : IStateMonad<TState, RWSResult<TOutput, TState, TValue>> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			TEnvironment _environment;
			public ShareEnvironmentCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment) {
				_self = self;
				_environment = environment;
			}
			public StateResult<TState, RWSResult<TOutput, TState, TValue>> Run(TState state) {
				return StateResult.Create(state, _self.Run(_environment, state));
			}
		}
		public static IStateMonad<TState, RWSResult<TOutput, TState, TValue>> ShareEnvironment<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment) {
			return new ShareEnvironmentCore<TEnvironment, TOutput, TState, TValue>(self, environment);
		}
	}
}