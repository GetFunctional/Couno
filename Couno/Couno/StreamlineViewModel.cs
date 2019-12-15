using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Couno.Engine;
using Couno.Shared.Mvvm;

namespace Couno
{
    public class StreamlineViewModel : ViewModelBase
    {
        private bool _canExecute;

        public StreamlineViewModel(ResourceStreamLine resourceStreamLine, ICommand executeStreamlineCommand)
        {
            this.StreamLine = resourceStreamLine;
            this.StreamlineElements =
                new ObservableCollection<ResourceStreamlineElementViewModel>(
                    this.CreateTokenBoardsFrom(resourceStreamLine.StreamlineElements));
            this.UseStreamlineCommand = executeStreamlineCommand;
        }
        
        public ObservableCollection<ResourceStreamlineElementViewModel> StreamlineElements { get; }

        public ICommand UseStreamlineCommand { get; }

        public ResourceStreamLine StreamLine { get; }

        public bool CanExecute
        {
            get { return this._canExecute; }
            set { this.SetField(ref this._canExecute, value); }
        }

        private IEnumerable<ResourceStreamlineElementViewModel> CreateTokenBoardsFrom(
            IList<IResourceStreamlineElement> streamlineElements)
        {
            return streamlineElements.Select(this.CreateMatchingResourceStreamlineElementViewModel);
        }

        private ResourceStreamlineElementViewModel CreateMatchingResourceStreamlineElementViewModel(
            IResourceStreamlineElement resourceStreamlineElement)
        {
            if (resourceStreamlineElement is TokenBoard tb)
            {
                return new TokenBoardViewModel(tb);
            }

            if (resourceStreamlineElement is ResourceGenerator rg)
            {
                return new ResourceGeneratorViewModel(rg);
            }

            throw new NotImplementedException();
        }
    }
}