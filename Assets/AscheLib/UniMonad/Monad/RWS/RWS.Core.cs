using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IRWSMonad<TEnvironment, TOutput, TState, TValue> {
		RWSResult<TOutput, TState, TValue> Run(TEnvironment environment, TState state);
	}
	public struct RWSResult<TOutput, TState, TValue> {
		public TValue Value { private set; get; }
		public IEnumerable<TOutput> Output { private set; get; }
		public TState State { private set; get; }

		public RWSResult(TValue value, IEnumerable<TOutput> output, TState state) {
			Value = value;
			Output = output;
			State = state;
		}
	}
	public static class RWSResult {
		public static RWSResult<TOutput, TState, TValue> Create<TOutput, TState, TValue>(TValue value, IEnumerable<TOutput> output, TState state) {
			return new RWSResult<TOutput, TState, TValue>(value, output, state);
		}
	}

	public static partial class RWS {

	}
}