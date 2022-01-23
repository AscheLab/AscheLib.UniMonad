using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class IfCore<T> : IIdentityMonad<T> {
			IIdentityMonad<T> _self;
			IIdentityMonad<T> _elseSource;
			Func<T, bool> _selector;
			public IfCore(IIdentityMonad<T> self, IIdentityMonad<T> elseSource, Func<T, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public T Run() {
				T result = _self.Run();
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.Run();
				}
			}
		}
		public static IIdentityMonad<T> If<T>(this IIdentityMonad<T> self, IIdentityMonad<T> elseSource, Func<T, bool> selector) {
			return new IfCore<T>(self, elseSource, selector);
		}
	}
}