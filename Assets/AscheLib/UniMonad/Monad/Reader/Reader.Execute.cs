using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		public static void Execute<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, TEnvironment environment) {
			self.RunReader(environment);
		}
		public static void Execute<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, TEnvironment environment, Action<TValue> onValue) {
			TValue result = self.RunReader(environment);
			onValue(result);
		}
	}
}