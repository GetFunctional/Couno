using System.Collections;
using System.Collections.Generic;

namespace Couno.Engine
{
    public sealed class AbilityActionsQueue : IEnumerable<IAbilityToken>
    {
        public AbilityActionsQueue(IAbilityToken rootToken)
        {
            this.Actions = this.CreateAbilityTokenQueue(rootToken);
        }

        private Queue<IAbilityToken> Actions { get; }

        #region IEnumerable<IAbilityToken> Members

        public IEnumerator<IAbilityToken> GetEnumerator()
        {
            return this.Actions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        private Queue<IAbilityToken> CreateAbilityTokenQueue(IAbilityToken rootToken)
        {
            var queue = new Queue<IAbilityToken>();

            queue.Enqueue(rootToken);

            var currentToken = rootToken;
            while (currentToken.Descendant != null)
            {
                currentToken = currentToken.Descendant;
                queue.Enqueue(currentToken);
            }

            return queue;
        }
    }
}