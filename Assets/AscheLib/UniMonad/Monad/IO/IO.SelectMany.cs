using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class SelectManyCore<T, TResult> : IIOMonad<TResult> {
			IIOMonad<T> _self;
			Func<T, IIOMonad<TResult>> _selector;
			public SelectManyCore(IIOMonad<T> self, Func<T, IIOMonad<TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult Run() {
				return _selector(_self.Run()).Run();
			}
		}
		public static IIOMonad<TResult> SelectMany<T, TResult>(this IIOMonad<T> self, Func<T, IIOMonad<TResult>> selector) {
			return new SelectManyCore<T, TResult>(self, selector);
		}

		private class SelectManyCore<TFirst, TSecond, TResult> : IIOMonad<TResult> {
			IIOMonad<TFirst> _self;
			Func<TFirst, IIOMonad<TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IIOMonad<TFirst> self, Func<TFirst, IIOMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public TResult Run() {
				TFirst selfResult = _self.Run();
				TSecond secondResult = _selector(selfResult).Run();
				return _projector(selfResult, secondResult);
			}
		}
		public static IIOMonad<TResult> SelectMany<TFirst, TSecond, TResult>(this IIOMonad<TFirst> self, Func<TFirst, IIOMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}