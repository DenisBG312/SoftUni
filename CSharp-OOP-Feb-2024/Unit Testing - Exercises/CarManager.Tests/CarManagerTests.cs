namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("BMW", "M3", 200, 290);
        }

        [TestCase("Audi", "A3", 100, 500)]
        public void Constructor_ShouldApplyRightValues(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car("Audi", "A3", 100, 500);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarFuel_ShouldAlwaysStartAsZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("", "Q7", 102, 400)]
        [TestCase(null, "Q7", 102, 400)]
        public void Make_ThrowsExceptionIfNullOrEmptyInput(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                Car vehicle = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase("Audi", "", 102, 400)]
        [TestCase("Mercedes", null, 102, 400)]
        public void Model_ThrowsExceptionIfNullOrEmptyInput(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase("Volkswagen", "Passat", -2, 500)]
        [TestCase("Volkswagen", "Golf", 0, 500)]
        public void FuelConsumptionMethod_ThrowsExceptionIfValueIsLessOrEqualToZero(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [Test]
        public void FuelAmountMethod_ShouldThrowExceptionIfValueIsLessThanZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("Volkswagen", "Passat", 200, -500)]
        [TestCase("Volkswagen", "Golf", 100, 0)]
        public void FuelCapacityMethod_ThrowsExceptionIfValueIsLessOrEqualToZero(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            });
        }

        [TestCase(20)]
        [TestCase(50)]
        [TestCase(60)]
        public void RefuelMethod_ShouldProperlyRefuel(double fuelToAdd)
        {
            car.Refuel(fuelToAdd);

            Assert.AreEqual(fuelToAdd, car.FuelAmount);
        }

        [TestCase(-10)]
        [TestCase(-20)]
        [TestCase(0)]
        public void RefuelMethod_ShouldThrowExceptionIfValueIsLessOrEqualToZero(double fuelToAdd)
        {
            Assert.Catch<ArgumentException>(() =>
            {
                car.Refuel(fuelToAdd);
            });
        }

        [TestCase(100)]
        [TestCase(40)]
        [TestCase(30)]
        public void DriveMethod_ShouldGetTheRightValueOff(double distance)
        {
            car.Refuel(200);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;

            car.Drive(distance);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfRefuelMoreThanCapacity()
        {
            this.car.Refuel(350);
            int expectedFuel = 290;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [TestCase(100)]
        [TestCase(40)]
        [TestCase(30)]
        public void DriveMethod_ShouldThrowExceptionIfFuelNeededIsBiggerThanFuelAmount(double distance)
        {
            car.Refuel(10);
            double fuelNeeded = (distance / 100) * car.FuelConsumption;
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;
            Assert.Catch<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }
    }
}