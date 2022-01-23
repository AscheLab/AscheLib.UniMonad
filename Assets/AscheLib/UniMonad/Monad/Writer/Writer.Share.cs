using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class ShareCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			IWriterMonad<TOutput, TValue> _self;
			Lazy<WriterResult<TOutput, TValue>> _lazy;
			public ShareCore(IWriterMonad<TOutput, TValue> self) {
				_self = self;
				_lazy = Lazy.Create<WriterResult<TOutput, TValue>>(RunSelf);
			}
			public WriterResult<TOutput, TValue> Run() {
				return _lazy.Value;
			}
			WriterResult<TOutput, TValue> RunSelf() {
				return _self.Run();
			}
		}
		public static IWriterMonad<TOutput, TValue> Share<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self) {
			return new ShareCore<TOutput, TValue>(self);
		}
	}
}