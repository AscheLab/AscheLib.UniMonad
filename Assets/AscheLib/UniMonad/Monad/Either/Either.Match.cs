using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class MatchCore<TLeft, TRight, TResult> : IIdentityMonad<TResult> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TLeft, TResult> _leftSelector;
			Func<TRight, TResult> _rightSelector;
			public MatchCore(IEitherMonad<TLeft, TRight> self, Func<TLeft, TResult> leftSelector, Func<TRight, TResult> rightSelector) {
				_self = self;
				_leftSelector = leftSelector;
				_rightSelector = rightSelector;
			}
			public TResult RunIdentity() {
				var result = _self.RunEither();
				return result.IsLeft ? _leftSelector(result.Left) : _rightSelector(result.Right);
			}
		}
		public static IIdentityMonad<TResult> Match<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Func<TLeft, TResult> leftSelector, Func<TRight, TResult> rightSelector) {
			return new MatchCore<TLeft, TRight, TResult>(self, leftSelector, rightSelector);
		}
	}
}