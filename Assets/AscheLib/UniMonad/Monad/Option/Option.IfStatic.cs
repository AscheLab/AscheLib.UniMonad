using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class IfElseStaticCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _thenSource;
			IOptionMonad<T> _elseSource;
			Func<bool> _selector;
			public IfElseStaticCore(IOptionMonad<T> thenSource, IOptionMonad<T> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public IOptionResult<T> Run() {
				if(_selector()) {
					return _thenSource.Run();
				}
				else {
					return _elseSource.Run();
				}
			}
		}
		public static IOptionMonad<T> If<T>(IOptionMonad<T> thenSource, IOptionMonad<T> elseSource, Func<bool> selector) {
			return new IfElseStaticCore<T>(thenSource, elseSource, selector);
		}

		private class IfStaticCore<T> : IOptionMonad<T> {
			IOptionMonad<T> _thenSource;
			Func<bool> _selector;
			public IfStaticCore(IOptionMonad<T> thenSource, Func<bool> selector) {
				_thenSource = thenSource;
				_selector = selector;
			}
			public IOptionResult<T> Run() {
				if(_selector()) {
					return _thenSource.Run();
				}
				else {
					return NoneResult<T>.Default;
				}
			}
		}
		public static IOptionMonad<T> If<T>(IOptionMonad<T> thenSource, Func<bool> selector) {
			return new IfStaticCore<T>(thenSource, selector);
		}
	}
}