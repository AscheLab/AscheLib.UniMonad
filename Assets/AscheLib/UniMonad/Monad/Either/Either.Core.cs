using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IEitherMonad<TLeft, TRight> {
		IEitherResult<TLeft, TRight> Run();
	}
	public interface IEitherResult<TLeft, TRight> {
		TLeft Left { get; }
		TRight Right { get; }
		bool IsLeft { get; }
		bool IsRight { get; }
	}
	public static class EitherResult {
		public static IEitherResult<TLeft, TRight> Left<TLeft, TRight> (TLeft value) {
			return new Either.LeftResult<TLeft, TRight>(value);
		}
		public static IEitherResult<TLeft, TRight> Right<TLeft, TRight> (TRight value) {
			return new Either.RightResult<TLeft, TRight>(value);
		}
		public static IEitherResult<TLeft, TRight> ThrowableLeft<TLeft, TRight> (TLeft value) {
			return new Either.ThrowableLeftResult<TLeft, TRight>(value);
		}
		public static IEitherResult<TLeft, TRight> ThrowableRight<TLeft, TRight> (TRight value) {
			return new Either.ThrowableRightResult<TLeft, TRight>(value);
		}
	}

	public static partial class Either {
		internal class LeftResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { private set; get; }
			public TRight Right { private set; get; }
			public bool IsLeft { get { return true; } }
			public bool IsRight { get { return false; } }
			public LeftResult(TLeft value) {
				Left = value;
				Right = default(TRight);
			}
		}
		internal class RightResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { private set; get; }
			public TRight Right { private set; get; }
			public bool IsLeft { get { return false; } }
			public bool IsRight { get { return true; } }
			public RightResult(TRight value) {
				Left = default(TLeft);
				Right = value;
			}
		}
		internal class ThrowableLeftResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { private set; get; }
			public TRight Right { get { throw new Exception(); } }
			public bool IsLeft { get { return true; } }
			public bool IsRight { get { return false; } }
			public ThrowableLeftResult(TLeft value) {
				Left = value;
			}
		}
		internal class ThrowableRightResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { get { throw new Exception(); } }
			public TRight Right { private set; get; }
			public bool IsLeft { get { return false; } }
			public bool IsRight { get { return true; } }
			public ThrowableRightResult(TRight value) {
				Right = value;
			}
		}
	}
}