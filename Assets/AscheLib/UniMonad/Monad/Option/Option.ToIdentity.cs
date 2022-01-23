using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class ToIdentityCore<T> : IIdentityMonad<IOptionResult<T>> {
			IOptionMonad<T> _self;
			Lazy<IOptionResult<T>> _lazy;
			public ToIdentityCore (IOptionMonad<T> self) {
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
		public static IIdentityMonad<IOptionResult<T>> ToIdentity<T>(this IOptionMonad<T> self) {
			return new ToIdentityCore<T>(self);
		}
	}
}