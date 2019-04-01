using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class TryCreateCore<T> : ITryMonad<T> {
			Func<T> _selector;
			public TryCreateCore(Func<T> selector) {
				_selector = selector;
			}
			public ITryResult<T> RunTry() {
				try {
					return new Success<T>(_selector());
				}
				catch(Exception e) {
					return new Failure<T>(e);
				}
			}
		}
		public static ITryMonad<T> TryCreate<T>(Func<T> selector) {
			return new TryCreateCore<T>(selector);
		}
	}
}