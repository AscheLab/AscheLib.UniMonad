using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		public static void Execute<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self) {
			self.Run();
		}
		public static void Execute<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self, Action<TValue> onValue) {
			WriterResult<TOutput, TValue> result = self.Run();
			onValue(result.Value);
		}
		public static void Execute<TOutput, TValue>(this IWriterMonad<TOutput, TValue> self, Action<TValue> onValue, Action<IEnumerable<TOutput>> onOutput) {
			WriterResult<TOutput, TValue> result = self.Run();
			onValue(result.Value);
			onOutput(result.Output);
		}
	}
}