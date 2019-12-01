using System.Collections.Generic;

namespace Couno.Engine
{
    public class Card
    {
        public string Name { get; }

        public IList<Effect> Effects { get; }
    }

    public class Character
    {

        public string Name { get;  }

        public int Life { get; private set; }

    }

    public class ChakraBoard
    {

        public Character Owner { get; }

        private ICollection<ChakraNode> Nodes { get; }
    }

    internal class ChakraNode
    {

        public string Name { get; }

        public IList<Effect> Effects { get; }

        public ICollection<ChakraNode> Childs { get; }
    }


    public class Player
    {
        public CardDeck DrawDeck { get;  }

        public CardDeck DiscardPile { get; }

        public CardDeck LostPile { get; }

        public Party Party { get; set; }

    }

    public class Party
    {
        // List of Characters

    }

    public class CardDeck
    {
        // Stack of Cards
        // Draw
        // Put
        // Shuffle
    }

}
