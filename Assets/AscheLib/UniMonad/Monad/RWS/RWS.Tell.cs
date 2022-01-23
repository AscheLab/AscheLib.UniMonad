using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class TellCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, Unit> {
			TOutput _output;
			public TellCore(TOutput output) {
				_output = output;
			}
			public RWSResult<TOutput, TState, Unit> Run(TEnvironment environment, TState state) {
				return RWSResult.Create(Unit.Default, new TOutput[1] { _output }, state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, Unit> Tell<TEnvironment, TOutput, TState>(TOutput output) {
			return new TellCore<TEnvironment, TOutput, TState>(output);
		}


		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> Tell<TEnvironment, TOutput, TState, TValue>(TValue value, TOutput output) {
			return RWS.Create<TEnvironment, TOutput, TState, TValue>((e, s) => RWSResult.Create(value, new TOutput[1] { output }, s));
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TValue> Tell<TEnvironment, TOutput, TState, TValue>(TValue value, IEnumerable<TOutput> outputs) {
			return RWS.Create<TEnvironment, TOutput, TState, TValue>((e, s) => RWSResult.Create(value, outputs, s));
		}
	}
}