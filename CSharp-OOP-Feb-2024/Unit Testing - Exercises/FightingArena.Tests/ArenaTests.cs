using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            arena = new();
            warrior = new("Rocky", 100, 200);
        }

        [Test]
        public void Constructor_ShouldAcceptRightValues()
        {
            Assert.AreEqual(arena.Warriors.Count, 0);
        }

        [Test]
        public void CountProperty_ShouldReturnTheCountOfTheWarriors()
        {
            Assert.AreEqual(arena.Count, 0);
        }

        [TestCase("Rocky", 100, 200)]
        public void EnrollMethod_ShouldThrowExceptionIfTheSameWarriorIsAddedTwice(string name, int damage, int hp)
        {
            arena.Enroll(warrior);
            Assert.Catch<InvalidOperationException>(() => { arena.Enroll(new(name, damage, hp)); });
        }

        [Test]
        public void FightMethod_AttackerAndDefenderExist_AttackerAttacksDefender()
        {
            Warrior attacker = new Warrior("Attacker", 100, 100);
            Warrior defender = new Warrior("Defender", 90, 90);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            // Assert
            Assert.AreEqual(attacker.HP, 10);
        }

        [TestCase("Alonso", "Rocky")]
        [TestCase("Denis", "Creed")]
        public void AttackMethod_ShouldThrowExceptionIfAttackerNameIsNull(string attackerName, string defenderName)
        {
            arena.Enroll(warrior);
            arena.Enroll(new("Bunny", 20, 60));
            Assert.Catch<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, defenderName);
            });
        }
        [TestCase("Alonso", "Rocky")]
        [TestCase("Denis", "Creed")]
        public void AttackMethod_ShouldThrowExceptionIfDefenderNameIsNull(string attackerName, string defenderName)
        {
            arena.Enroll(warrior);
            arena.Enroll(new("Bunny", 20, 60));
            Assert.Catch<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName, defenderName);
            });
        }
    }
}
