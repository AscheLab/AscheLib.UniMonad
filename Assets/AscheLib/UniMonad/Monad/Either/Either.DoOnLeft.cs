using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class DoOnLeftCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			Action<TLeft> _action;
			public DoOnLeftCore(IEitherMonad<TLeft, TRight> self, Action<TLeft> action) {
				_self = self;
				_action = action;
			}
			public IEitherResult<TLeft, TRight> RunEither() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				if(result.IsLeft) _action(result.Left);
				return result;
			}
		}
		public static IEitherMonad<TLeft, TRight> DoOnLeft<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self, Action<TLeft> action) {
			return new DoOnLeftCore<TLeft, TRight>(self, action);
		}
	}
}