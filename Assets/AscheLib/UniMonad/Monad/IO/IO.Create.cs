using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class CreateCore<T> : IIOMonad<T> {
			Func<T> _func;
			public CreateCore(Func<T> func) {
				_func = func;
			}
			public T RunIO() {
				return _func();
			}
		}
		public static IIOMonad<T> Create<T>(Func<T> func) {
			return new CreateCore<T>(func);
		}
	}
}