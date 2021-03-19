using System;

namespace PensionGame.Core.Common
{
    public static class PipeHelper
    {
		/// <summary>
		/// Pipes 1 functions
		/// </summary>
		public static B Pipe<A, B>(this A obj, Func<A, B> func1) => func1(obj);

		/// <summary>
		/// Pipes 2 functions
		/// </summary>
		public static C Pipe<A, B, C>(this A obj, Func<A, B> func1, Func<B, C> func2) => func2(func1(obj));

		/// <summary>
		/// Pipes 3 functions
		/// </summary>
		public static D Pipe<A, B, C, D>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3) => func3(func2(func1(obj)));

		/// <summary>
		/// Pipes 4 functions
		/// </summary>
		public static E Pipe<A, B, C, D, E>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4) => func4(func3(func2(func1(obj))));

		/// <summary>
		/// Pipes 5 functions
		/// </summary>
		public static F Pipe<A, B, C, D, E, F>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5) => func5(func4(func3(func2(func1(obj)))));

		/// <summary>
		/// Pipes 6 functions
		/// </summary>
		public static G Pipe<A, B, C, D, E, F, G>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6) => func6(func5(func4(func3(func2(func1(obj))))));

		/// <summary>
		/// Pipes 7 functions
		/// </summary>
		public static H Pipe<A, B, C, D, E, F, G, H>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7) => func7(func6(func5(func4(func3(func2(func1(obj)))))));

		/// <summary>
		/// Pipes 8 functions
		/// </summary>
		public static I Pipe<A, B, C, D, E, F, G, H, I>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8) => func8(func7(func6(func5(func4(func3(func2(func1(obj))))))));

		/// <summary>
		/// Pipes 9 functions
		/// </summary>
		public static J Pipe<A, B, C, D, E, F, G, H, I, J>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9) => func9(func8(func7(func6(func5(func4(func3(func2(func1(obj)))))))));

		/// <summary>
		/// Pipes 10 functions
		/// </summary>
		public static K Pipe<A, B, C, D, E, F, G, H, I, J, K>(this A obj, Func<A, B> func1, Func<B, C> func2, Func<C, D> func3, Func<D, E> func4, Func<E, F> func5, Func<F, G> func6, Func<G, H> func7, Func<H, I> func8, Func<I, J> func9, Func<J, K> func10) => func10(func9(func8(func7(func6(func5(func4(func3(func2(func1(obj))))))))));
	}
}
