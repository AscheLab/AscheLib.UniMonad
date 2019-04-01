using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class SelectManyCore<T, TResult> : IOptionMonad<TResult> {
			IOptionMonad<T> _self;
			Func<T, IOptionMonad<TResult>> _selector;
			public SelectManyCore(IOptionMonad<T> self, Func<T, IOptionMonad<TResult>> selector ) {
				_self = self;
				_selector = selector;
			}
			public IOptionResult<TResult> RunOption() {
				IOptionResult<T> result = _self.RunOption();
				if(!result.IsNone) return _selector(result.Value).RunOption();
				return NoneResult<TResult>.Default;
			}
		}
		public static IOptionMonad<TResult> SelectMany<T, TResult>(this IOptionMonad<T> self, Func<T, IOptionMonad<TResult>> selector) {
			return new SelectManyCore<T, TResult>(self, selector);
		}
		
		private class SelectManyCore<TFirst, TSecond, TResult> : IOptionMonad<TResult> {
			IOptionMonad<TFirst> _self;
			Func<TFirst, IOptionMonad<TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IOptionMonad<TFirst> self, Func<TFirst, IOptionMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public IOptionResult<TResult> RunOption() {
				IOptionResult<TFirst> selfResult = _self.RunOption();
				if(!selfResult.IsNone) {
					IOptionResult<TSecond> secondResult = _selector(selfResult.Value).RunOption();
					if(!secondResult.IsNone) return new JustResult<TResult>(_projector(selfResult.Value, secondResult.Value));
				}
				return NoneResult<TResult>.Default;
			}
		}
		public static IOptionMonad<TResult> SelectMany<TFirst, TSecond, TResult>(this IOptionMonad<TFirst> self, Func<TFirst, IOptionMonad<TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}