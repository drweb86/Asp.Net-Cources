using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW1.Models
{
    public class PrivatePageModel
    {
        public PrivatePageModel(double[] numbers, double minimumValue, double maximumValue)
        {
            Numbers = numbers;
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;
        }

        public double[] Numbers { get; private set; }

        public double MinimumValue { get; private set; }

        public double MaximumValue { get; private set; }
    }
}