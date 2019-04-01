using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class SelectManyCore<TLeft, TRight, TResultRight> : IEitherMonad<TLeft, TResultRight> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TRight, IEitherMonad<TLeft, TResultRight>> _selector;
			public SelectManyCore(IEitherMonad<TLeft, TRight> self, Func<TRight, IEitherMonad<TLeft, TResultRight>> selector) {
				_self = self;
				_selector = selector;
			}
			public IEitherResult<TLeft, TResultRight> RunEither() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				if(result.IsLeft) {
					return new LeftResult<TLeft, TResultRight>(result.Left);
				}
				else {
					return _selector(result.Right).RunEither();
				}
			}
		}
		public static IEitherMonad<TLeft, TResultRight> SelectMany<TLeft, TRight, TResultRight>(this IEitherMonad<TLeft, TRight> self, Func<TRight, IEitherMonad<TLeft, TResultRight>> selector) {
			return new SelectManyCore<TLeft, TRight, TResultRight>(self, selector);
		}

		private class SelectManyCore<TLeft, TFirstRight, TSecondResult, TResultRight> : IEitherMonad<TLeft, TResultRight> {
			IEitherMonad<TLeft, TFirstRight> _self;
			Func<TFirstRight, IEitherMonad<TLeft, TSecondResult>> _selector;
			Func<TFirstRight, TSecondResult, TResultRight> _projector;
			public SelectManyCore(IEitherMonad<TLeft, TFirstRight> self, Func<TFirstRight, IEitherMonad<TLeft, TSecondResult>> selector, Func<TFirstRight, TSecondResult, TResultRight> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public IEitherResult<TLeft, TResultRight> RunEither() {
				IEitherResult<TLeft, TFirstRight> selfResult = _self.RunEither();
				if(selfResult.IsLeft) {
					return new LeftResult<TLeft, TResultRight>(selfResult.Left);
				}
				IEitherResult<TLeft, TSecondResult> secondResult = _selector(selfResult.Right).RunEither();
				if(secondResult.IsLeft) {
					return new LeftResult<TLeft, TResultRight>(secondResult.Left);
				}
				else {
					return new RightResult<TLeft, TResultRight>(_projector(selfResult.Right, secondResult.Right));
				}
			}
		}
		public static IEitherMonad<TLeft, TResultRight> SelectMany<TLeft, TFirstRight, TSecondResult, TResultRight>(this IEitherMonad<TLeft, TFirstRight> self, Func<TFirstRight, IEitherMonad<TLeft, TSecondResult>> selector, Func<TFirstRight, TSecondResult, TResultRight> projector) {
			return new SelectManyCore<TLeft, TFirstRight, TSecondResult, TResultRight>(self, selector, projector);
		}
	}
}