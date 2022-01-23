using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class State {
		private class ShareCore<TState, TValue> : IIdentityMonad<StateResult<TState, TValue>> {
			IStateMonad<TState, TValue> _self;
			TState _state;
			Lazy<StateResult<TState, TValue>> _lazy;
			public ShareCore(IStateMonad<TState, TValue> self, TState state) {
				_self = self;
				_state = state;
				_lazy = Lazy.Create<StateResult<TState, TValue>>(RunSelf);
			}
			public StateResult<TState, TValue> Run() {
				return _lazy.Value;
			}
			StateResult<TState, TValue> RunSelf() {
				return _self.Run(_state);
			}
		}
		public static IIdentityMonad<StateResult<TState, TValue>> Share<TState, TValue>(this IStateMonad<TState, TValue> self, TState state) {
			return new ShareCore<TState, TValue>(self, state);
		}
	}
}