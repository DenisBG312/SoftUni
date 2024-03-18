using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(6, 2);
            dummy = new Dummy(10, 20);
        }
        [Test]
        public void Dummy_ShouldLoseHealth()
        {
            axe.Attack(dummy);

            Assert.AreEqual(dummy.Health, 4);
        }

        [Test]
        public void DeadDummy_ShouldThrowException()
        {
            dummy = new Dummy(-10, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }

        [Test]
        public void DeadDummy_CanGiveXP()
        {
            dummy = new Dummy(-10, 10);

            Assert.AreEqual(dummy.GiveExperience(), 10);
        }

        [Test]
        public void DeadDummy_CannotGiveXP()
        {
            dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}