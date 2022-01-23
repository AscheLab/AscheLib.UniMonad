using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class IfCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TValue> {
			IReaderMonad<TEnvironment, TValue> _self;
			IReaderMonad<TEnvironment, TValue> _elseSource;
			Func<TValue, bool> _selector;
			public IfCore(IReaderMonad<TEnvironment, TValue> self, IReaderMonad<TEnvironment, TValue> elseSource, Func<TValue, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public TValue Run(TEnvironment environment) {
				TValue result = _self.Run(environment);
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.Run(environment);
				}
			}
		}
		public static IReaderMonad<TEnvironment, TValue> If<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, IReaderMonad<TEnvironment, TValue> elseSource, Func<TValue, bool> selector) {
			return new IfCore<TEnvironment, TValue>(self, elseSource, selector);
		}
	}
}