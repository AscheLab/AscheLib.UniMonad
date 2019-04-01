using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IEitherMonad<TLeft, TRight> {
		IEitherResult<TLeft, TRight> RunEither();
	}
	public interface IEitherResult<TLeft, TRight> {
		TLeft Left { get; }
		TRight Right { get; }
		bool IsLeft { get; }
		bool IsRight { get; }
	}

	public static partial class Either {
		private class LeftResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { private set; get; }
			public TRight Right { private set; get; }
			public bool IsLeft { get { return true; } }
			public bool IsRight { get { return false; } }
			public LeftResult(TLeft value) {
				Left = value;
				Right = default(TRight);
			}
		}
		private class RightResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { private set; get; }
			public TRight Right { private set; get; }
			public bool IsLeft { get { return false; } }
			public bool IsRight { get { return true; } }
			public RightResult(TRight value) {
				Left = default(TLeft);
				Right = value;
			}
		}
		private class ThrowableLeftResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
			public TLeft Left { private set; get; }
			public TRight Right { get { throw new Exception(); } }
			public bool IsLeft { get { return true; } }
			public bool IsRight { get { return false; } }
			public ThrowableLeftResult(TLeft value) {
				Left = value;
			}
		}
		private class ThrowableRightResult<TLeft, TRight> : IEitherResult<TLeft, TRight> {
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