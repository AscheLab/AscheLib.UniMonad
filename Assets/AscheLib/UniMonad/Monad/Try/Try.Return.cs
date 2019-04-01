using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class ReturnCore<T> : ITryMonad<T> {
			T _value;
			public ReturnCore(T value) {
				_value = value;
			}
			public ITryResult<T> RunTry() {
				return new Success<T>(_value);
			}
		}
		public static ITryMonad<T> Return<T>(T value) {
			return new ReturnCore<T>(value);
		}
	}
}