using System;
using System.Windows;
using System.Windows.Controls;


namespace Calculator
{
    public partial class MainWindow : Window
    {
        string leftop = "";
        string operation = "";
        string rightop = "";

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string s = (string)((Button)e.OriginalSource).Content;

            textBlock.Text += s;

            int num;

            bool result = Int32.TryParse(s, out num);

            if (result == true | s == ",")
            {

                if (operation == "")
                {

                    leftop += s;
                }
                else
                {

                    rightop += s;
                }
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text = "";
                    textBlock.Text += rightop;
                    operation = "";
                }
                else if (s == "CLEAR")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else if (s == "SQRT" & leftop != "")
                {
                    if (leftop.Contains(","))
                    {
                        double numd1 = Double.Parse(leftop);
                        double result1 = Math.Sqrt(numd1);
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                    else
                    {
                        int num1 = Int32.Parse(leftop);
                        double result1 = Math.Sqrt(num1);
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                }
                else if (s == "x^2" & leftop != "")
                {
                    if (leftop.Contains(","))
                    {
                        double numd1 = Double.Parse(leftop);
                        double result1 = numd1 * numd1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                    else
                    {
                        int num1 = Int32.Parse(leftop);
                        double result1 = num1 * num1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                }
                else if (s == "1/x" & leftop != "")
                {
                    if (leftop.Contains(","))
                    {
                        double numd1 = Double.Parse(leftop);
                        double result1 = 1 / numd1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                    else
                    {
                        int num1 = Int32.Parse(leftop);
                        double result1 = 1 / num1;
                        textBlock.Text = "";
                        textBlock.Text = result1.ToString();
                    }
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            int num1 = 0;
            int num2 = 0;
            double numd1 = 0;
            double numd2 = 0;
            if (leftop.Contains(","))
            {

                numd1 = Double.Parse(leftop);
            }
            else num1 = Int32.Parse(leftop);

            if (rightop.Contains(","))
            {

                numd2 = Double.Parse(rightop);
            }
            else num2 = Int32.Parse(rightop);

            switch (operation)
            {
                case "+":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 + numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 + (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 + numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 + num2).ToString(); }
                    break;
                case "-":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 - numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 - (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 - numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 - num2).ToString(); }
                    break;
                case "*":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 * numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 * (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 * numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 * num2).ToString(); }
                    break;
                case "/":
                    if (leftop.Contains(",") & rightop.Contains(","))
                    { rightop = (numd1 / numd2).ToString(); }
                    else if (leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (numd1 / (double)num2).ToString(); }
                    else if (!leftop.Contains(",") & rightop.Contains(","))
                    { rightop = ((double)num1 / numd2).ToString(); }
                    else if (!leftop.Contains(",") & !rightop.Contains(","))
                    { rightop = (num1 / num2).ToString(); }
                    break;
            }
        }
    }
}