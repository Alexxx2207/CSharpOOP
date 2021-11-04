using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace NeedForSpeed
{
    class RaceMotorcycle : Motorcycle
    {
        private const double DefaultFuelConsumption = 8;

        public override double FuelConsumption { get { return DefaultFuelConsumption; } }
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
