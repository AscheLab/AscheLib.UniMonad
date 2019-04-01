using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class AskReturnNoArgumentCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> {
			public AskReturnNoArgumentCore() {

			}
			public RWSResult<TOutput, TState, TEnvironment> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(environment, new TOutput[0], state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> Ask<TEnvironment, TOutput, TState>() {
			return new AskReturnNoArgumentCore<TEnvironment, TOutput, TState>();
		}

		private class AskReturnSelectCore<TEnvironment, TOutput, TState> : IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> {
			Func<TEnvironment, TEnvironment> _selector;
			public AskReturnSelectCore(Func<TEnvironment, TEnvironment> selector) {
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TEnvironment> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(_selector(environment), new TOutput[0], state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> Ask<TEnvironment, TOutput, TState>(Func<TEnvironment, TEnvironment> selector) {
			return new AskReturnSelectCore<TEnvironment, TOutput, TState>(selector);
		}

		private class AskCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> {
			public AskCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self) {

			}
			public RWSResult<TOutput, TState, TEnvironment> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(environment, new TOutput[0], state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> Ask<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self) {
			return new AskCore<TEnvironment, TOutput, TState, TValue>(self);
		}

		private class AskSelectCore<TEnvironment, TOutput, TState, TValue> : IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> {
			Func<TEnvironment, TEnvironment> _selector;
			public AskSelectCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Func<TEnvironment, TEnvironment> selector) {
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TEnvironment> RunRWS(TEnvironment environment, TState state) {
				return RWSResult.Create(_selector(environment), new TOutput[0], state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TEnvironment> Ask<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Func<TEnvironment, TEnvironment> selector) {
			return new AskSelectCore<TEnvironment, TOutput, TState, TValue>(self, selector);
		}
	}
}