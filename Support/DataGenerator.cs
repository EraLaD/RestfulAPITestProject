using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPITestProject.Support
{
    public static class DataGenerator
    {

        //Generate random device name with format "Device_{random string of 8 characters}"
        public static string GenerateDeviceName()
        {
            return $"Device_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
        //Generate random year between 1990 - 2026
        public static int GenerateYear()
        {
            Random random = new Random();
            return random.Next(1990, 2026);
        }
        //Generate random number between 0 - 100000
        public static float GeneratePrice()
        {
            return (float)(new Random().NextDouble() * 100000);
        }
        //Generate random CPU model
        public static string GenerateCPUModel()
        {
            return $"CPUModel_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
        //Generate random hard disk size with format "{random number between 128 - 2048}GB"
        public static string GenerateHardDiskSize()
        {
            return $"{new Random().Next(128, 2048)} GB";
        }
        //Generate random description
        public static string GenerateDescription()
        {
            return $"Description_{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
}
