using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class SelectCore<TLeft, TRight, TResultRight> : IEitherMonad<TLeft, TResultRight> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TRight, TResultRight> _selector;
			public SelectCore(IEitherMonad<TLeft, TRight> self, Func<TRight, TResultRight> selector) {
				_self = self;
				_selector = selector;
			}
			public IEitherResult<TLeft, TResultRight> Run() {
				IEitherResult<TLeft, TRight> result = _self.Run();
				if(result.IsLeft) {
					return new LeftResult<TLeft, TResultRight>(result.Left);
				}
				else {
					return new RightResult<TLeft, TResultRight>(_selector(result.Right));
				}
			}
		}
		public static IEitherMonad<TLeft, TResultRight> Select<TLeft, TRight, TResultRight>(this IEitherMonad<TLeft, TRight> self, Func<TRight, TResultRight> selector) {
			return new SelectCore<TLeft, TRight, TResultRight>(self, selector);
		}
	}
}