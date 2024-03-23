using System;
using System.Data;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 20);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 2, 10, 11, 3, 4, 11 })]
        public void Constructor_ShouldAddValuesProperly(int[] data)
        {
            database = new Database(data);
            int expectedResult = 6;
            int actualResult = database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 20, 11, 2, 4, 2, 1, 1, 1, 2, 3, 7, 4, 3, 2, 9, 9, 1, 1, 1, 10, 200, 2 })]
        public void StoringArrayCapacity_ShouldThrowExceptionIfCountIsEqualOrBiggerThanSixteen(int[] data)
        {
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>((() =>
            {
                database = new Database(data);
            }));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,})]
        public void TheAddMethod_ShouldAddElementAtTheNextCell(int[] data)
        {
            database = new Database(data);
            database.Add(15);
            database.Add(16);
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>(() =>
            {
                database.Add(17);
            });

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void TheRemoveMethod_ShouldRemoveElementsOnlyAtTheLastIndex()
        {
            database.Remove();
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void TheRemoveMethod_ShouldThrowExceptionIfRemoveFromEmptyDatabase()
        {
            database = new Database();
            InvalidOperationException exception = Assert.Catch<InvalidOperationException>((() =>
            {
                database.Remove();
            }));

            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [Test]
        public void TheFetchMethod_ShouldReturnTheElementsOfTheArray()
        {
            int[] coppiedArray = database.Fetch();
            Assert.AreEqual(coppiedArray.Length, database.Count);
        }
    }
}
