using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class ToIdentityCore<TOutput, TValue> : IIdentityMonad<WriterResult<TOutput, TValue>> {
			IWriterMonad<TOutput, TValue> _self;
			Lazy<WriterResult<TOutput, TValue>> _lazy;
			public ToIdentityCore (IWriterMonad<TOutput, TValue> self) {
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
		public static IIdentityMonad<WriterResult<TOutput, TValue>> ToIdentity<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self) {
			return new ToIdentityCore<TOutput, TValue>(self);
		}
	}
}