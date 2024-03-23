using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private Database database;

        [SetUp]
        public void SetUp()
        {
            person = new Person(20200312, "Denis");
            database = new Database(person);
        }

        [TestCase(202020, "JoniGotiniq")]
        public void ConstructorForPerson_ShouldAcceptRightValues(long id, string name)
        {
            person = new Person(id, name);
            Assert.AreEqual(id, person.Id);
            Assert.AreEqual(name, person.UserName);
        }

        [Test]
        public void ConstructorForDatabase_ShouldAcceptRightValues()
        {
            person = new Person(201201, "Sashkoo");
            Person person2 = new Person(12310, "Denis");
            Person person3 = new Person(201312, "Behatov");
            database = new Database(person, person2, person3);
            Assert.AreEqual(3, database.Count);
        } 
        [Test]
        public void AddMethod_ShouldThrowInvalidException_IfItIsGivenSameUsernameTwice()
        {
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>(() =>
            {
                database.Add(new Person(20202010, "Denis"));
            });

            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void AddMethod_ShouldThrowInvalidException_IfItIsGivenSameIdTwice()
        {
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>(() =>
            {
                database.Add(new Person(20200312, "Aleko"));
            });

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void RemoveMethod_ShouldRemoveLastPersonSuccessfully()
        {
            database.Add(new Person(202012032103, "Sasho"));
            database.Remove();
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void RemoveMethod_ShouldThrowExceptionIfEmpty()
        {
            database.Remove();
            Assert.Catch<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }
        [Test]
        public void FindByUsernameMethod_ShouldThrowExceptionIfNoUserIsPresentByThatUsername()
        {
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>(() =>
            {
                database.FindByUsername("Sasho");
            });

            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [TestCase("")]
        public void FindByUsernameMethod_ShouldThrowExceptionIfParameterIsNull(string test)
        {
            ArgumentNullException exception = Assert.Catch<ArgumentNullException>(() =>
            {
                database.FindByUsername(test);
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'Username parameter is null!')", exception.Message);
        }

        [TestCase(21)]
        [TestCase(1)]
        [TestCase(501)]
        public void FindByIdMethod_ShouldThrowExceptionIfThereIsNoSuchId(long id)
        {
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>(() =>
            {
                database.FindById(id);
            });

            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }

        [TestCase(-2000)]
        [TestCase(-31023)]
        [TestCase(-21031203)]
        public void FindByIdMethod_ShouldThrowExceptionIfNegativeIdIsGiven(long id)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(id);
            });

        }

        [Test]
        public void AddPerson_ShouldThrowExceptionIfCountIsEqualOrBiggerThanSixteen()
        {
            Person[] persons =
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Ivan_Ivan"),
                new Person(4, "Pesho_ivanov"),
                new Person(5, "Gosho_Naskov"),
                new Person(6, "Pesh-Peshov"),
                new Person(7, "Ivan_Kaloqnov"),
                new Person(8, "Ivan_Draganchov"),
                new Person(9, "Asen"),
                new Person(10, "Jivko"),
                new Person(11, "Toshko"),
                new Person(12, "Moshko"),
                new Person(13, "Foshko"),
                new Person(14, "Loshko"),
                new Person(15, "Roshko"),
                new Person(16, "Boshko"),
                new Person(17, "Kokoshko")
            };


            InvalidOperationException exception = Assert.Catch<InvalidOperationException>(() =>
            {
                foreach (var guy in persons)
                {
                    database.Add(guy);
                }
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }
    }
}