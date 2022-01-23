using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class SelectManyCore<T, TResult> : ITryMonad<TResult> {
			ITryMonad<T> _self;
			Func<T, ITryMonad<TResult>> _selector;
			public SelectManyCore(ITryMonad<T> self, Func<T, ITryMonad<TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public ITryResult<TResult> Run() {
				ITryResult<T> selfResult;
				try {
					selfResult = _self.Run();
					if(selfResult.IsFaulted)
						return new Failure<TResult>(selfResult.Exception);
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}
				TResult resultValue;
				try {
					resultValue = _selector(selfResult.Value).Run().Value;
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}
				return new Success<TResult>(resultValue);
			}
		}
		public static ITryMonad<TResult> SelectMany<T, TResult>(this ITryMonad<T> self, Func<T, ITryMonad<TResult>> selector) {
			return new SelectManyCore<T, TResult>(self, selector);
		}

		private class SelectManyCore<TFirst, TSecond, TResult> : ITryMonad<TResult> {
			ITryMonad<TFirst> _self;
			Func<TFirst, ITryMonad<TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(ITryMonad<TFirst> self, Func<TFirst, ITryMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public ITryResult<TResult> Run() {
				ITryResult<TFirst> selfResult;
				try {
					selfResult = _self.Run();
					if(selfResult.IsFaulted)
						return new Failure<TResult>(selfResult.Exception);
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}

				ITryResult<TSecond> secondResult;
				try {
					secondResult = _selector(selfResult.Value).Run();
					if(secondResult.IsFaulted)
						return new Failure<TResult>(secondResult.Exception);
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}

				TResult resultValue;
				try {
					resultValue = _projector(selfResult.Value, secondResult.Value);
				}
				catch(Exception e) {
					return new Failure<TResult>(e);
				}

				return new Success<TResult>(resultValue);
			}
		}
		public static ITryMonad<TResult> SelectMany<TFirst, TSecond, TResult>(this ITryMonad<TFirst> self, Func<TFirst, ITryMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}