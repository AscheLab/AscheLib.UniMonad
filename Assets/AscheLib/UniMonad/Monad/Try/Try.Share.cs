using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class ShareCore<T> : ITryMonad<T> {
			ITryMonad<T> _self;
			Lazy<ITryResult<T>> _lazy;
			public ShareCore(ITryMonad<T> self) {
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
		public static ITryMonad<T> Share<T>(this ITryMonad<T> self) {
			return new ShareCore<T>(self);
		}
	}
}