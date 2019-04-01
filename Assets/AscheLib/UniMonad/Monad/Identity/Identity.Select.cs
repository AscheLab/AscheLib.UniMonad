using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class SelectCore<T, TResult> : IIdentityMonad<TResult> {
			IIdentityMonad<T> _self;
			Func<T, TResult> _selector;
			public SelectCore(IIdentityMonad<T> self, Func<T, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult RunIdentity() {
				return _selector(_self.RunIdentity());
			}
		}
		public static IIdentityMonad<TResult> Select<T, TResult>(this IIdentityMonad<T> self, Func<T, TResult> selector) {
			return new SelectCore<T, TResult>(self, selector);
		}
	}
}