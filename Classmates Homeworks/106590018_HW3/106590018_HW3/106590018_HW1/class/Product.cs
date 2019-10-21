using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106590018_Homework
{
    public class Product 
    {
        public Product(int idData, string nameData, string typeData, int priceData, string introductionData, int inventory)
        {
            _id = idData;
            _name = nameData;
            _type = typeData;
            _price = priceData;
            _introduction = introductionData;
            _inventory = inventory;
        }

        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
        }
        public string Introduction
        {
            get
            {
                return _introduction;
            }
        }

        public int Inventory
        {
            set
            {
                _inventory = value;
            }
            get
            {
                return _inventory;
            }
        }
        private int _id;
        private int _price;
        private int _inventory;
        private string _name = "";
        private string _introduction = "";
        private string _type = "";
    }
}
