using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class ToIdentityCore<TLeft, TRight> : IIdentityMonad<IEitherResult<TLeft, TRight>> {
			IEitherMonad<TLeft, TRight> _self;
			Lazy<IEitherResult<TLeft, TRight>> _lazy;
			public ToIdentityCore (IEitherMonad<TLeft, TRight> self) {
				_self = self;
				_lazy = Lazy.Create<IEitherResult<TLeft, TRight>>(RunSelf);
			}
			public IEitherResult<TLeft, TRight> Run() {
				return _lazy.Value;
			}
			IEitherResult<TLeft, TRight> RunSelf() {
				return _self.Run();
			}
		}
		public static IIdentityMonad<IEitherResult<TLeft, TRight>> ToIdentity<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self) {
			return new ToIdentityCore<TLeft, TRight>(self);
		}
	}
}