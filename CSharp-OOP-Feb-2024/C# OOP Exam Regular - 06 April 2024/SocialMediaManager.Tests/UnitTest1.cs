using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private InfluencerRepository repository;
        [SetUp]
        public void Setup()
        {
            repository = new InfluencerRepository();
        }

        [Test]
        public void ConstructorShouldWork()
        {
            Assert.AreEqual(0, repository.Influencers.Count);
        }

        [Test]
        public void RegisterInfluencerNullThrows()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                repository.RegisterInfluencer(null);
            });
        }

        [Test]
        public void RegisterInfluencerNullThrowsIfAlreadyThereIsSameName()
        {
            repository.RegisterInfluencer(new Influencer("Denis", 20));
            Assert.Catch<InvalidOperationException>(() =>
            {
                repository.RegisterInfluencer(new Influencer("Denis", 30));
            });
        }

        [Test]
        public void RegisterInfluencerShouldWorkAsExpected()
        {
            //Successfully added influencer {influencer.Username} with {influencer.Followers}
            Assert.AreEqual("Successfully added influencer Ivan with 10",
                repository.RegisterInfluencer(new("Ivan", 10)));
            Assert.AreEqual(1, repository.Influencers.Count);
        }

        [Test]
        public void RemoveInfluencer_ThrowsIfNull()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                repository.RemoveInfluencer(null);
            });
        }

        [Test]
        public void RemoveInfluencer_ThrowsIfWhitespace()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                repository.RemoveInfluencer(" ");
            });
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnFalse()
        {
            Assert.IsFalse(repository.RemoveInfluencer("Denis"));
        }

        [Test]
        public void RemoveInfluencer_ShouldReturnTrue()
        {
            repository.RegisterInfluencer(new("Denis", 20));
            Assert.AreEqual(1, repository.Influencers.Count);
            Assert.IsTrue(repository.RemoveInfluencer("Denis"));
            Assert.AreEqual(0, repository.Influencers.Count);
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ShouldWork()
        {
            repository.RegisterInfluencer(new("Denis", 20));
            repository.RegisterInfluencer(new("Ivan", 50));
            repository.RegisterInfluencer(new("Georgi",90));
            repository.RegisterInfluencer(new("Misho", 60));

            Influencer influencer = repository.GetInfluencerWithMostFollowers();
            Assert.AreEqual("Georgi", influencer.Username);
        }

        [Test]
        public void GetInfluencer_ShouldReturnRight()
        {
            repository.RegisterInfluencer(new("Denis", 20));
            repository.RegisterInfluencer(new("Ivan", 50));
            repository.RegisterInfluencer(new("Georgi", 90));
            repository.RegisterInfluencer(new("Misho", 60));

            Influencer influencer = repository.GetInfluencer("Denis");
            Assert.AreEqual("Denis", influencer.Username);
        }
    }
}