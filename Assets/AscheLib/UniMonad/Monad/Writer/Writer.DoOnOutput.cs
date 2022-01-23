using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class DoOnOutputCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			IWriterMonad<TOutput, TValue> _self;
			Action<IEnumerable<TOutput>> _action;
			public DoOnOutputCore(IWriterMonad<TOutput, TValue> self, Action<IEnumerable<TOutput>> action) {
				_self = self;
				_action = action;
			}
			public WriterResult<TOutput, TValue> Run() {
				WriterResult<TOutput, TValue> result = _self.Run();
				_action(result.Output);
				return result;
			}
		}
		public static IWriterMonad<TOutput, TValue> DoOnOutput<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self, Action<IEnumerable<TOutput>> action) {
			return new DoOnOutputCore<TOutput, TValue>(self, action);
		}
	}
}