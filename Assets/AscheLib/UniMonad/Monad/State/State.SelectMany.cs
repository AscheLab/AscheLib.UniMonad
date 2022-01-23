using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class SelectManyCore<TState, TValue, TResult> : IStateMonad<TState, TResult> {
			IStateMonad<TState, TValue> _self;
			Func<TValue, IStateMonad<TState, TResult>> _selector;
			public SelectManyCore(IStateMonad<TState, TValue> self, Func<TValue, IStateMonad<TState, TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public StateResult<TState, TResult> Run(TState state) {
				StateResult<TState, TValue> result = _self.Run(state);
				return StateResult.Create(result.State, _selector(result.Value).Run(result.State).Value);
			}
		}
		public static IStateMonad<TState, TResult> SelectMany<TState, TValue, TResult>(this IStateMonad<TState, TValue> self, Func<TValue, IStateMonad<TState, TResult>> selector) {
			return new SelectManyCore<TState, TValue, TResult>(self, selector);
		}

		private class SelectManyCore<TState, TFirst, TSecond, TResult> : IStateMonad<TState, TResult> {
			IStateMonad<TState, TFirst> _self;
			Func<TFirst, IStateMonad<TState, TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IStateMonad<TState, TFirst> self, Func<TFirst, IStateMonad<TState, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public StateResult<TState, TResult> Run(TState state) {
				StateResult<TState, TFirst> firstResult = _self.Run(state);
				StateResult<TState, TSecond> secondResult = _selector(firstResult.Value).Run(firstResult.State);
				return new StateResult<TState, TResult>(secondResult.State, _projector(firstResult.Value, secondResult.Value));
			}
		}
		public static IStateMonad<TState, TResult> SelectMany<TState, TFirst, TSecond, TResult>(this IStateMonad<TState, TFirst> self, Func<TFirst, IStateMonad<TState, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TState, TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}