using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IWriterMonad<TOutput, TValue> {
		WriterResult<TOutput, TValue> Run();
	}
	public struct WriterResult<TOutput, TValue> {
		public TValue Value { private set; get; }
		public IEnumerable<TOutput> Output { private set; get; }

		public WriterResult(TValue value, IEnumerable<TOutput> output) {
			Value = value;
			Output = output;
		}
	}

	public static class WriterResult {
		public static WriterResult<TOutput, TValue> Create<TOutput, TValue>(TValue value, IEnumerable<TOutput> output) {
			return new WriterResult<TOutput, TValue>(value, output);
		}
	}

	public static partial class Writer {

	}
}