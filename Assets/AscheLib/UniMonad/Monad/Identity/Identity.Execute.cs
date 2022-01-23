using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		public static void Execute<T>(this IIdentityMonad<T> self) {
			self.Run();
		}
		public static void Execute<T>(this IIdentityMonad<T> self, Action<T> onValue) {
			T result = self.Run();
			onValue(result);
		}
	}
}