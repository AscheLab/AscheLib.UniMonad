using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class SelectCore<T, TResult> : IIOMonad<TResult> {
			IIOMonad<T> _self;
			Func<T, TResult> _selector;
			public SelectCore(IIOMonad<T> self, Func<T, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult Run() {
				return _selector(_self.Run());
			}
		}
		public static IIOMonad<TResult> Select<T, TResult>(this IIOMonad<T> self, Func<T, TResult> selector) {
			return new SelectCore<T, TResult>(self, selector);
		}
	}
}