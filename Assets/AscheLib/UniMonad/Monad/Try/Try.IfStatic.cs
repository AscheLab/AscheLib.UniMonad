using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class IfStaticCore<T> : ITryMonad<T> {
			ITryMonad<T> _thenSource;
			ITryMonad<T> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(ITryMonad<T> thenSource, ITryMonad<T> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public ITryResult<T> RunTry() {
				try {
					if(_selector()) {
						return _thenSource.RunTry();
					}
					else {
						return _elseSource.RunTry();
					}
				}
				catch(Exception e) {
					return new Failure<T>(e);
				}
			}
		}
		public static ITryMonad<T> If<T>(ITryMonad<T> thenSource, ITryMonad<T> elseSource, Func<bool> selector) {
			return new IfStaticCore<T>(thenSource, elseSource, selector);
		}
	}
}