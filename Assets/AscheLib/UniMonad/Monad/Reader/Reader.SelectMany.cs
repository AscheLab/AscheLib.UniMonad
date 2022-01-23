using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class SelectManyCore<TEnvironment, TValue, TResult> : IReaderMonad<TEnvironment, TResult> {
			IReaderMonad<TEnvironment, TValue> _self;
			Func<TValue, IReaderMonad<TEnvironment, TResult>> _selector;
			public SelectManyCore(IReaderMonad<TEnvironment, TValue> self, Func<TValue, IReaderMonad<TEnvironment, TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult Run(TEnvironment environment) {
				return _selector(_self.Run(environment)).Run(environment);
			}
		}
		public static IReaderMonad<TEnvironment, TResult> SelectMany<TEnvironment, TValue, TResult>(this IReaderMonad<TEnvironment, TValue> self, Func<TValue, IReaderMonad<TEnvironment, TResult>> selector) {
			return new SelectManyCore<TEnvironment, TValue, TResult>(self, selector);
		}

		private class SelectManyCore<TEnvironment, TFirst, TSecond, TResult> : IReaderMonad<TEnvironment, TResult> {
			IReaderMonad<TEnvironment, TFirst> _self;
			Func<TFirst, IReaderMonad<TEnvironment, TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IReaderMonad<TEnvironment, TFirst> self, Func<TFirst, IReaderMonad<TEnvironment, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public TResult Run(TEnvironment environment) {
				TFirst firstResult = _self.Run(environment);
				TSecond secondResult = _selector(firstResult).Run(environment);
				return _projector(firstResult, secondResult);
			}
		}
		public static IReaderMonad<TEnvironment, TResult> SelectMany<TEnvironment, TFirst, TSecond, TResult>(this IReaderMonad<TEnvironment, TFirst> self, Func<TFirst, IReaderMonad<TEnvironment, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TEnvironment, TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}