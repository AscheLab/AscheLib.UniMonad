using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class MatchLeftCore<TLeft, TRight, TResult> : IIdentityMonad<TResult> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TLeft, TResult> _selector;
			public MatchLeftCore(IEitherMonad<TLeft, TRight> self, Func<TLeft, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult RunIdentity() {
				return _selector(_self.RunEither().Left);
			}
		}
		public static IIdentityMonad<TResult> MatchLeft<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Func<TLeft, TResult> selector) {
			return new MatchLeftCore<TLeft, TRight, TResult>(self, selector);
		}

		private class MatchLeftUnitCore<TLeft, TRight, TResult> : IIdentityMonad<Unit> {
			IEitherMonad<TLeft, TRight> _self;
			Action<TLeft> _action;
			public MatchLeftUnitCore(IEitherMonad<TLeft, TRight> self, Action<TLeft> action) {
				_self = self;
				_action = action;
			}
			public Unit RunIdentity() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				_action(result.Left);
				return Unit.Default;
			}
		}
		public static IIdentityMonad<Unit> MatchLeft<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Action<TLeft> action) {
			return new MatchLeftUnitCore<TLeft, TRight, TResult>(self, action);
		}

		private class MatchLeftOrDefaultCore<TLeft, TRight, TResult> : IIdentityMonad<TResult> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TLeft, TResult> _selector;
			TResult _defaultValue;
			public MatchLeftOrDefaultCore(IEitherMonad<TLeft, TRight> self, Func<TLeft, TResult> selector, TResult defaultValue) {
				_self = self;
				_selector = selector;
				_defaultValue = defaultValue;
			}
			public TResult RunIdentity() {
				IEitherResult<TLeft, TRight> result = _self.RunEither();
				return result.IsLeft ? _selector(result.Left) : _defaultValue;
			}
		}
		public static IIdentityMonad<TResult> MatchLeftOrDefault<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Func<TLeft, TResult> selector, TResult defaultValue = default(TResult)) {
			return new MatchLeftOrDefaultCore<TLeft, TRight, TResult>(self, selector, defaultValue);
		}
	}
}