using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    class Box
    {
        private const string INVALID_PARAM_ERROR_MSG = "{0} cannot be zero or negative.";
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length { get => length; private set { ValidateParameter(value, nameof(Length)); length = value; } }
        public double Width { get => width; private set { ValidateParameter(value, nameof(Width)); width = value; } }
        public double Height { get => height; private set { ValidateParameter(value, nameof(Height)); height = value; } }

        public double FindSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double FindLateralArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double FindVolume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {FindSurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {FindLateralArea():f2}");
            sb.AppendLine($"Volume - {FindVolume():f2}");
            return sb.ToString().TrimEnd();
        }

        private void ValidateParameter(double parameter, string paramName)
        {
            if (parameter <= 0)
            {
                throw new ArgumentException(string.Format(INVALID_PARAM_ERROR_MSG, paramName));
            }
        }
    }
}
