using Cysharp.Threading.Tasks;
using PrefabGenerator;
using UniPresentation.Canvases;
using UniPresentation.View;

namespace UniPresentation.Presenter
{
    public abstract class PresenterBase<T> : IPresenter where T : ViewBase
    {
        public T TargetView;
        private readonly ICanvas _canvas;

        protected PresenterBase(PrefabGenParams prefabGenParams)
        {
            TargetView = PrefabFactory.Create<T>(prefabGenParams.PrefabPath, prefabGenParams.GetCanvasTransform());
            _canvas = prefabGenParams.targetCanvas;
            SetActiveView(false);
        }
        
        protected async UniTask ShowDialogCommonAsync()
        {
            SetActiveTouchBlock(true);
            SetActiveView(true);
            await TargetView.PlayOpenAnimationAsync();
        }
        
        protected async UniTask HideDialogCommonAsync()
        {
            SetActiveTouchBlock(false);
            await TargetView.PlayCloseAnimationAsync();
            SetActiveView(false);
        }
        
        public async UniTask ShowWindowCommonAsync()
        {
            SetActiveView(true);
            await TargetView.PlayOpenAnimationAsync();
        }
        
        public async UniTask HideWindowCommonAsync()
        {
            await TargetView.PlayCloseAnimationAsync();
            SetActiveView(false);
        }

        public void SetActiveView(bool isActive)
        {
            TargetView.gameObject.SetActive(isActive);
        }

        public bool IsViewActive()
        {
            return TargetView.gameObject.activeInHierarchy;
        }

        private void SetActiveTouchBlock(bool isActive)
        {
            if (_canvas.IsTouchBlockEnabled() != isActive)
            {
                _canvas.SetActiveTouchBlockWindow(isActive);
            }
        }

        public virtual void Dispose()
        {
            PrefabDestroyer.Destroy(ref TargetView);
        }
    }
}