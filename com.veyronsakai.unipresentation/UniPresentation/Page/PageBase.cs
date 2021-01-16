using System;
using System.Collections.Generic;
using UniPresentation.Canvases;
using UniPresentation.Presenter;
using UniPresentation.View;

namespace UniPresentation.Page
{
    public abstract class PageBase : IPage, IDisposable
    {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        protected PageBase(CanvasContainer canvasContainer)
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

        protected void ShowPage<TPage>(CanvasContainer canvasContainer) where TPage : IPage
        {
            SetActivePage(false);
            PageFactory<TPage>.Create(canvasContainer);
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