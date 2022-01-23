using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		private class DoCore<T> : ITryMonad<T> {
			ITryMonad<T> _self;
			Action<ITryResult<T>> _action;
			public DoCore(ITryMonad<T> self, Action<ITryResult<T>> action) {
				_self = self;
				_action = action;
			}
			public ITryResult<T> Run() {
				ITryResult<T> selfResult;
				try {
					selfResult = _self.Run();
					_action(selfResult);
					return selfResult;
				}
				catch(Exception e) {
					return new Failure<T>(e);
				}
			}
		}
		public static ITryMonad<T> Do<T>(this ITryMonad<T> self, Action<ITryResult<T>> action) {
			return new DoCore<T>(self, action);
		}
	}
}