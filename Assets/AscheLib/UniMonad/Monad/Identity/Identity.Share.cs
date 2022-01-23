using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class ShareCore<T> : IIdentityMonad<T> {
			IIdentityMonad<T> _self;
			Lazy<T> _lazy;
			public ShareCore(IIdentityMonad<T> self) {
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
		public static IIdentityMonad<T> Share<T>(this IIdentityMonad<T> self) {
			return new ShareCore<T>(self);
		}
	}
}