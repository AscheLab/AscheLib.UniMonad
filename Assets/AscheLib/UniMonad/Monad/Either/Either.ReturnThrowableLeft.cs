using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class ReturnThrowableLeftCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			TLeft _value;
			public ReturnThrowableLeftCore(TLeft value) {
				_value = value;
			}
			public IEitherResult<TLeft, TRight> RunEither() {
				return new ThrowableLeftResult<TLeft, TRight>(_value);
			}
		}
		public static IEitherMonad<TLeft, TRight> ReturnThrowableLeft<TLeft, TRight>(TLeft value) {
			return new ReturnThrowableLeftCore<TLeft, TRight>(value);
		}
	}
}