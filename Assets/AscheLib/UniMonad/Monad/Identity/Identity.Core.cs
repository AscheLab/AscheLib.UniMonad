using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IIdentityMonad<T> {
		T RunIdentity();
	}
	public static partial class Identity {

	}
}