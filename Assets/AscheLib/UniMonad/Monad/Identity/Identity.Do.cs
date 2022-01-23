using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class DoCore<T> : IIdentityMonad<T> {
			IIdentityMonad<T> _self;
			Action<T> _action;
			public DoCore(IIdentityMonad<T> self, Action<T> action) {
				_self = self;
				_action = action;
			}
			public T Run() {
				T result = _self.Run();
				_action(result);
				return result;
			}
		}
		public static IIdentityMonad<T> Do<T>(this IIdentityMonad<T> self, Action<T> action) {
			return new DoCore<T>(self, action);
		}
	}
}