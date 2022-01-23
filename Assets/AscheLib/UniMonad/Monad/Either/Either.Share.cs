using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class ShareCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			Lazy<IEitherResult<TLeft, TRight>> _lazy;
			public ShareCore(IEitherMonad<TLeft, TRight> self) {
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
		public static IEitherMonad<TLeft, TRight> Share<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self) {
			return new ShareCore<TLeft, TRight>(self);
		}
	}
}