using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class AsThrowableCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			public AsThrowableCore(IEitherMonad<TLeft, TRight> self) {
				_self = self;
			}
			public IEitherResult<TLeft, TRight> Run() {
				IEitherResult<TLeft, TRight> result = _self.Run();
				if(result.IsLeft) {
					return new ThrowableLeftResult<TLeft, TRight>(result.Left);
				}
				else {
					return new ThrowableRightResult<TLeft, TRight>(result.Right);
				}
			}
		}
		public static IEitherMonad<TLeft, TRight> AsThrowable<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self) {
			return new AsThrowableCore<TLeft, TRight>(self);
		}
	}
}