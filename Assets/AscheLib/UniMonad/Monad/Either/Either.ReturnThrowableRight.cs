using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class ReturnThrowableRightCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			TRight _value;
			public ReturnThrowableRightCore(TRight value) {
				_value = value;
			}
			public IEitherResult<TLeft, TRight> Run() {
				return new ThrowableRightResult<TLeft, TRight>(_value);
			}
		}
		public static IEitherMonad<TLeft, TRight> ReturnThrowableRight<TLeft, TRight>(TRight value) {
			return new ReturnThrowableRightCore<TLeft, TRight>(value);
		}
	}
}