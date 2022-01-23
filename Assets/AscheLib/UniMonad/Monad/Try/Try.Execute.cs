using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Try {
		public static void Execute<T>(this ITryMonad<T> self) {
			ITryResult<T> selfResult;
			try {
				selfResult = self.Run();
				if(selfResult.IsFaulted) {
					return;
				}
				else {
					return;
				}
			}
			catch {
				return;
			}
		}
		public static void Execute<T>(this ITryMonad<T> self, Action<T> onSuccess) {
			ITryResult<T> selfResult;
			try {
				selfResult = self.Run();
				if(selfResult.IsFaulted) {
					throw(selfResult.Exception);
				}
				else {
					onSuccess(selfResult.Value);
					return;
				}
			}
			catch (Exception e) {
				throw(e);
			}
		}
		public static void Execute<T>(this ITryMonad<T> self, Action<T> onSuccess, Action<Exception> onError) {
			ITryResult<T> selfResult;
			try {
				selfResult = self.Run();
				if(selfResult.IsFaulted) {
					onError(selfResult.Exception);
					return;
				}
				else {
					onSuccess(selfResult.Value);
					return;
				}
			}
			catch(Exception e) {
				onError(e);
				return;
			}
		}
		public static void Execute<T, TException>(this ITryMonad<T> self, Action<T> onSuccess, Action<TException> onError) where TException : Exception {
			ITryResult<T> selfResult;
			try {
				selfResult = self.Run();
				if(selfResult.IsFaulted) {
					if(selfResult.Exception is TException) {
						onError(selfResult.Exception as TException);
					}
					return;
				}
				else {
					onSuccess(selfResult.Value);
					return;
				}
			}
			catch(Exception e) {
				if(e is TException) {
					onError(e as TException);
				}
				return;
			}
		}
	}
}