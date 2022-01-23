using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		private class ShareCore<TEnvironment, TValue> : IIdentityMonad<TValue> {
			IReaderMonad<TEnvironment, TValue> _self;
			TEnvironment _environment;
			Lazy<TValue> _lazy;
			public ShareCore(IReaderMonad<TEnvironment, TValue> self, TEnvironment environmen) {
				_self = self;
				_environment = environmen;
				_lazy = Lazy.Create<TValue>(RunSelf);
			}
			public TValue Run() {
				return _lazy.Value;
			}
			TValue RunSelf() {
				return _self.Run(_environment);
			}
		}
		public static IIdentityMonad<TValue> Share<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, TEnvironment environment) {
			return new ShareCore<TEnvironment, TValue>(self, environment);
		}
	}
}