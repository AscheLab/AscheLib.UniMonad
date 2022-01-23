using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class ShareCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Lazy<IOptionResult<T>> _lazy;
			public ShareCore(IOptionMonad<T> self) {
				_self = self;
				_lazy = Lazy.Create<IOptionResult<T>>(RunSelf);
			}
			public IOptionResult<T> Run() {
				return _lazy.Value;
			}
			IOptionResult<T> RunSelf() {
				return _self.Run();
			}
		}
		public static IOptionMonad<T> Share<T>(this IOptionMonad<T> self) {
			return new ShareCore<T>(self);
		}
	}
}