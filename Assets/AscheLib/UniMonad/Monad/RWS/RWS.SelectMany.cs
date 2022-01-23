using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class SelectManyCore<TEnvironment, TOutput, TState, TValue, TResult> : IRWSMonad<TEnvironment, TOutput, TState, TResult>
			where TState : class {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			Func<TValue, IRWSMonad<TEnvironment, TOutput, TState, TResult>> _selector;
			public SelectManyCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Func<TValue, IRWSMonad<TEnvironment, TOutput, TState, TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public RWSResult<TOutput, TState, TResult> Run(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TValue> selfResult = _self.Run(environment, state);
				return _selector(selfResult.Value).Run(environment, selfResult.State ?? state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TResult> SelectMany<TEnvironment, TOutput, TState, TValue, TResult>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, Func<TValue, IRWSMonad<TEnvironment, TOutput, TState, TResult>> selector)
			where TState : class {
			return new SelectManyCore<TEnvironment, TOutput, TState, TValue, TResult>(self, selector);
		}

		private class SelectManyCore<TEnvironment, TOutput, TState, TFirst, TSecond, TResult> : IRWSMonad<TEnvironment, TOutput, TState, TResult>
			where TState : class {
			IRWSMonad<TEnvironment, TOutput, TState, TFirst> _self;
			Func<TFirst, IRWSMonad<TEnvironment, TOutput, TState, TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IRWSMonad<TEnvironment, TOutput, TState, TFirst> self, Func<TFirst, IRWSMonad<TEnvironment, TOutput, TState, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public RWSResult<TOutput, TState, TResult> Run(TEnvironment environment, TState state) {
				RWSResult<TOutput, TState, TFirst> selfResult = _self.Run(environment, state);
				RWSResult<TOutput, TState, TSecond> secondResult = _selector(selfResult.Value).Run(environment, selfResult.State ?? state);
				return RWSResult.Create(_projector(selfResult.Value, secondResult.Value), selfResult.Output.Concat(secondResult.Output), secondResult.State ?? selfResult.State ?? state);
			}
		}
		public static IRWSMonad<TEnvironment, TOutput, TState, TResult> SelectMany<TEnvironment, TOutput, TState, TFirst, TSecond, TResult>(this IRWSMonad<TEnvironment, TOutput, TState, TFirst> self, Func<TFirst, IRWSMonad<TEnvironment, TOutput, TState, TSecond>> selector, Func<TFirst, TSecond, TResult> projector)
			where TState : class {
			return new SelectManyCore<TEnvironment, TOutput, TState, TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}