using System.Collections.Generic;
using GF.Couno.Core.CardSysten;
using NUnit.Framework;

namespace GF.Couno.Core.Unittests.CardSystemTests
{
    [TestFixture]
    internal class CardTests
    {
        [Test]
        public void Card_Setup_Test()
        {
            // Arrange + Act
            var card = new Card(new List<CardEffect>(), new CardCost());

            // Assert
            Assert.That(card.CardCost.TotalResourceCost, Is.Not.Null);
            Assert.That(card.CardEffects, Is.Not.Null);
        }
    }
}