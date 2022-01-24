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
	public static class OptionResult {
		public static IOptionResult<T> Just<T> (T value) {
			return new Option.JustResult<T>(value);
		}
		public static IOptionResult<T> None<T> () {
			return new Option.NoneResult<T>();
		}
	}
	public static partial class Option {
		internal struct JustResult<T> : IOptionResult<T> {
			public T Value { private set; get; }
			public bool IsNone { get { return false; } }
			public bool IsJust { get { return true; } }
			public JustResult(T value) {
				Value = value;
			}
		}
		internal struct NoneResult<T> : IOptionResult<T> {
			public static NoneResult<T> Default = new NoneResult<T>();
			public T Value { get { throw new Exception(); } }
			public bool IsNone { get { return true; } }
			public bool IsJust { get { return false; } }
		}
	}
}