using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class WhereCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Func<T, bool> _selector;
			public WhereCore(IOptionMonad<T> self, Func<T, bool> selector) {
				_self = self;
				_selector = selector;
			}
			public IOptionResult<T> RunOption() {
				IOptionResult<T> result = _self.RunOption();
				if(!result.IsNone && _selector(result.Value)) return new JustResult<T>(result.Value);
				return NoneResult<T>.Default;
			}
		}
		public static IOptionMonad<T> Where<T>(this IOptionMonad<T> self, Func<T, bool> selector) {
			return new WhereCore<T>(self, selector);
		}
	}
}