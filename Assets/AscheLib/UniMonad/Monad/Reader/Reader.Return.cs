using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class ReturnCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TValue> {
			TValue _value;
			public ReturnCore(TValue value) {
				_value = value;
			}
			public TValue Run(TEnvironment environment) {
				return _value;
			}
		}
		public static IReaderMonad<TEnvironment, TValue> Return<TEnvironment, TValue>(TValue value = default(TValue)) {
			return new ReturnCore<TEnvironment, TValue>(value);
		}
	}
}