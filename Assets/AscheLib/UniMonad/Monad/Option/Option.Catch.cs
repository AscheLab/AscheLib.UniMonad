using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class CatchCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Func<IOptionMonad<T>> _selector;
			public CatchCore(IOptionMonad<T> self, Func<IOptionMonad<T>> selector) {
				_self = self;
				_selector = selector;
			}
			public IOptionResult<T> Run() {
				IOptionResult<T> result = _self.Run();
				if(!result.IsNone) return result;
				return _selector().Run();
			}
		}		
		public static IOptionMonad<T> Catch<T>(this IOptionMonad<T> self, Func<IOptionMonad<T>> selector) {
			return new CatchCore<T>(self, selector);
		}
	}
}