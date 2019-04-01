using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Identity {
		private class ReturnCore<T> : IIdentityMonad<T> {
			T _value;
			public ReturnCore(T value) {
				_value = value;
			}
			public T RunIdentity() {
				return _value;
			}
		}
		public static IIdentityMonad<T> Return<T>(T value) {
			return new ReturnCore<T>(value);
		}
	}
}