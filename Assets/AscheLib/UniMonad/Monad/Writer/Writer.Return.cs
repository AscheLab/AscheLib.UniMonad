using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class ReturnCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			TValue _value;
			public ReturnCore(TValue value) {
				_value = value;
			}
			public WriterResult<TOutput, TValue> RunWriter() {
				return WriterResult.Create(_value, new TOutput[0]);
			}
		}
		public static IWriterMonad<TOutput, TValue> Return<TOutput, TValue>(TValue value) {
			return new ReturnCore<TOutput, TValue>(value);
		}
	}
}