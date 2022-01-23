using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class SelectCore<T, TResult> : ITryMonad<TResult> {
			ITryMonad<T> _self;
			Func<T, TResult> _selector;
			public SelectCore(ITryMonad<T> self, Func<T, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public ITryResult<TResult> Run() {
				ITryResult<T> selfResult;
				try {
					selfResult = _self.Run();
					if(selfResult.IsFaulted)
						return new Failure<TResult>(selfResult.Exception);
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}

				TResult resultValue;
				try {
					resultValue = _selector(selfResult.Value);
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}

				return new Success<TResult>(resultValue);
			}
		}
		public static ITryMonad<TResult> Select<T, TResult>(this ITryMonad<T> self, Func<T, TResult> selector) {
			return new SelectCore<T, TResult>(self, selector);
		}
	}
}