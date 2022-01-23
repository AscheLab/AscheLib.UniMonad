using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class DoCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			Action<IEitherResult<TLeft, TRight>> _action;
			public DoCore(IEitherMonad<TLeft, TRight> self, Action<IEitherResult<TLeft, TRight>> action) {
				_self = self;
				_action = action;
			}
			public IEitherResult<TLeft, TRight> Run() {
				IEitherResult<TLeft, TRight> result = _self.Run();
				_action(result);
				return result;
			}
		}
		public static IEitherMonad<TLeft, TRight> Do<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self, Action<IEitherResult<TLeft, TRight>> action) {
			return new DoCore<TLeft, TRight>(self, action);
		}
	}
}