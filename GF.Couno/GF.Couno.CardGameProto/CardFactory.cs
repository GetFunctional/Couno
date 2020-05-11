using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GF.Couno.CardGameProto
{
    public class CardFactory
    {
        internal Card CreateCard(CardType cardType, int value)
        {
            return new Card(cardType, value);
        }

        public Card CreateCard(string cardName)
        {
            var color = cardName[0].ToString().ToUpper();
            var cardValue = string.Concat(cardName.Skip(1).Take(3));
            var value = int.Parse(cardValue);

            switch (color)
            {
                case "R":
                    return CreateCard(CardType.Red, value);
                case "B":
                    return CreateCard(CardType.Blue, value);
                case "Y":
                    return CreateCard(CardType.Yellow, value);
                case "G":
                    return CreateCard(CardType.Green, value);

                default:
                    throw new ArgumentException("color");
            }
        }

        public IList<Card> CreateCardSequence(int amountOfCardsEachColor)
        {
            var colors = new string[] { "R", "B", "Y", "G" };
            var cardsToProduce = new List<string>();

            foreach (var color in colors)
            {
                var cardValue = 1;

                for (int cardNo = 0; cardNo < amountOfCardsEachColor; cardNo++)
                {
                    cardsToProduce.Add(color + cardValue++);
                }
            }

            return cardsToProduce.Select(CreateCard).ToList();
        }
    }
}