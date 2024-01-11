using NUnit.Framework;
using UmaOdisseiaBrasileira.game.model;

namespace UmaOdisseiaBrasileira.test.game.model
{
    public class PlayerTests
    {
        [Test]
        public void ShouldCreatePlayer()
        {
            var player = new Player("Name");

            Assert.That(player == null, Is.False);
        }
    }
}