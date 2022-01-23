using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class IfCore<T> : IIOMonad<T> {
			IIOMonad<T> _self;
			IIOMonad<T> _elseSource;
			Func<T, bool> _selector;
			public IfCore(IIOMonad<T> self, IIOMonad<T> elseSource, Func<T, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public T Run() {
				T result = _self.Run();
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.Run();
				}
			}
		}
		public static IIOMonad<T> If<T>(this IIOMonad<T> self, IIOMonad<T> elseSource, Func<T, bool> selector) {
			return new IfCore<T>(self, elseSource, selector);
		}
	}
}