using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class ToIdentityCore<T> : IIdentityMonad<ITryResult<T>> {
			ITryMonad<T> _self;
			Lazy<ITryResult<T>> _lazy;
			public ToIdentityCore (ITryMonad<T> self) {
				_self = self;
				_lazy = Lazy.Create<ITryResult<T>>(RunSelf);
			}
			public ITryResult<T> Run() {
				return _lazy.Value;
			}
			ITryResult<T> RunSelf() {
				return _self.Run();
			}
		}
		public static IIdentityMonad<ITryResult<T>> ToIdentity<T>(this ITryMonad<T> self) {
			return new ToIdentityCore<T>(self);
		}
	}
}