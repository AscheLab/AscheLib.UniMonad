using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class DoOnValueCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			IWriterMonad<TOutput, TValue> _self;
			Action<TValue> _action;
			public DoOnValueCore(IWriterMonad<TOutput, TValue> self, Action<TValue> action) {
				_self = self;
				_action = action;
			}
			public WriterResult<TOutput, TValue> RunWriter() {
				WriterResult<TOutput, TValue> result = _self.RunWriter();
				_action(result.Value);
				return result;
			}
		}
		public static IWriterMonad<TOutput, TValue> DoOnValue<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self, Action<TValue> action) {
			return new DoOnValueCore<TOutput, TValue>(self, action);
		}
	}
}