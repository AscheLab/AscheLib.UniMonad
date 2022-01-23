using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		public static void Execute<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self) {
			IEitherResult<TLeft, TRight> selfResult = self.Run();
			if(selfResult.IsRight) {
				return;
			}
			else {
				return;
			}
		}
		public static void Execute<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self, Action<TRight> onRight) {
			IEitherResult<TLeft, TRight> selfResult = self.Run();
			if(selfResult.IsRight) {
				return;
			}
			else {
				onRight (selfResult.Right);
				return;
			}
		}
		public static void Execute<TLeft, TRight>(this IEitherMonad<TLeft, TRight> self, Action<TRight> onRight, Action<TLeft> onLeft) {
			IEitherResult<TLeft, TRight> selfResult = self.Run();
			if(selfResult.IsLeft) {
				onLeft (selfResult.Left);
				return;
			}
			else {
				onRight (selfResult.Right);
				return;
			}
		}
	}
}