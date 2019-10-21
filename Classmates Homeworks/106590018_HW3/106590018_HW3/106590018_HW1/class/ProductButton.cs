using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _106590018_Homework
{
    class ProductButton : Button
    {
        private int _id = 0;
        public ProductButton()
        {
        }
        public ProductButton(int id)
        {
            this._id = id;
        }
        public int Id
        {
            get
            {
                return _id;
            }
        }
    }
}
