using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Writer {
		private class SelectManyCore<TOutput, TValue, TResult> : IWriterMonad<TOutput, TResult> {
			IWriterMonad<TOutput, TValue> _self;
			Func<TValue, IWriterMonad<TOutput, TResult>> _selector;
			public SelectManyCore(IWriterMonad<TOutput, TValue> self, Func<TValue, IWriterMonad<TOutput, TResult>> selector) {
				_self = self;
				_selector = selector;
			}
			public WriterResult<TOutput, TResult> Run() {
				WriterResult<TOutput, TValue> result = _self.Run();
				return _selector(result.Value).Run();
			}
		}
		public static IWriterMonad<TOutput, TResult> SelectMany<TOutput, TValue, TResult>(this IWriterMonad<TOutput, TValue> self, Func<TValue, IWriterMonad<TOutput, TResult>> selector) {
			return new SelectManyCore<TOutput, TValue, TResult>(self, selector);
		}

		private class SelectManyCore<TOutput, TFirst, TSecond, TResult> : IWriterMonad<TOutput, TResult> {
			IWriterMonad<TOutput, TFirst> _self;
			Func<TFirst, IWriterMonad<TOutput, TSecond>> _selector;
			Func<TFirst, TSecond, TResult> _projector;
			public SelectManyCore(IWriterMonad<TOutput, TFirst> self, Func<TFirst, IWriterMonad<TOutput, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
				_self = self;
				_selector = selector;
				_projector = projector;
			}
			public WriterResult<TOutput, TResult> Run() {
				WriterResult<TOutput, TFirst> firstResult = _self.Run();
				WriterResult<TOutput, TSecond> secondResult = _selector(firstResult.Value).Run();
				return WriterResult.Create(_projector(firstResult.Value, secondResult.Value), firstResult.Output.Concat(secondResult.Output));
			}
		}
		public static IWriterMonad<TOutput, TResult> SelectMany<TOutput, TFirst, TSecond, TResult>(this IWriterMonad<TOutput, TFirst> self, Func<TFirst, IWriterMonad<TOutput, TSecond>> selector, Func<TFirst, TSecond, TResult> projector) {
			return new SelectManyCore<TOutput, TFirst, TSecond, TResult>(self, selector, projector);
		}
	}
}