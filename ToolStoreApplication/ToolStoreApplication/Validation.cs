using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolStoreApplication
{
    class Validation
    {
        public bool ValidateDecimalInput(string input)
        {
            decimal _input;
            if (decimal.TryParse(input, out _input))
            {
                return true;
            }
            else return false;
        }

        public void DecimalErrorMessage()
        {
            MessageBox.Show("Du har uppgivit felaktig infomation.");
        }
    }
}
