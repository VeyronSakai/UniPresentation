using System;

namespace UniPresentation.Presenter
{
    public interface IPresenter : IDisposable
    {
        void SetActiveView(bool isActive);
    }
}