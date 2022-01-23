using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Reader {
		public static IIdentityMonad<TValue> ToIdentity<TEnvironment, TValue>(this IReaderMonad<TEnvironment, TValue> self, TEnvironment environment) {
			return self.Share(environment);
		}
	}
}