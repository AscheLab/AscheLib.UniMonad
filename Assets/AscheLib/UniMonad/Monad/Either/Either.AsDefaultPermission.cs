using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class AsDefaultPermissionCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			public AsDefaultPermissionCore(IEitherMonad<TLeft, TRight> self) {
				_self = self;
			}
			public IEitherResult<TLeft, TRight> RunEither() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				if(result.IsLeft) {
					return new LeftResult<TLeft, TRight>(result.Left);
				}
				else {
					return new RightResult<TLeft, TRight>(result.Right);
				}
			}
		}
		public static IEitherMonad<TLeft, TRight> AsDefaultPermission<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self) {
			return new AsDefaultPermissionCore<TLeft, TRight>(self);
		}
	}
}