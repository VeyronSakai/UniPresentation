using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace UniPresentation.Canvases
{
    public static class CanvasContainerFactory<T> where T : ICanvasContainer
    {
        private static Func<List<ICanvas>, T> _delegateCache;

        public static T Create(List<ICanvas> canvasList)
        {
            _delegateCache ??= CreateInstanceDelegate();

            return _delegateCache(canvasList);
        }

        private static Func<List<ICanvas>, T> CreateInstanceDelegate()
        {
            var constructorInfo = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(List<ICanvas>)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(List<ICanvas>));

            return Expression.Lambda<Func<List<ICanvas>, T>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}