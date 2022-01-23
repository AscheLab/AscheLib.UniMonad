using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Either {
		private class IfStaticCore<TLeft, TRight> : IEitherMonad<TLeft, TRight> {
			IEitherMonad<TLeft, TRight> _thenSource;
			IEitherMonad<TLeft, TRight> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IEitherMonad<TLeft, TRight> thenSource, IEitherMonad<TLeft, TRight> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public IEitherResult<TLeft, TRight> Run() {
				if(_selector()) {
					return _thenSource.Run();
				}
				else {
					return _elseSource.Run();
				}
			}
		}
		public static IEitherMonad<TLeft, TRight> If<TLeft, TRight>(IEitherMonad<TLeft, TRight> thenSource, IEitherMonad<TLeft, TRight> elseSource, Func<bool> selector) {
			return new IfStaticCore<TLeft, TRight>(thenSource, elseSource, selector);
		}
	}
}