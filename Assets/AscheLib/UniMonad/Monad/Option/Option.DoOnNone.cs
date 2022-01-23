using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class DoOnNoneCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Action _action;
			public DoOnNoneCore(IOptionMonad<T> self, Action action ) {
				_self = self;
				_action = action;
			}
			public IOptionResult<T> Run() {
				IOptionResult<T> result = _self.Run();
				if(result.IsNone) _action();
				return result;
			}
		}
		public static IOptionMonad<T> DoOnNone<T>(this IOptionMonad<T> self, Action action) {
			return new DoOnNoneCore<T>(self, action);
		}
	}
}