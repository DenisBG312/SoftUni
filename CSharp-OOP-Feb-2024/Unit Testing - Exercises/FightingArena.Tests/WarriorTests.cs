using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Internal;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private const int MIN_ATTACK_HP = 30;
        [SetUp]
        public void SetUp()
        {
            warrior = new("Denis", 50, 100);
        }

        [TestCase("Sasho", 60, 100)]
        [TestCase("Aleks", 90, 100)]
        [TestCase("Joni", 10, 100)]
        public void Constructor_ShouldAcceptRightValues(string name, int damage, int hp)
        {
            warrior = new(name, damage, hp);
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase(null, 40, 100)]
        [TestCase("", 60, 100)]
        public void NameProperty_ShouldThrowExceptionIfValueIsNullOrEmpty(string name, int damage, int hp)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                warrior = new(name, damage, hp);
            });
        }

        [TestCase("Aleksi", 0, 100)]
        [TestCase("Denis", -20, 100)]
        public void DamageProperty_ShouldThrowExceptionIfValueIsLessOrEqualToZero(string name, int damage, int hp)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                warrior = new(name, damage, hp);
            });
        }

        [TestCase("Aleksi", 90, -3)]
        [TestCase("Denis", 20, -5)]
        public void HpProperty_ShouldThrowExceptionIfValueIsLessThanZero(string name, int damage, int hp)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                warrior = new(name, damage, hp);
            });
        }

        [TestCase("Arno", 10, 10)]
        [TestCase("Bobi", 20, 29)]
        public void AttackMethod_ShouldThrowExceptionIfValueIsLessThanTheMinConst(string name, int damage, int hp)
        {
            warrior = new(name, damage, hp);
            Assert.Catch<InvalidOperationException>(() =>
            {
                warrior.Attack(new("Denis", 80, 70));
            });
        }

        [TestCase("Alonso", 50, 5)]
        [TestCase("Creed", 100, 20)]
        public void AttackMethod_ShouldThrowExceptionIfEnemyHpIsLessThanTheMinConst(string name, int damage, int hp)
        {
            Assert.Catch<InvalidOperationException>(() =>
            {
                warrior.Attack(new(name, damage, hp));
            });
        }

        [TestCase("Doni", 150, 100)]
        [TestCase("Denis4o", 200, 100)]
        public void AttackMethod_ShouldThrowExceptionIfEnemyIsTooStrong(string name, int damage, int hp)
        {
            Assert.Catch<InvalidOperationException>(() =>
            {
                warrior.Attack(new(name, damage, hp));
            });
        }

        [TestCase("Rocky", 70, 150)]
        public void AttackMethod_ShouldGetProperHpPoints(string name, int damage, int hp)
        {
            warrior = new("Denis", 80, 200);
            warrior.Attack(new(name, damage, hp));
            int expectedResult = warrior.HP;
            Assert.AreEqual(expectedResult, warrior.HP);
        }

        [TestCase("Rocky", 100, 200)]
        public void AttackMethod_ShouldSetWarriorHpToZeroIfThisWarriorHasBiggerDamagePointsThanHisHealth(string name, int damage, int hp)
        {
            warrior = new("Denis", 300, 100);
            Warrior warriorTwo = new(name, damage, hp);
            warrior.Attack(warriorTwo);
            Assert.AreEqual(0, warriorTwo.HP);
        }

        [TestCase("Rocky", 60, 200)]
        public void AttackMethod_ShouldCalculateHpProperly(string name, int damage, int hp)
        {
            warrior = new("Denis", 100, 100);
            Warrior warriorTwo = new(name, damage, hp);
            warrior.Attack(warriorTwo);
            Assert.AreEqual(100, warriorTwo.HP);
        }

    }
}