using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class NoneCore<T> : IOptionMonad<T> {
			public NoneCore() {

			}
			public IOptionResult<T> Run() {
				return NoneResult<T>.Default;
			}
		}
		public static IOptionMonad<T> None<T>() {
			return new NoneCore<T>();
		}
	}
}