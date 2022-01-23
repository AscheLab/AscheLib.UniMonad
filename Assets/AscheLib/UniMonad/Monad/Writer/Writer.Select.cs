using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class SelectCore<TOutput, TValue, TResult> : IWriterMonad<TOutput, TResult> {
			IWriterMonad<TOutput, TValue> _self;
			Func<TValue, TResult> _selector;
			public SelectCore(IWriterMonad<TOutput, TValue> self, Func<TValue, TResult> selector) {
				_self = self;
				_selector = selector;
			}
			public WriterResult<TOutput, TResult> Run() {
				WriterResult<TOutput, TValue> result = _self.Run();
				return WriterResult.Create(_selector(result.Value), result.Output);
			}
		}
		public static IWriterMonad<TOutput, TResult> Select<TOutput, TValue, TResult>(this IWriterMonad<TOutput, TValue> self, Func<TValue, TResult> selector) {
			return new SelectCore<TOutput, TValue, TResult>(self, selector);
		}
	}
}