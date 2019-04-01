using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class TryCreateCore<T> : IOptionMonad<T> {
			Func<T> _selector;
			public TryCreateCore(Func<T> selector) {
				_selector = selector;
			}
			public IOptionResult<T> RunOption() {
				try {
					return new JustResult<T>(_selector());
				}
				catch {
					return NoneResult<T>.Default;
				}
			}
		}
		public static IOptionMonad<T> TryCreate<T>(Func<T> selector) {
			return new TryCreateCore<T>(selector);
		}
	}
}