using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IIdentityMonad<T> {
		T Run();
	}
	public static partial class Identity {

	}
}