using Cysharp.Threading.Tasks;
using PrefabGenerator;
using UniPresentation.Canvases;
using UniPresentation.View;

namespace UniPresentation.Presenter
{
    public abstract class PresenterBase<T> : IPresenter where T : ViewBase
    {
        public T TargetView;
        private readonly ICanvas _appCanvas;

        protected PresenterBase(PrefabGenParams prefabGenParams)
        {
            TargetView = PrefabFactory.Create<T>(prefabGenParams.PrefabPath, prefabGenParams.GetCanvasTransform());
            _appCanvas = prefabGenParams.AppCanvas;
            SetActiveView(false);
        }

        /// <summary>
        /// Dialogを開く際の共通処理
        /// </summary>
        protected async UniTask ShowDialogCommonAsync()
        {
            SetActiveTouchBlock(true);
            SetActiveView(true);
            await TargetView.PlayOpenAnimationAsync();
        }

        /// <summary>
        /// Dialogを閉じる際の共通処理
        /// </summary>
        protected async UniTask HideDialogCommonAsync()
        {
            SetActiveTouchBlock(false);
            await TargetView.PlayCloseAnimationAsync();
            SetActiveView(false);
        }

        /// <summary>
        /// Windowを開く
        /// </summary>
        public async UniTask ShowWindowCommonAsync()
        {
            SetActiveView(true);
            await TargetView.PlayOpenAnimationAsync();
        }

        /// <summary>
        /// Windowを閉じる
        /// </summary>
        public async UniTask HideWindowCommonAsync()
        {
            await TargetView.PlayOpenAnimationAsync();
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
            if (_appCanvas.IsTouchBlockEnabled() != isActive)
            {
                _appCanvas.SetActiveTouchBlockWindow(isActive);
            }
        }

        public virtual void Dispose()
        {
            PrefabDestroyer.Destroy(ref TargetView);
        }
    }
}