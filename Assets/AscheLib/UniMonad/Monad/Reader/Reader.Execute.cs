using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		public static void Execute<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, TEnvironment environment) {
			self.Run(environment);
		}
		public static void Execute<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, TEnvironment environment, Action<TValue> onValue) {
			TValue result = self.Run(environment);
			onValue(result);
		}
	}
}