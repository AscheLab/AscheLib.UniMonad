using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class IfStaticCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TValue> {
			IReaderMonad<TEnvironment, TValue> _thenSource;
			IReaderMonad<TEnvironment, TValue> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IReaderMonad<TEnvironment, TValue> thenSource, IReaderMonad<TEnvironment, TValue> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public TValue Run(TEnvironment environment) {
				if(_selector()) {
					return _thenSource.Run(environment);
				}
				else {
					return _elseSource.Run(environment);
				}
			}
		}
		public static IReaderMonad<TEnvironment, TValue> If<TEnvironment, TValue>(IReaderMonad<TEnvironment, TValue> thenSource, IReaderMonad<TEnvironment, TValue> elseSource, Func<bool> selector) {
			return new IfStaticCore<TEnvironment, TValue>(thenSource, elseSource, selector);
		}
	}
}