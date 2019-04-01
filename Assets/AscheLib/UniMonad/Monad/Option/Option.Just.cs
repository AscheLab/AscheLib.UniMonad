using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class JustCore<T> : IOptionMonad<T> {
			T _value;
			public JustCore(T value) {
				_value = value;
			}
			public IOptionResult<T> RunOption() {
				return new JustResult<T>(_value);
			}
		}
		public static IOptionMonad<T> Just<T>(T value) {
			return new JustCore<T>(value);
		}
	}
}