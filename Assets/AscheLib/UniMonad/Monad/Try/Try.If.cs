using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class IfCore<T> : ITryMonad<T> {
			ITryMonad<T> _self;
			ITryMonad<T> _elseSource;
			Func<ITryResult<T>, bool> _selector;
			public IfCore(ITryMonad<T> self, ITryMonad<T> elseSource, Func<ITryResult<T>, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public ITryResult<T> RunTry() {
				ITryResult<T> selfResult;
				try {
					selfResult = _self.RunTry();
					if(_selector(selfResult)) {
						return selfResult;
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
		public static ITryMonad<T> If<T>(this ITryMonad<T> self, ITryMonad<T> elseSource, Func<ITryResult<T>, bool> selector) {
			return new IfCore<T>(self, elseSource, selector);
		}
	}
}