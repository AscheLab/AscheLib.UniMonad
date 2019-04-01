using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class IfCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _self;
			IEitherMonad<TLeft, TRight> _elseSource;
			Func<IEitherResult<TLeft, TRight>, bool> _selector;
			public IfCore(IEitherMonad<TLeft, TRight> self, IEitherMonad<TLeft, TRight> elseSource, Func<IEitherResult<TLeft, TRight>, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public IEitherResult<TLeft, TRight> RunEither() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.RunEither();
				}
			}
		}
		public static IEitherMonad<TLeft, TRight> If<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self, IEitherMonad<TLeft, TRight> elseSource, Func<IEitherResult<TLeft, TRight>, bool> selector) {
			return new IfCore<TLeft, TRight>(self, elseSource, selector);
		}
	}
}