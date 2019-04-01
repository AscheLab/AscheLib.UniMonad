using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		public static void Execute<T>(this IIOMonad<T> self) {
			self.RunIO();
		}
		public static void Execute<T>(this IIOMonad<T> self, Action<T> onValue) {
			T result = self.RunIO();
			onValue(result);
		}
	}
}