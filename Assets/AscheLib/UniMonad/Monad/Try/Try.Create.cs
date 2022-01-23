using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class CreateCore<T> : ITryMonad<T> {
			Func<ITryResult<T>> _func;
			public CreateCore(Func<ITryResult<T>> func) {
				_func = func;
			}
			public ITryResult<T> Run() {
				try {
					return _func();
				}
				catch(Exception e) {
					return new Failure<T>(e);
				}
			}
		}
		public static ITryMonad<T> Create<T>(Func<ITryResult<T>> func) {
			return new CreateCore<T>(func);
		}
	}
}