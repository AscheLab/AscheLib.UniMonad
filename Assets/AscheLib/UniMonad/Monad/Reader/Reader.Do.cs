using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class DoCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TValue> {
			IReaderMonad<TEnvironment, TValue> _self;
			Action<TValue> _action;
			public DoCore(IReaderMonad<TEnvironment, TValue> self, Action<TValue> action) {
				_self = self;
				_action = action;
			}
			public TValue Run(TEnvironment environment) {
				TValue result = _self.Run(environment);
				_action(result);
				return result;
			}
		}
		public static IReaderMonad<TEnvironment, TValue> Do<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, Action<TValue> action) {
			return new DoCore<TEnvironment, TValue>(self, action);
		}
	}
}