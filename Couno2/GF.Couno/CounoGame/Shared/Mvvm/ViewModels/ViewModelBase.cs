using CounoGame.Shared.Mvvm.Shared;

namespace CounoGame.Shared.Mvvm.ViewModels
{
    public class ViewModelBase : ObservableObject,IViewModel
    {
        public ViewModelBase()
        {
            
        }


        protected virtual void AddChildViewModel(ViewModelBase viewModelBase)
        {

        }
    }
}