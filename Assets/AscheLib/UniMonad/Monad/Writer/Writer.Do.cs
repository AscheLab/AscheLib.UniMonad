using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class DoCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			IWriterMonad<TOutput, TValue> _self;
			Action<WriterResult<TOutput, TValue>> _action;
			public DoCore(IWriterMonad<TOutput, TValue> self, Action<WriterResult<TOutput, TValue>> action) {
				_self = self;
				_action = action;
			}
			public WriterResult<TOutput, TValue> RunWriter() {
				WriterResult<TOutput, TValue> result = _self.RunWriter();
				_action(result);
				return result;
			}
		}
		public static IWriterMonad<TOutput, TValue> Do<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self, Action<WriterResult<TOutput, TValue>> action) {
			return new DoCore<TOutput, TValue>(self, action);
		}
	}
}