using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class DoOnValueCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Action<T> _action;
			public DoOnValueCore(IOptionMonad<T> self, Action<T> action ) {
				_self = self;
				_action = action;
			}
			public IOptionResult<T> Run() {
				IOptionResult<T> result = _self.Run();
				if(!result.IsNone) _action(result.Value);
				return result;
			}
		}
		public static IOptionMonad<T> DoOnValue<T>(this IOptionMonad<T> self, Action<T> action) {
			return new DoOnValueCore<T>(self, action);
		}
	}
}