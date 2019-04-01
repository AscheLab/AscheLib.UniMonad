using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface ITryMonad<T> {
		ITryResult<T> RunTry();
	}
	public interface ITryResult<T> {
		T Value { get; }
		Exception Exception { get; }
		bool IsFaulted { get; }
		bool IsSucceeded { get; }
	}
	public static partial class Try {
		private class Success<T> : ITryResult<T> {
			public T Value { private set; get; }
			public Exception Exception { private set; get; }
			public Success(T value) {
				Value = value;
				Exception = null;
			}
			public bool IsFaulted { get { return false; } }
			public bool IsSucceeded { get { return true; } }
			public override string ToString() {
				return Value != null ? Value.ToString() : "[null]";
			}
		}
		private class Failure<T> : ITryResult<T> {
			public T Value { private set; get; }
			public Exception Exception { private set; get; }
			public Failure(Exception exception) {
				Value = default(T);
				Exception = exception;
			}
			public bool IsFaulted { get { return true; } }
			public bool IsSucceeded { get { return false; } }
			public override string ToString() {
				return Exception.ToString();
			}
		}
	}
}