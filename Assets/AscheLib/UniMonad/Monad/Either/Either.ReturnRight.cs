using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class ReturnRightCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			TRight _value;
			public ReturnRightCore(TRight value) {
				_value = value;
			}
			public IEitherResult<TLeft, TRight> Run() {
				return new RightResult<TLeft, TRight>(_value);
			}
		}
		public static IEitherMonad<TLeft, TRight> ReturnRight<TLeft, TRight>(TRight value) {
			return new ReturnRightCore<TLeft, TRight>(value);
		}
	}
}