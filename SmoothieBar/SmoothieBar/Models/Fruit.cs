using System;
using System.Collections.Generic;
using System.Text;

namespace SmoothieBar.Models
{
    internal class Fruit
    {
        private string Name;

        public string FruitName
        {
            get { return Name; }
            set { Name = value; }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
