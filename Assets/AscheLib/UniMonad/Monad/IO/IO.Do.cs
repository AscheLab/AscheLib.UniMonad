using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class IO {
		private class DoCore<T> : IIOMonad<T> {
			IIOMonad<T> _self;
			Action<T> _action;
			public DoCore(IIOMonad<T> self, Action<T> action) {
				_self = self;
				_action = action;
			}
			public T Run() {
				T result = _self.Run();
				_action(result);
				return result;
			}
		}
		public static IIOMonad<T> Do<T>(this IIOMonad<T> self, Action<T> action) {
			return new DoCore<T>(self, action);
		}
	}
}