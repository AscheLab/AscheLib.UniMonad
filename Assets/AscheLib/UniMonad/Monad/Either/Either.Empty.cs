using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class EmptyCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			public EmptyCore() {

			}
			public IEitherResult<TLeft, TRight> RunEither() {
				return new RightResult<TLeft, TRight>(default(TRight));
			}
		}
		public static IEitherMonad<TLeft, TRight> Empty<TLeft, TRight>() {
			return new EmptyCore<TLeft, TRight>();
		}
	}
}