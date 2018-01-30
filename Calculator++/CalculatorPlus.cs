using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorPlus
{
    public partial class CalculatorPlusPlus : Form
    {
        
        public CalculatorPlusPlus()
        {
            InitializeComponent();
        }

        

        private double Skobki(List<string> list, int index)
        {
            double result = 0;

            for (int i = index; i < list.Count; i++)
            {
                //выход из метода при условии окончания скобок
                if (list[i] == ")")
                {
                    list.RemoveAt(i);
                    break;
                }

                //проверка двойных скобок или скобки в начале
                if (list[i] == "(")
                {
                    list.Insert(i, Skobki(list, i + 1).ToString());
                    list.RemoveAt(i + 1);
                }


                //проверка отрицательного значения
                if (list[index] == "-")
                {
                    list[index + 1] = (-1 * double.Parse(Skobki(list, index + 1).ToString())).ToString();
                    list.RemoveAt(i);
                }

                #region Проверка начальных тригонометрических функций 
                if (list[index] == "sin")
                {
                    if (list[index + 1] == "(")
                    {
                        list.Insert(index + 1, Skobki(list, index + 2).ToString());
                        list.RemoveAt(index + 2);
                    }
                    list.Insert(index + 1, Math.Sin(double.Parse(list[index + 1])).ToString());
                    list.RemoveAt(index);
                    list.RemoveAt(index + 1);
                }

                if (list[index] == "cos")
                {
                    if (list[index + 1] == "(")
                    {
                        list.Insert(index + 1, Skobki(list, index + 2).ToString());
                        list.RemoveAt(index + 2);
                    }
                    list.Insert(index + 1, Math.Cos(double.Parse(list[index + 1])).ToString());
                    list.RemoveAt(index);
                    list.RemoveAt(index + 1);
                }

                if (list[index] == "tg")
                {
                    if (list[index + 1] == "(")
                    {
                        list.Insert(index + 1, Skobki(list, index + 2).ToString());
                        list.RemoveAt(index + 2);
                    }
                    list.Insert(index + 1, Math.Tan(double.Parse(list[index + 1])).ToString());
                    list.RemoveAt(i);
                    list.RemoveAt(index + 1);
                }

                if (list[index] == "ctg")
                {
                    if (list[index + 1] == "(")
                    {
                        list.Insert(index + 1, Skobki(list, index + 2).ToString());
                        list.RemoveAt(index + 2);
                    }
                    list.Insert(index + 1, (Math.Cos(double.Parse(list[index + 1])) / Math.Sin(double.Parse(list[i + 1]))).ToString());
                    list.RemoveAt(index);
                    list.RemoveAt(index + 1);
                }



                #endregion

                #region Проверка операторов
                if (list[i] == "+")
                {
                    if (list[i + 1] == "(")
                    {
                        list.Insert(i + 1, Skobki(list, i + 2).ToString());
                        list.RemoveAt(i + 2);
                    }

                    if (list[i + 1] == "sin")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Sin(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "cos")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Cos(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "tg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Tan(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "ctg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, (Math.Cos(double.Parse(list[i + 2])) / Math.Sin(double.Parse(list[i + 2]))).ToString());
                        list.RemoveAt(i + 1);
                    }
                    result = double.Parse(list[i - 1]) + double.Parse(list[i + 1]);
                    list.Insert(i - 1, result.ToString());
                    list.RemoveAt(i + 2);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    i--;
                    continue;
                    
                }

                if (list[i] == "-")
                {

                    if (list[i + 1] == "(")
                    {
                        list.Insert(i + 1, Skobki(list, i + 2).ToString());
                        list.RemoveAt(i + 2);
                    }

                    if (list[i + 1] == "sin")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Sin(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "cos")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Cos(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "tg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Tan(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "ctg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, (Math.Cos(double.Parse(list[i + 2])) / Math.Sin(double.Parse(list[i + 2]))).ToString());
                        list.RemoveAt(i + 1);
                    }

                    result = double.Parse(list[i - 1]) - double.Parse(list[i + 1]);
                    list.Insert(i - 1, result.ToString());
                    list.RemoveAt(i + 2);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    i--;
                    continue;
                }

                if (list[i] == "*")
                {

                    if (list[i + 1] == "(")
                    {
                        list.Insert(i + 1, Skobki(list, i + 2).ToString());
                        list.RemoveAt(i + 2);
                    }

                    if (list[i + 1] == "sin")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Sin(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "cos")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Cos(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "tg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Tan(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "ctg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, (Math.Cos(double.Parse(list[i + 2])) / Math.Sin(double.Parse(list[i + 2]))).ToString());
                        list.RemoveAt(i + 1);
                    }

                    result = double.Parse(list[i - 1]) * double.Parse(list[i + 1]);
                    list.Insert(i - 1, result.ToString());
                    list.RemoveAt(i + 2);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    i--;
                    continue;
                }

                if (list[i] == "/")
                {

                    if (list[i + 1] == "(")
                    {
                        list.Insert(i + 1, Skobki(list, i + 2).ToString());
                        list.RemoveAt(i + 2);
                    }

                    if (list[i + 1] == "sin")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Sin(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "cos")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Cos(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "tg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, Math.Tan(double.Parse(list[i + 2])).ToString());
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 1] == "ctg")
                    {
                        if (list[i + 2] == "(")
                        {
                            list.Insert(i + 2, Skobki(list, i + 3).ToString());
                            list.RemoveAt(i + 3);
                        }
                        list.Insert(i + 2, (Math.Cos(double.Parse(list[i + 2])) / Math.Sin(double.Parse(list[i + 2]))).ToString());
                        list.RemoveAt(i + 1);
                    }

                    result = double.Parse(list[i - 1]) / double.Parse(list[i + 1]);
                    list.Insert(i - 1, result.ToString());
                    list.RemoveAt(i + 2);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    i--;
                    continue;
                }
                #endregion

                //вывод окончательного значения
                result = double.Parse(list[index]);
            }
            return result;
        }


        #region Buttons
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            StringBuilder convertions = new StringBuilder();
            List<string> numbers = new List<string>();
            convertions.Append(txtField.Text);
            convertions.Replace("+", " + ");
            convertions.Replace("-", " - ");
            convertions.Replace("*", " * ");
            convertions.Replace("/", " / ");
            convertions.Replace("(", " ( ");
            convertions.Replace(")", " ) ");
            convertions.Replace("sin", " sin ");
            convertions.Replace("cos", " cos ");
            convertions.Replace("tg", " tg ");
            convertions.Replace("ctg", " ctg ");


            numbers.AddRange(convertions.ToString().Split());
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == "" || numbers[i] == " ")
                    numbers.RemoveAt(i);
            }

            try
            {
                txtField.Text = "" + Skobki(numbers, 0);
            }
            catch
            {
                txtField.Text = "wrong format";
            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtField.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtField.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtField.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtField.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtField.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtField.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtField.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtField.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtField.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtField.Text += "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtField.Text = "";
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtField.Text += "+";
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            txtField.Text += "-";
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            txtField.Text += "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            txtField.Text += "/";
        }

        private void btnSkobka1_Click(object sender, EventArgs e)
        {
            txtField.Text += "(";
        }

        private void btnSkobka2_Click(object sender, EventArgs e)
        {
            txtField.Text += ")";
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            txtField.Text += ",";
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            txtField.Text += "sin";
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            txtField.Text += "cos";
        }

        private void btnTg_Click(object sender, EventArgs e)
        {
            txtField.Text += "tg";
        }

        private void btnCtg_Click(object sender, EventArgs e)
        {
            txtField.Text += "ctg";
        }

        #endregion
    }
}
