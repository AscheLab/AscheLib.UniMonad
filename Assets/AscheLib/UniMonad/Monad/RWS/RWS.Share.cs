using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class RWS {
		private class ShareCore<TEnvironment, TOutput, TState, TValue> : IIdentityMonad<RWSResult<TOutput, TState, TValue>> {
			IRWSMonad<TEnvironment, TOutput, TState, TValue> _self;
			TEnvironment _environment;
			TState _state;
			Lazy<RWSResult<TOutput, TState, TValue>> _lazy;
			public ShareCore(IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state) {
				_self = self;
				_environment = environment;
				_state = state;
				_lazy = Lazy.Create<RWSResult<TOutput, TState, TValue>>(RunSelf);
			}
			public RWSResult<TOutput, TState, TValue> RunIdentity() {
				return _lazy.Value;
			}
			RWSResult<TOutput, TState, TValue> RunSelf() {
				return _self.RunRWS(_environment, _state);
			}
		}
		public static IIdentityMonad<RWSResult<TOutput, TState, TValue>> Share<TEnvironment, TOutput, TState, TValue>(this IRWSMonad<TEnvironment, TOutput, TState, TValue> self, TEnvironment environment, TState state) {
			return new ShareCore<TEnvironment, TOutput, TState, TValue>(self, environment, state);
		}
	}
}