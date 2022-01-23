using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class ToIdentityCore<T> : IIdentityMonad<T> {
			IIOMonad<T> _self;
			Lazy<T> _lazy;
			public ToIdentityCore (IIOMonad<T> self) {
				_self = self;
				_lazy = Lazy.Create<T>(RunSelf);
			}
			public T Run() {
				return _lazy.Value;
			}
			T RunSelf() {
				return _self.Run();
			}
		}
		public static IIdentityMonad<T> ToIdentity<T>(this IIOMonad<T> self) {
			return new ToIdentityCore<T>(self);
		}
	}
}