using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class ShareCore<T> : IIOMonad<T> {
			IIOMonad<T> _self;
			Lazy<T> _lazy;
			public ShareCore(IIOMonad<T> self) {
				_self = self;
				_lazy = Lazy.Create<T>(RunSelf);
			}
			public T RunIO() {
				return _lazy.Value;
			}
			T RunSelf() {
				return _self.RunIO();
			}
		}
		public static IIOMonad<T> Share<T>(this IIOMonad<T> self) {
			return new ShareCore<T>(self);
		}
	}
}