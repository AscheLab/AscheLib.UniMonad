using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class IfElseCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			IOptionMonad<T> _elseSource;
			Func<IOptionResult<T>, bool> _selector;
			public IfElseCore(IOptionMonad<T> self, IOptionMonad<T> elseSource, Func<IOptionResult<T>, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public IOptionResult<T> RunOption() {
				IOptionResult<T> result = _self.RunOption();
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.RunOption();
				}
			}
		}
		public static IOptionMonad<T> If<T>(this IOptionMonad<T> self, IOptionMonad<T> elseSource, Func<IOptionResult<T>, bool> selector) {
			return new IfElseCore<T>(self, elseSource, selector);
		}

		private class IfCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _self;
			Func<IOptionResult<T>, bool> _selector;
			public IfCore(IOptionMonad<T> self, Func<IOptionResult<T>, bool> selector) {
				_self = self;
				_selector = selector;
			}
			public IOptionResult<T> RunOption() {
				IOptionResult<T> result = _self.RunOption();
				if(_selector(result)) {
					return result;
				}
				else {
					return NoneResult<T>.Default;
				}
			}
		}
		public static IOptionMonad<T> If<T>(this IOptionMonad<T> self, Func<IOptionResult<T>, bool> selector) {
			return new IfCore<T>(self, selector);
		}
	}
}