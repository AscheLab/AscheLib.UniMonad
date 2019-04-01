using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class ReturnCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TValue> {
			TValue _value;
			public ReturnCore(TValue value) {
				_value = value;
			}
			public RWSResult<TOutput, TState, TValue> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(_value, new TOutput[0], state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> Return<TEnvironment, TOutput, TState, TValue>(TValue value) {
			return new ReturnCore<TEnvironment, TOutput, TState, TValue>(value);
		}
	}
}