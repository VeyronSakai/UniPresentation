using System;
using System.Linq.Expressions;
using System.Reflection;
using UniPresentation.Canvases;

namespace UniPresentation.Page
{
    public static class PageFactory<TPage> where TPage : IPage
    {
        private static Func<ICanvasContainer, TPage> _delegateCache;

        public static TPage Create(ICanvasContainer canvasContainer)
        {
            _delegateCache ??= CreateInstanceDelegate();

            return _delegateCache(canvasContainer);
        }

        private static Func<ICanvasContainer, TPage> CreateInstanceDelegate()
        {
            var constructorInfo = typeof(TPage).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(ICanvasContainer)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(ICanvasContainer));

            return Expression.Lambda<Func<ICanvasContainer, TPage>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}