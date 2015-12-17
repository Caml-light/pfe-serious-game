using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Classes
{
    public class Info
    {
        protected string _Name;
        protected double _Value;

        public Info(string Name, double Value)
        {
            _Name = Name;
            _Value = Value;
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            //The name should not be modify after the initialization
            //set 
            //{
            //    _Name = value;
            //}
        }

        public double Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }
    }
}
