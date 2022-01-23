using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class AskReturnNoArgumentCore<TEnvironment> : IReaderMonad<TEnvironment, TEnvironment> {
			public AskReturnNoArgumentCore() {

			}
			public TEnvironment Run(TEnvironment environment) {
				return environment;
			}
		}
		public static IReaderMonad<TEnvironment, TEnvironment> Ask<TEnvironment>() {
			return new AskReturnNoArgumentCore<TEnvironment>();
		}

		private class AskReturnEnvironmentSelectCore<TEnvironment> : IReaderMonad<TEnvironment, TEnvironment> {
			Func<TEnvironment, TEnvironment> _selector;
			public AskReturnEnvironmentSelectCore(Func<TEnvironment, TEnvironment> selector) {
				_selector = selector;
			}
			public TEnvironment Run(TEnvironment environment) {
				return _selector(environment);
			}
		}
		public static IReaderMonad<TEnvironment, TEnvironment> Ask<TEnvironment>(Func<TEnvironment, TEnvironment> selector) {
			return new AskReturnEnvironmentSelectCore<TEnvironment>(selector);
		}

		private class AskCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TEnvironment> {
			public AskCore(IReaderMonad<TEnvironment, TValue> self) {

			}
			public TEnvironment Run(TEnvironment environment) {
				return environment;
			}
		}
		public static IReaderMonad<TEnvironment, TEnvironment> Ask<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self) {
			return new AskCore<TEnvironment, TValue>(self);
		}

		private class AskSelectCore<TEnvironment, TValue> : IReaderMonad<TEnvironment, TEnvironment> {
			Func<TEnvironment, TEnvironment> _selector;
			public AskSelectCore(IReaderMonad<TEnvironment, TValue> self, Func<TEnvironment, TEnvironment> selector) {
				_selector = selector;
			}
			public TEnvironment Run(TEnvironment environment) {
				return _selector(environment);
			}
		}
		public static IReaderMonad<TEnvironment, TEnvironment> Ask<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, Func<TEnvironment, TEnvironment> selector) {
			return new AskSelectCore<TEnvironment, TValue>(self, selector);
		}
	}
}