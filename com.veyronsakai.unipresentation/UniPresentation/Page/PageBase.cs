using System;
using System.Collections.Generic;
using UniPresentation.Presenter;
using UniPresentation.Shared.Canvases;
using UniPresentation.View;

namespace UniPresentation.Page
{
    public abstract class PageBase : IPage, IDisposable
    {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        protected PageBase(ICanvasContainer canvasContainer)
        {
        }

        protected TPresenter CreatePresenter<TPresenter, TView>(ICanvas canvas, string prefabPath)
            where TPresenter : PresenterBase<TView>
            where TView : ViewBase
        {
            var prefabGenParams = PrefabGenParamsFactory.Create(canvas, prefabPath);
            var presenter = PresenterFactory<TPresenter, TView>.Create(prefabGenParams);

            _presenters.Add(presenter);

            return presenter;
        }

        protected void ShowPage<TPage, TCanvasContainer>(TCanvasContainer canvasContainer)
            where TPage : IPage
            where TCanvasContainer : ICanvasContainer
        {
            SetActivePage(false);
            PageFactory<TPage, TCanvasContainer>.Create(canvasContainer);
        }

        public virtual void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }

        private void SetActivePage(bool isActive)
        {
            foreach (var presenter in _presenters)
            {
                presenter.SetActiveView(isActive);
            }
        }
    }
}