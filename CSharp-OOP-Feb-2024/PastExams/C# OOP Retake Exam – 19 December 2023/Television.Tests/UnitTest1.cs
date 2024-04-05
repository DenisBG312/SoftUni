namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice tv;
        [SetUp]
        public void Setup()
        {
            tv = new TelevisionDevice("Samsung", 200, 20, 20);
        }

        [Test]
        public void TestingConstructor()
        {
            Assert.AreEqual("Samsung", tv.Brand);
            Assert.AreEqual(200, tv.Price);
            Assert.AreEqual(20, tv.ScreenWidth);
            Assert.AreEqual(20, tv.ScreenHeigth);
        }

        [Test]
        public void CurrentChannelPropCheck()
        {
            Assert.AreEqual(0, tv.CurrentChannel);
        }

        [Test]
        public void CurrentVolumePropCheck()
        {
            Assert.AreEqual(13, tv.Volume);
        }

        [Test]
        public void IsMutedPropCheck()
        {
            Assert.IsFalse(tv.IsMuted);
        }

        [Test]
        public void SwitchOnMethodTesting_WhenMuted()
        {
            Assert.AreEqual("Cahnnel 0 - Volume 13 - Sound On", tv.SwitchOn());
        }

        [Test]
        public void SwitchOnMethodTesting_WhenNotMuted()
        {
            tv.MuteDevice();
            Assert.AreEqual("Cahnnel 0 - Volume 13 - Sound Off", tv.SwitchOn());
        }

        [Test]
        public void ChangeChannelTesting_InvalidThrows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                tv.ChangeChannel(-4);
            });
        }

        [Test]
        public void ChangeChannelShouldWork()
        {
            tv.ChangeChannel(5);
            Assert.AreEqual(5, tv.CurrentChannel);
        }

        [Test]
        public void VolumeChange_Up_Valid()
        {
            Assert.AreEqual("Volume: 63", tv.VolumeChange("UP", 50));
        }

        [Test]
        public void VolumeChange_Up_MoreThan100()
        {
            Assert.AreEqual("Volume: 100", tv.VolumeChange("UP", 90));
        }

        [Test]
        public void VolumeChange_Down_Valid()
        {
            Assert.AreEqual("Volume: 3", tv.VolumeChange("DOWN", 10));
        }

        [Test]
        public void VolumeChange_Down_LessThan0()
        {
            Assert.AreEqual("Volume: 0", tv.VolumeChange("DOWN", 199));
        }

        [Test]
        public void MuteDevice_Unmute_ToMute()
        {
            Assert.IsTrue(tv.MuteDevice());
        }

        [Test]
        public void MuteDevice_Mute_ToUnmute()
        {
            tv.MuteDevice();
            Assert.IsFalse(tv.MuteDevice());
        }

        [Test]
        public void TestingToStringMethod()
        {
            //TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeigth}, Price {Price}$
            Assert.AreEqual("TV Device: Samsung, Screen Resolution: 20x20, Price 200$", tv.ToString());
        }
    }
}