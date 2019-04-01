using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class IfStaticCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			IWriterMonad<TOutput, TValue> _thenSource;
			IWriterMonad<TOutput, TValue> _elseSource;
			Func<bool> _selector;
			public IfStaticCore(IWriterMonad<TOutput, TValue> thenSource, IWriterMonad<TOutput, TValue> elseSource, Func<bool> selector) {
				_thenSource = thenSource;
				_elseSource = elseSource;
				_selector = selector;
			}
			public WriterResult<TOutput, TValue> RunWriter() {
				if(_selector()) {
					return _thenSource.RunWriter();
				}
				else {
					return _elseSource.RunWriter();
				}
			}
		}
		public static IWriterMonad<TOutput, TValue> If<TOutput, TValue>(IWriterMonad<TOutput, TValue> thenSource, IWriterMonad<TOutput, TValue> elseSource, Func<bool> selector) {
			return new IfStaticCore<TOutput, TValue>(thenSource, elseSource, selector);
		}
	}
}