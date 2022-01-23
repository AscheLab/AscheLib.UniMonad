using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		public static TState Execute<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state) {
			return self.Run(environment, state).State;
		}
		public static TState Execute<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state, Action<TValue> onValue) {
			RWSResult<TOutput, TState, TValue> selfResult = self.Run(environment, state);
			onValue(selfResult.Value);
			return selfResult.State;
		}
		public static TState Execute<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state, Action<TValue> onValue, Action<IEnumerable<TOutput>> onOutput) {
			RWSResult<TOutput, TState, TValue> selfResult = self.Run(environment, state);
			onValue(selfResult.Value);
			onOutput(selfResult.Output);
			return selfResult.State;
		}
		public static TState Execute<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state, Action<TValue> onValue, Action<TState> onState) {
			RWSResult<TOutput, TState, TValue> selfResult = self.Run(environment, state);
			onValue(selfResult.Value);
			onState(selfResult.State);
			return selfResult.State;
		}
		public static TState Execute<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state, Action<TValue> onValue, Action<TState> onState, Action<IEnumerable<TOutput>> onOutput) {
			RWSResult<TOutput, TState, TValue> selfResult = self.Run(environment, state);
			onValue(selfResult.Value);
			onState(selfResult.State);
			onOutput(selfResult.Output);
			return selfResult.State;
		}
	}
}