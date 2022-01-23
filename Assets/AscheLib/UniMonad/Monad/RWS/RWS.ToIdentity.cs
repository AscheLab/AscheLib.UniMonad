using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		public static IIdentityMonad<RWSResult<TOutput, TState, TValue>> ToIdentity<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state) {
			return self.Share(environment, state);
		}
	}
}