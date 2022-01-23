using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class CreateCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			Func<WriterResult<TOutput, TValue>> _func;
			public CreateCore(Func<WriterResult<TOutput, TValue>> func) {
				_func = func;
			}
			public WriterResult<TOutput, TValue> Run() {
				return _func();
			}
		}
		public static IWriterMonad<TOutput, TValue> Create<TOutput, TValue>(Func<WriterResult<TOutput, TValue>> func) {
			return new CreateCore<TOutput, TValue>(func);
		}
	}
}