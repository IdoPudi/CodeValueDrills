using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        public Form1()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOne = 0;
            int numberTwo = 0;
            if (int.TryParse(textBox1.Text, out numberOne) && int.TryParse(textBox2.Text, out numberTwo))
            {
                var CalcThread = new Thread(() => CalcPrimeNumbers(numberOne, numberTwo, _cancellationToken));
                CalcThread.Start();
            }
            else
            {
                MessageBox.Show("Invalid input.....enter only numbers");
                ClearTextBox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void CalcPrimeNumbers(int startNumber, int endNumber, CancellationToken _cancellationToken)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = startNumber; i < endNumber && !_cancellationToken.IsCancellationRequested; i++)
            {
                if (IsNumberPrimeNumber(i))
                    primeNumbers.Add(i);
            }
            if (!_cancellationToken.IsCancellationRequested)
            {
                foreach (var item in primeNumbers)
                {
                    listBox1.Invoke(new Action(() => listBox1.Items.Add(item)));
                }
                
            }
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
