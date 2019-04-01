using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class SelectCore<T, TResult> : IOptionMonad<TResult> {
			IOptionMonad<T> _self;
			Func<T, TResult> _selector;
			public SelectCore(IOptionMonad<T> self, Func<T, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public IOptionResult<TResult> RunOption() {
				IOptionResult<T> result = _self.RunOption();
				if(!result.IsNone) return new JustResult<TResult>(_selector(result.Value));
				return NoneResult<TResult>.Default;
			}
		}
		public static IOptionMonad<TResult> Select<T, TResult>(this IOptionMonad<T> self, Func<T, TResult> selector) {
			return new SelectCore<T, TResult>(self, selector);
		}
	}
}