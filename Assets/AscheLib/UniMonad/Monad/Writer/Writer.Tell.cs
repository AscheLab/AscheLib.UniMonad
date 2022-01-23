using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class TellCore<TOutput> : IWriterMonad<TOutput, Unit> {
			TOutput _output;
			public TellCore(TOutput output) {
				_output = output;
			}
			public WriterResult<TOutput, Unit> Run() {
				return WriterResult.Create(Unit.Default, new TOutput[1] { _output });
			}
		}
		public static IWriterMonad<TOutput, Unit> Tell<TOutput>(TOutput output) {
			return new TellCore<TOutput>(output);
		}

		private class TellCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			TValue _value;
			TOutput _output;
			public TellCore(TValue value, TOutput output) {
				_value = value;
				_output = output;
			}
			public WriterResult<TOutput, TValue> Run() {
				return WriterResult.Create(_value, new TOutput[1] { _output });
			}
		}
		public static IWriterMonad<TOutput, TValue> Tell<TOutput, TValue>(TValue value, TOutput output) {
			return new TellCore<TOutput, TValue>(value, output);
		}

		private class TellEnumerableCore<TOutput, TValue> : IWriterMonad<TOutput, TValue> {
			TValue _value;
			IEnumerable<TOutput> _outputs;
			public TellEnumerableCore(TValue value, IEnumerable<TOutput> outputs) {
				_value = value;
				_outputs = outputs;
			}
			public WriterResult<TOutput, TValue> Run() {
				return WriterResult.Create(_value, _outputs);
			}
		}
		public static IWriterMonad<TOutput, TValue> Tell<TOutput, TValue>(TValue value, IEnumerable<TOutput> outputs) {
			return new TellEnumerableCore<TOutput, TValue>(value, outputs);
		}
	}
}