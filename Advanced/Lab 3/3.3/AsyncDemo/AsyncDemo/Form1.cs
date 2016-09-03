using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncDemo
{
    public partial class Form1 : Form
    {
        public delegate IEnumerable<int> getAllPrimes(int startNumber, int endNumber);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOne = 0;
            int numberTwo = 0;
            if (int.TryParse(textBox1.Text,out numberOne)&& int.TryParse(textBox2.Text, out numberTwo))
            {
                getAllPrimes del = CalcPrimes;
                del.BeginInvoke(numberOne, numberTwo, (result) =>
                  {
                      IEnumerable<int> primeNumbersList = del.EndInvoke(result);
                      this.Invoke(new Action(() =>
                      {
                          listBox1.Items.Clear();
                          ClearTextBox();
                          foreach (var item in primeNumbersList)
                          {
                              listBox1.Items.Add(item);
                          }
                      }));
                  }, del);
            }
            else
            {
                MessageBox.Show("Invalid input.....enter only numbers");
                ClearTextBox();
            }
        }

        private static IEnumerable<int> CalcPrimes(int startNumber,int endNumber)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = startNumber; i < endNumber; i++)
            {
                if (IsNumberPrimeNumber(i))
                    primeNumbers.Add(i);
            }

            return primeNumbers;
        }

        private static bool IsNumberPrimeNumber(int numberToCheck)
        {
            int check = (int)Math.Floor(Math.Sqrt(numberToCheck));

            if (numberToCheck == 1)
                return false;

            if (numberToCheck == 2)
                return true;

            for (int i = 2; i <= check; i++)
                if (numberToCheck % i == 0)
                    return false;

            return true;
        }

        private void ClearTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
