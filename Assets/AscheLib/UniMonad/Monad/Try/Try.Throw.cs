using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class ThrowCore<T> : ITryMonad<T> {
			Exception _exception;
			public ThrowCore(Exception exception) {
				_exception = exception;
			}
			public ITryResult<T> Run() {
				return new Failure<T>(_exception);
			}
		}
		public static ITryMonad<T> Throw<T>(Exception exception) {
			return new ThrowCore<T>(exception);
		}
	}
}