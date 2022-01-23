using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IOptionMonad<T> {
		IOptionResult<T> Run();
	}
	public interface IOptionResult<T> {
		T Value { get; }
		bool IsNone { get; }
		bool IsJust { get; }
	}

	public static partial class Option {
		private struct JustResult<T> : IOptionResult<T> {
			public T Value { private set; get; }
			public bool IsNone { get { return false; } }
			public bool IsJust { get { return true; } }
			public JustResult(T value) {
				Value = value;
			}
		}
		private struct NoneResult<T> : IOptionResult<T> {
			public static NoneResult<T> Default = new NoneResult<T>();
			public T Value { get { throw new Exception(); } }
			public bool IsNone { get { return true; } }
			public bool IsJust { get { return false; } }
		}
	}
}