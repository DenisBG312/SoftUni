using System.Linq;

namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(30)]
        [TestCase(10)]
        [TestCase(60)]
        public void Constructor_ShouldApplyRightValues(int memoryCapacity)
        {
            Device device = new(memoryCapacity);
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [TestCase(10, 70)]
        [TestCase(60, 20)]
        [TestCase(29, 51)]
        public void TakePhotoMethod_IfSizeIsLowerThanAvailableMemory_DecreasesAvailableMemory(int photoSize, int expectedAvailableMemory)
        {
            Device device = new Device(80);

            bool success = device.TakePhoto(photoSize);

            Assert.IsTrue(success);
            Assert.AreEqual(expectedAvailableMemory, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void TakePhotoMethod_IfSizeIsGreaterThanAvailableMemory_DoesNotTakePhoto()
        {
            Device device = new Device(20);

            bool success = device.TakePhoto(30);

            Assert.IsFalse(success);
            Assert.AreEqual(20, device.AvailableMemory);

            Assert.AreEqual(0, device.Photos); 
        }

        [Test]
        public void InstallAppMethod_ShouldWorkRightIfAppSizeIsLowerThanMemory()
        {
            Device device = new Device(80);
            int appSize = 20;
            string result = device.InstallApp("Mineshaft", appSize);
            Assert.AreEqual(60, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.IsTrue(device.Applications.Contains("Mineshaft"));
            Assert.AreEqual("Mineshaft is installed successfully. Run application?", result);
        }

        [Test]
        public void InstallAppMethod_ThrowsExceptionIfAppSizeIsBigger()
        {
            Device device = new Device(10);
            int appSize = 50;
            Assert.Catch<InvalidOperationException>(() => device.InstallApp("Denka's Game", appSize));
            Assert.AreEqual(10, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void FormatDeviceMethod_ShouldResetEverything()
        {
            int memoryCapacity = 2048;
            Device device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyApp", 500);

            device.FormatDevice();

            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void GetDeviceStatus_ReturnsCorrectStatus()
        {
            
            Device device = new Device(80);
            device.TakePhoto(10);
            device.InstallApp("Calculator", 5);
            device.InstallApp("WeatherApp", 8);
            //device should be 57
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Memory Capacity: 80 MB, Available Memory: 57 MB");
            //$"Memory Capacity: {this.MemoryCapacity} MB, Available Memory: {this.AvailableMemory} MB"
            sb.AppendLine("Photos Count: 1");
            sb.AppendLine("Applications Installed: Calculator, WeatherApp");

            string expectedResult = sb.ToString().TrimEnd();
            Assert.AreEqual(expectedResult, device.GetDeviceStatus());
        }

    }
}