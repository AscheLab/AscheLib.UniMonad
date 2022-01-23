using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class ReturnCore<T> : IIOMonad<T> {
			T _value;
			public ReturnCore (T value) {
				_value = value;
			}

			public T Run () {
				return _value;
			}
		}
		public static IIOMonad<T> Return<T>(T value = default(T)) {
			return new ReturnCore<T>(value);
		}
	}
}