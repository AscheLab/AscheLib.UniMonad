using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class MatchRightCore<TLeft, TRight, TResult> : IIdentityMonad<TResult> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TRight, TResult> _selector;
			public MatchRightCore(IEitherMonad<TLeft, TRight> self, Func<TRight, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult Run() {
				return _selector(_self.Run().Right);
			}
		}
		public static IIdentityMonad<TResult> MatchRight<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Func<TRight, TResult> selector) {
			return new MatchRightCore<TLeft, TRight, TResult>(self, selector);
		}

		private class MatchRightUnitCore<TLeft, TRight, TResult> : IIdentityMonad<Unit> {
			IEitherMonad<TLeft, TRight> _self;
			Action<TRight> _action;
			public MatchRightUnitCore(IEitherMonad<TLeft, TRight> self, Action<TRight> action) {
				_self = self;
				_action = action;
			}
			public Unit Run() {
				IEitherResult<TLeft, TRight> result = _self.Run();
				_action(result.Right);
				return Unit.Default;
			}
		}
		public static IIdentityMonad<Unit> MatchRight<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Action<TRight> action) {
			return new MatchRightUnitCore<TLeft, TRight, TResult>(self, action);
		}

		private class MatchRightOrDefaultCore<TLeft, TRight, TResult> : IIdentityMonad<TResult> {
			IEitherMonad<TLeft, TRight> _self;
			Func<TRight, TResult> _selector;
			TResult _defaultValue;
			public MatchRightOrDefaultCore(IEitherMonad<TLeft, TRight> self, Func<TRight, TResult> selector, TResult defaultValue) {
				_self = self;
				_selector = selector;
				_defaultValue = defaultValue;
			}
			public TResult Run() {
				IEitherResult<TLeft, TRight> result = _self.Run();
				return result.IsRight ? _selector(result.Right) : _defaultValue;
			}
		}
		public static IIdentityMonad<TResult> MatchRightOrDefault<TLeft, TRight, TResult>(this IEitherMonad<TLeft, TRight> self, Func<TRight, TResult> selector, TResult defaultValue = default(TResult)) {
			return new MatchRightOrDefaultCore<TLeft, TRight, TResult>(self, selector, defaultValue);
		}
	}
}