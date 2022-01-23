using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class ReturnLeftCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			TLeft _value;
			public ReturnLeftCore(TLeft value) {
				_value = value;
			}
			public IEitherResult<TLeft, TRight> Run() {
				return new LeftResult<TLeft, TRight>(_value);
			}
		}
		public static IEitherMonad<TLeft, TRight> ReturnLeft<TLeft, TRight>(TLeft value) {
			return new ReturnLeftCore<TLeft, TRight>(value);
		}
	}
}