using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class IfCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			IWriterMonad<TOutput, TValue> _self;
			IWriterMonad<TOutput, TValue> _elseSource;
			Func<WriterResult<TOutput, TValue>, bool> _selector;
			public IfCore(IWriterMonad<TOutput, TValue> self, IWriterMonad<TOutput, TValue> elseSource, Func<WriterResult<TOutput, TValue>, bool> selector) {
				_self = self;
				_elseSource = elseSource;
				_selector = selector;
			}
			public WriterResult<TOutput, TValue> RunWriter() {
				WriterResult<TOutput, TValue> result = _self.RunWriter();
				if(_selector(result)) {
					return result;
				}
				else {
					return _elseSource.RunWriter();
				}
			}
		}
		public static IWriterMonad<TOutput, TValue> If<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self, IWriterMonad<TOutput, TValue> elseSource, Func<WriterResult<TOutput, TValue>, bool> selector) {
			return new IfCore<TOutput, TValue>(self, elseSource, selector);
		}
	}
}