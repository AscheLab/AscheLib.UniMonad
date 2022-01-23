using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class CreateCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TValue> {
			Func<TEnvironment, TValue> _func;
			public CreateCore(Func<TEnvironment, TValue> func) {
				_func = func;
			}
			public TValue Run(TEnvironment environment) {
				return _func(environment);
			}
		}
		public static IReaderMonad<TEnvironment, TValue> Create<TEnvironment, TValue>(Func<TEnvironment, TValue> func) {
			return new CreateCore<TEnvironment, TValue>(func);
		}
	}
}