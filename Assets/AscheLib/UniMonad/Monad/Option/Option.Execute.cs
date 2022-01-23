using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		public static void Execute<T>(this IOptionMonad<T> self) {
			IOptionResult<T> selfResult = self.Run();
			if (selfResult.IsNone) {
				return;
			}
			else {
				return;
			}
		}
		public static void Execute<T>(this IOptionMonad<T> self, Action<T> onJust) {
			IOptionResult<T> selfResult = self.Run();
			if (selfResult.IsNone) {
				return;
			}
			else {
				onJust(selfResult.Value);
				return;
			}
		}
		public static void Execute<T>(this IOptionMonad<T> self, Action<T> onJust, Action onNone) {
			IOptionResult<T> selfResult = self.Run();
			if (selfResult.IsNone) {
				onNone();
				return;
			}
			else {
				onJust(selfResult.Value);
				return;
			}
		}
	}
}