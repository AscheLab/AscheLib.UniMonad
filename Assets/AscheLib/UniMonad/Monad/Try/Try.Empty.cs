using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class EmptyCore<T> : ITryMonad<T> {
			public EmptyCore() {

			}
			public ITryResult<T> RunTry() {
				return new Success<T>(default(T));
			}
		}
		public static ITryMonad<T> Empty<T>() {
			return new EmptyCore<T>();
		}
	}
}