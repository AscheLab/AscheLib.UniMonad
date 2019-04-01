using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class SelectManyCore<T, TResult> : IIdentityMonad<TResult> {
			IIdentityMonad<T> _self;
			Func<T, IIdentityMonad<TResult>> _selector;
			public SelectManyCore(IIdentityMonad<T> self, Func<T, IIdentityMonad<TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public TResult RunIdentity() {
				return _selector(_self.RunIdentity()).RunIdentity();
			}
		}
		public static IIdentityMonad<TResult> SelectMany<T, TResult>(this IIdentityMonad<T> self, Func<T, IIdentityMonad<TResult>> selector) {
			return new SelectManyCore<T, TResult>(self, selector);
		}

		private class SelectManyCore<TFirst, TSecond, TResult> : IIdentityMonad<TResult> {
			IIdentityMonad<TFirst> _self;
			Func<TFirst, IIdentityMonad<TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IIdentityMonad<TFirst> self, Func<TFirst, IIdentityMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public TResult RunIdentity() {
				TFirst selfResult = _self.RunIdentity();
				TSecond secondResult = _selector(selfResult).RunIdentity();
				return _projector(selfResult, secondResult);
			}
		}
		public static IIdentityMonad<TResult> SelectMany<TFirst, TSecond, TResult>(this IIdentityMonad<TFirst> self, Func<TFirst, IIdentityMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}