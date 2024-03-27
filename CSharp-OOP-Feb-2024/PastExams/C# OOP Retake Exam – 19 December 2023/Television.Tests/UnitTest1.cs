using NUnit.Framework;
using System;

namespace TelevisionTests
{
    using Television;

    [TestFixture]
    public class TelevisionDeviceTests
    {
        private TelevisionDevice device;

        [SetUp]
        public void Setup()
        {
            device = new TelevisionDevice("Samsung", 500, 50, 70);
        }

        [TestCase("LG", 500, 10, 20)]
        public void Constructor_ShouldApplyRightValues(string brand, double price, int screenWidth, int screenHeight)
        {
            // Act
            TelevisionDevice tv = new TelevisionDevice(brand, price, screenWidth, screenHeight);

            // Assert
            Assert.AreEqual(brand, tv.Brand);
            Assert.AreEqual(price, tv.Price);
            Assert.AreEqual(screenWidth, tv.ScreenWidth);
            Assert.AreEqual(screenHeight, tv.ScreenHeigth);
        }

        [Test]
        public void Test_CurrentChannel_ShouldReturnTheDefaultChannel()
        {
            // Assert
            Assert.AreEqual(0, device.CurrentChannel);
        }

        [Test]
        public void Test_Volume_ShouldReturnDefaultVolume()
        {
            // Assert
            Assert.AreEqual(13, device.Volume);
        }

        [Test]
        public void Test_IsMuted_ShouldReturnFalseByDefault()
        {
            // Assert
            Assert.IsFalse(device.IsMuted);
        }

        [Test]
        public void CurrentChannel_ShouldReturnTheDefaultChannel()
        {
            // Assert
            Assert.AreEqual(0, device.CurrentChannel);
        }

        [Test]
        public void Volume_ShouldReturnDefaultVolume()
        {
            // Assert
            Assert.AreEqual(13, device.Volume);
        }

        [Test]
        public void IsMuted_ShouldReturnFalseByDefault()
        {
            // Assert
            Assert.IsFalse(device.IsMuted);
        }

        [Test]
        public void ToStringMethod_ShouldReturnCorrectStringRepresentation()
        {
            // Act
            string result = device.ToString();

            // Assert
            string expectedString = $"TV Device: Samsung, Screen Resolution: 50x70, Price 500$";
            Assert.AreEqual(expectedString, result);
        }

        [Test]
        public void SwitchOnMethod_ShouldReturnCorrectStringRepresentation()
        {
            // Act
            string result = device.SwitchOn();

            // Assert
            string expectedString = "Cahnnel 0 - Volume 13 - Sound On";
            Assert.AreEqual(expectedString, result);
        }

        [TestCase(-2)]
        [TestCase(-6)]
        [TestCase(-12003)]
        public void ChangeChannelMethod_ShouldThrowExceptionIfValueIsBelowZero(int channel)
        {
            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                device.ChangeChannel(channel);
            });
        }

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(8)]
        public void ChangeChannelMethod_ShouldChangeChannelProperly(int channel)
        {
            // Act
            int result = device.ChangeChannel(channel);

            // Assert
            Assert.AreEqual(channel, result);
        }

        [Test]
        public void MuteDeviceMethod_ShouldToggleMuteState()
        {
            // Act & Assert
            Assert.IsTrue(device.MuteDevice()); // Mute the device
            Assert.IsFalse(device.MuteDevice()); // Unmute the device
        }

        [TestCase("UP", 100)]
        [TestCase("UP", 20)]
        [TestCase("DOWN", 100)]
        [TestCase("DOWN", 20)]
        public void VolumeChangeMethod_ShouldAdjustVolumeCorrectly(string direction, int units)
        {
            // Arrange
            int expectedVolume = device.Volume;

            // Act
            device.VolumeChange(direction, units);

            // Assert
            if (direction == "UP")
                expectedVolume += units;
            else if (direction == "DOWN")
                expectedVolume -= units;

            expectedVolume = Math.Max(0, Math.Min(100, expectedVolume)); // Ensure volume is within the valid range
            Assert.AreEqual(expectedVolume, device.Volume);
        }
    }
}
