using System;
using System.Linq.Expressions;
using System.Reflection;
using UniPresentation.Canvases;

namespace UniPresentation.Page
{
    public static class PageFactory<TPage> where TPage : IPage
    {
        private static Func<CanvasContainer, TPage> _delegateCache;

        public static TPage Create(CanvasContainer canvasContainer)
        {
            _delegateCache ??= CreateInstanceDelegate();

            return _delegateCache(canvasContainer);
        }

        private static Func<CanvasContainer, TPage> CreateInstanceDelegate()
        {
            var constructorInfo = typeof(TPage).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(CanvasContainer)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(CanvasContainer));

            return Expression.Lambda<Func<CanvasContainer, TPage>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}