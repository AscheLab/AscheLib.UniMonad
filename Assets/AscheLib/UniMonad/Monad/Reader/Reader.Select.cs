using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class SelectCore<TEnvironment, TValue, TResult> : IReaderMonad<TEnvironment, TResult> {
			IReaderMonad<TEnvironment, TValue> _self;
			Func<TValue, TResult> _selector;
			public SelectCore(IReaderMonad<TEnvironment, TValue> self, Func<TValue, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult Run(TEnvironment environment) {
				return _selector(_self.Run(environment));
			}
		}
		public static IReaderMonad<TEnvironment, TResult> Select<TEnvironment, TValue, TResult>(this IReaderMonad<TEnvironment, TValue> self, Func<TValue, TResult> selector) {
			return new SelectCore<TEnvironment, TValue, TResult>(self, selector);
		}
	}
}