using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class IfStaticCore<T> : IIOMonad<T> {
			IIOMonad<T> _thenSource;
			IIOMonad<T> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IIOMonad<T> thenSource, IIOMonad<T> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public T Run() {
				if(_selector()) {
					return _thenSource.Run();
				}
				else {
					return _elseSource.Run();
				}
			}
		}
		public static IIOMonad<T> If<T>(IIOMonad<T> thenSource, IIOMonad<T> elseSource, Func<bool> selector) {
			return new IfStaticCore<T>(thenSource, elseSource, selector);
		}
	}
}