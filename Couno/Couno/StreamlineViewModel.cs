using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Couno.Engine;

namespace Couno
{
    public class StreamlineViewModel : ViewModelBase
    {

        private readonly ResourceStreamLine _resourceStreamLine;

        public StreamlineViewModel(ResourceStreamLine resourceStreamLine)
        {
            this._resourceStreamLine = resourceStreamLine;
            this.TokenBoards = new ObservableCollection<TokenBoardViewModel>(this.CreateTokenBoardsFrom(resourceStreamLine.StreamlineElements));
        }

        private IEnumerable<TokenBoardViewModel> CreateTokenBoardsFrom(IList<IResourceStreamlineElement> streamlineElements)
        {
            return streamlineElements.Select(x => new TokenBoardViewModel(x));
        }

        public ObservableCollection<TokenBoardViewModel> TokenBoards { get; }
    }
}