using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IReaderMonad<TEnvironment, TValue> {
		TValue Run(TEnvironment environment);
	}
	public static partial class Reader {

	}
}