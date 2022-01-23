using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public interface IIOMonad<T> {
		T Run();
	}
	public static partial class IO {

	}
}