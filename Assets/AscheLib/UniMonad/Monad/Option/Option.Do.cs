using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class DoCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Action<IOptionResult<T>> _action;
			public DoCore(IOptionMonad<T> self, Action<IOptionResult<T>> action) {
				_self = self;
				_action = action;
			}
			public IOptionResult<T> Run() {
				IOptionResult<T> result = _self.Run();
				_action(result);
				return result;
			}
		}
		public static IOptionMonad<T> Do<T>(this IOptionMonad<T> self, Action<IOptionResult<T>> action) {
			return new DoCore<T>(self, action);
		}
	}
}