using System.Diagnostics.Contracts;

namespace ComplexCalculator
{
    public partial class Form1 : Form
    {
        string num1 = "";
        string num2 = "";
        string operation = "";
        Boolean entersecondnumber = false;

        public Form1()
        {
            InitializeComponent();
            button_0.Click += (s, e) => NumberClick("0");
            button_1.Click += (s, e) => NumberClick("1");
            button_2.Click += (s, e) => NumberClick("2");
            button_3.Click += (s, e) => NumberClick("3");
            button_4.Click += (s, e) => NumberClick("4");
            button_5.Click += (s, e) => NumberClick("5");
            button_6.Click += (s, e) => NumberClick("6");
            button_7.Click += (s, e) => NumberClick("7");
            button_8.Click += (s, e) => NumberClick("8");
            button_9.Click += (s, e) => NumberClick("9");
            button_point.Click += (s, e) => NumberClick(".");

            button_plus.Click += (s, e) => OperatorClick("+");
            button_minus.Click += (s, e) => OperatorClick("-");
            button_multiply.Click += (s, e) => OperatorClick("*");
            button_divide.Click += (s, e) => OperatorClick("/");
            button_qaliq.Click += (s, e) => OperatorClick("%");
            button_sqrt.Click += (s, e) => OperatorClick("sqrt");

            button_ce.Click += (s, e) => ClearAll();
            button_equal.Click += (s, e) => button_equal_Click();
            button_c.Click += button_c_Click;
            button_sqrt.Click += button_sqrt_Click;
        }
        private void button_sqrt_Click(object sender, EventArgs e)
        {
            double result = 0;
            double n1 = double.Parse(num1);
            result = Math.Sqrt(n1);
            display.Text = "=" + result.ToString();
        }
        private void OperatorClick(string op)
        {
            if (!string.IsNullOrEmpty(num1))
            {
                if (!string.IsNullOrEmpty(num2))
                {
                    double n1 = double.Parse(num1);
                    double n2 = double.Parse(num2);

                    if (operation == "+")
                        num1 = (n1 + n2).ToString();
                    else if (operation == "-")
                        num1 = (n1 - n2).ToString();
                    else if (operation == "*")
                        num1 = (n1 * n2).ToString();
                    else if (operation == "/")
                        num1 = n2 != 0 ? (n1 / n2).ToString() : "0";
                    else if (operation == "%")
                        num1 = (n1 % n2).ToString();

                    num2 = "";
                }

                operation = op;
                entersecondnumber = true;
                display.Text = num1 + operation;
            }


            operation = op;
            entersecondnumber = true;
            //display.Text += op;

        }
        private void NumberClick(string number)
        {
            if (entersecondnumber)
                num2 += number;
            else
                num1 += number;

            display.Text += number;

        }

        private void button_equal_Click()
        {
            if (string.IsNullOrWhiteSpace(num1) || string.IsNullOrWhiteSpace(num2) || string.IsNullOrWhiteSpace(operation))
            {
                MessageBox.Show("Əvvəlcə düzgün əməliyyat ardıcıllığı qurun!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                double n1 = double.Parse(num1);
                double n2 = double.Parse(num2);
                double result = 0;

                if (operation == "+")
                    result = n1 + n2;
                else if (operation == "-")
                    result = n1 - n2;
                else if (operation == "*")
                    result = n1 * n2;
                else if (operation == "/")
                {
                    if (n2 == 0)
                    {
                        MessageBox.Show("Sıfıra bölmək olmaz!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        result = n1 / n2;
                }
                else if (operation == "%")
                    result = n1 % n2;


                display.Text = "=" + result.ToString();
                num1 = result.ToString();
                num2 = "";
                operation = "";
                entersecondnumber = false;
            }
        }
        private void ClearAll()
        {
            num1 = "";
            num2 = "";
            operation = "";
            entersecondnumber = false;
            display.Text = "";
        }

        private void button_c_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(num2))
            {
                num2 = num2.Substring(0, num2.Length - 1);
                display.Text = num1 + operation + num2;
            }
            else if (!string.IsNullOrEmpty(operation))
            {
                operation = "";
                entersecondnumber = false;
                display.Text = num1;
            }
            else if (!string.IsNullOrEmpty(num1))
            {
                num1 = num1.Substring(0, num1.Length - 1);
                display.Text = num1;
            }

        }

    }

}









