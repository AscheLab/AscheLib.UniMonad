using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class ReturnCore<T> : IOptionMonad<T> {
			T _value;
			public ReturnCore (T value) {
				_value = value;
			}
			public IOptionResult<T> Run() {
				return new JustResult<T>(_value);
			}
		}
		public static IOptionMonad<T> Return<T>(T value) {
			return new ReturnCore<T>(value);
		}
	}
}