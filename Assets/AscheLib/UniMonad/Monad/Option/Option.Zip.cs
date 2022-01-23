using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class ZipCore<TFirst, TSecond, TResult> : IOptionMonad<TResult> {
			IOptionMonad<TFirst> _self;
			IOptionMonad<TSecond> _second;
			Func<TFirst, TSecond, TResult> _resultSelector;
			public ZipCore(IOptionMonad<TFirst> self, IOptionMonad<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) {
				_self = self;
				_second = second;
				_resultSelector = resultSelector;
			}
			public IOptionResult<TResult> Run() {
				IOptionResult<TFirst> selfResult = _self.Run();
				IOptionResult<TSecond> secondResult = _second.Run();
				if(!selfResult.IsNone && !secondResult.IsNone) return new JustResult<TResult>(_resultSelector(selfResult.Value, secondResult.Value));
				return NoneResult<TResult>.Default;
			}
		}
		public static IOptionMonad<TResult> Zip<TFirst, TSecond, TResult>(this IOptionMonad<TFirst> self, IOptionMonad<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) {
			return new ZipCore<TFirst, TSecond, TResult>(self, second, resultSelector);
		}
	}
}