using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class CreateCore<T> : IOptionMonad<T> {
			Func<IOptionResult<T>> _func;
			public CreateCore(Func<IOptionResult<T>> func) {
				_func = func;
			}
			public IOptionResult<T> RunOption() {
				return _func();
			}
		}
		public static IOptionMonad<T> Create<T>(Func<IOptionResult<T>> func) {
			return new CreateCore<T>(func);
		}
	}
}