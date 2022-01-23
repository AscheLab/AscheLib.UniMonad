using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class CreateCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			Func<IEitherResult<TLeft, TRight>> _func;
			public CreateCore(Func<IEitherResult<TLeft, TRight>> func) {
				_func = func;
			}
			public IEitherResult<TLeft, TRight> Run() {
				return _func();
			}
		}
		public static IEitherMonad<TLeft, TRight> Create<TLeft, TRight>(Func<IEitherResult<TLeft, TRight>> func) {
			return new CreateCore<TLeft, TRight>(func);
		}
	}
}