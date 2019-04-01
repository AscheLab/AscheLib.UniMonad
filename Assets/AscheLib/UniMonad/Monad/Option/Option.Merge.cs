using System;
using System.Collections.Generic;
using System.Linq;

namespace AscheLib.UniMonad {
	public static partial class Option {
		private class MergeCore<T> : IOptionMonad<T[]> {
			IOptionMonad<T>[] _sources;
			public MergeCore(IOptionMonad<T>[] sources) {
				_sources = sources;
			}
			public IOptionResult<T[]> RunOption() {
				List<IOptionResult<T>> resultList = _sources.Select(source => source.RunOption()).ToList();
				if(resultList.All(result => !result.IsNone)) return new JustResult<T[]>(resultList.Select(result => result.Value).ToArray());
				return NoneResult<T[]>.Default;
			}
		}
		public static IOptionMonad<T[]> Merge<T>(this IOptionMonad<T> self, params IOptionMonad<T>[] sources) {
			List<IOptionMonad<T>> mergeList = new List<IOptionMonad<T>>() { self };
			return Merge(mergeList.Concat(sources));
		}
		public static IOptionMonad<T[]> Merge<T>(IEnumerable<IOptionMonad<T>> sources) {
			return Merge(sources.ToArray());
		}
		public static IOptionMonad<T[]> Merge<T>(params IOptionMonad<T>[] sources) {
			return new MergeCore<T>(sources);
		}
	}
}