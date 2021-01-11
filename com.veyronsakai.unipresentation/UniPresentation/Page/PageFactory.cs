using System;
using System.Linq.Expressions;
using System.Reflection;
using UniPresentation.Shared.Canvases;

namespace UniPresentation.Page
{
    public static class PageFactory<TPage, TCanvasContainer>
        where TPage : IPage
        where TCanvasContainer : ICanvasContainer
    {
        private static Func<TCanvasContainer, TPage> _delegateCache;

        public static TPage Create(TCanvasContainer canvasContainer)
        {
            _delegateCache ??= CreateInstanceDelegate();

            return _delegateCache(canvasContainer);
        }

        private static Func<TCanvasContainer, TPage> CreateInstanceDelegate()
        {
            var constructorInfo = typeof(TPage).GetConstructor(BindingFlags.Public | BindingFlags.Instance,
                Type.DefaultBinder, new[] {typeof(TCanvasContainer)}, null);

            if (constructorInfo == null) throw new ArgumentNullException();

            var arg = Expression.Parameter(typeof(TCanvasContainer));

            return Expression.Lambda<Func<TCanvasContainer, TPage>>(Expression.New(constructorInfo, arg), arg)
                .Compile();
        }
    }
}