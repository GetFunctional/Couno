using GF.Couno.Core.FightSystem;
using GF.Couno.Core.FightSystem.Ai;
using GF.Couno.Core.FightSystem.Player;
using NUnit.Framework;

namespace GF.Couno.Core.Unittests.FightSystemTests
{
    [TestFixture]
    internal class FightTests
    {
        [Test]
        public void Fight_Setup_Test()
        {
            // Arrange + Act
            var fight = new Fight(new PlayerFightParticipant(), new AiFightParticipant());

            // Assert
            Assert.That(fight.TurnNumber, Is.EqualTo(1));
            Assert.That(fight.Player, Is.Not.Null);
            Assert.That(fight.Enemy, Is.Not.Null);
        }
    }
}