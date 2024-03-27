namespace Television
{
    using System;
    public class TelevisionDevice
    {
        private int lastChannel = 0;
        private int lastVolume = 13;
        private bool lastMuted = false;
        public TelevisionDevice(string brand, double price, int screenWidth, int screenHeigth)
        {
            Brand = brand;
            Price = price;
            ScreenWidth = screenWidth;
            ScreenHeigth = screenHeigth;
        }

        public string Brand { get; set; }

        public double Price { get; set; }

        public int ScreenWidth { get; set; }

        public int ScreenHeigth { get; set; }

        public int CurrentChannel => lastChannel;

        public int Volume => lastVolume;

        public bool IsMuted => lastMuted;

        public string SwitchOn()
        {
            string sound = IsMuted ? "Off" : "On";
            return $"Cahnnel {CurrentChannel} - Volume {Volume} - Sound {sound}";
        }

        public int ChangeChannel(int channel)
        {
            if (channel < 0)
            {
                throw new ArgumentException("Invalid key!");
            }
            lastChannel = channel;
            return CurrentChannel;
        }

        public string VolumeChange(string direction, int units)
        {
            if(direction == "UP")
            {
                lastVolume += Math.Abs(units);
                if(lastVolume > 100)
                {
                    lastVolume = 100;
                }
            }
             if(direction == "DOWN")
            {
                lastVolume -= Math.Abs(units);
                if(lastVolume < 0)
                {
                    lastVolume = 0;
                }
            }

            return $"Volume: {lastVolume}";
        }

        public bool MuteDevice()
        {
            if(IsMuted)
            {
                lastMuted = false;
                return IsMuted;
            }

            lastMuted = true;
            return IsMuted;
        }

        public override string ToString()
        {
            return $"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeigth}, Price {Price}$";
        }

    }
}
