using System;
using BlinkStickCore;

namespace BlinkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Blink();
            SetLedColor();
            GetLedColor();
        }

        private static void Blink()
        {
            var device = BlinkStick.FindFirst();
            device?.OpenDevice();
            device?.Blink("red");
            device?.CloseDevice();
        }

        private static void SetLedColor()
        {
            var device = BlinkStick.FindFirst();
            device?.OpenDevice();
            device?.SetColor(255,255,255);
            device?.CloseDevice();
        }

        private static void GetLedColor()
        {
            byte redVal = 0x00;
            byte greenVal = 0x00;
            byte blueVal = 0x00;
            
            var device = BlinkStick.FindFirst();
            device?.OpenDevice();
            device?.GetColor(1, out redVal, out greenVal, out blueVal);
            device?.CloseDevice();
            
            Console.WriteLine($"LED 1 - Red: {redVal} Green: {greenVal} Blue: {blueVal}");
        }
    }
}