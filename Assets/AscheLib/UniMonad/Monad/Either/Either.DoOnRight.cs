using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class DoOnRightCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			Action<TRight> _action;
			public DoOnRightCore(IEitherMonad<TLeft, TRight> self, Action<TRight> action) {
				_self = self;
				_action = action;
			}
			public IEitherResult<TLeft, TRight> RunEither() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				if(result.IsRight) _action(result.Right);
				return result;
			}
		}
		public static IEitherMonad<TLeft, TRight> DoOnRight<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self, Action<TRight> action) {
			return new DoOnRightCore<TLeft, TRight>(self, action);
		}
	}
}