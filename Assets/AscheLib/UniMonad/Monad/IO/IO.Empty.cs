using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class EmptyCore<T> : IIOMonad<T> {
			public EmptyCore() {

			}
			public T RunIO() {
				return default(T);
			}
		}
		public static IIOMonad<T> Empty<T>() {
			return new EmptyCore<T>();
		}
	}
}