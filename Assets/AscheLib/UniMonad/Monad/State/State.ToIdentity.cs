using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		public static IIdentityMonad<StateResult<TState, TValue>> ToIdentity<TState, TValue> (this IStateMonad<TState, TValue> self, TState state) {
			return self.Share(state);
		}
	}
}