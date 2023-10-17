using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.Text;

namespace ASS_4_CALCULATOR
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void button_click(object sender, EventArgs e)
        {
            if ((textBoxResult.Text == "0"))
            {
                textBoxResult.Clear();
            }
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if(!textBoxResult.Text.Contains("."))
                    textBoxResult.Text = textBoxResult.Text + button.Text;
            }
            else
                textBoxResult.Text = textBoxResult.Text + button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            if (textBoxResult.Text == "0")
            {
                textBoxResult.Clear();
            }
            Button button = (Button)sender;
            textBoxResult.Text = textBoxResult.Text +" "+  button.Text+" ";

        }


        private void buttonBack_Click(object sender, EventArgs e)
        {
            int rem = textBoxResult.Text.Length - 1;
            textBoxResult.Text = textBoxResult.Text.Remove(rem);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Clear();
        }
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            recentOp.Text = textBoxResult.Text;
            textBoxResult.Text = Solve(textBoxResult.Text);
            historyBox.Text = historyBox.Text + "\r\n" + recentOp.Text + "=" + textBoxResult.Text+ "\n";
        }
        public static string Solve(string equation)
        {
            try
            {
                
                string[] orderOfOperations = new string[] { "/", "x", "+","*", "-" };

            
                equation = equation.Replace(" ", "");
                while (equation.Contains("("))
                {
                    int openIndex = equation.LastIndexOf('(');
                    int closeIndex = equation.IndexOf(')', openIndex);

                    if (closeIndex == -1)
                    {
                        throw new ArgumentException("Invalid equation");
                    }

                    string subEquation = equation.Substring(openIndex + 1, closeIndex - openIndex - 1);
                    string subResult = Solve(subEquation);

                    equation = equation.Substring(0, openIndex) + subResult + equation.Substring(closeIndex + 1);
                }
                
                List<string> elementsList = new List<string>();

                // Initialize the current element
                string currentElement = "";

                
                for (int i = 0; i < equation.Length; i++)
                {
                    char c = equation[i].ToString()[0];
                    if (orderOfOperations.Contains(c.ToString()))
                    {
                        
                        elementsList.Add(currentElement);
                        elementsList.Add(c.ToString());
                        currentElement = "";
                    }
                    else
                    {
                        
                        currentElement += c;
                    }
                    
                    if (i == equation.Length - 1)
                    {
                        elementsList.Add(currentElement);
                    }
                }

                // Check if there's an operator between operands
                if (!elementsList.Any(op => orderOfOperations.Contains(op)))
                    throw new ArgumentException("Invalid equation");
                // Convert the list to an array
                string[] elements = elementsList.ToArray();



                foreach (string op in orderOfOperations)
                {
                    for (int i = 0; i < elements.Length; i++)
                    {
                        if (elements[i] == op)
                        {
                            // Check if operand is not at the start of the string and not at the end; if it is, it's considered invalid
                            if (i == 0 || i == elements.Length - 1)
                                throw new ArgumentException("Invalid equation");

                            double operand1 = double.Parse(elements[i - 1]);
                            double operand2 = double.Parse(elements[i + 1]);
                            double result = 0;

                            switch (op)
                            {
                                case "/":
                                    if (operand2 == 0)
                                        throw new DivideByZeroException();
                                    result = operand1 / operand2;
                                    break;
                                case "x":
                                    result = operand1 * operand2;
                                    break;
                                case "*":
                                    result = operand1 * operand2;
                                    break;
                                case "+":
                                    result = operand1 + operand2;
                                    break;
                                case "-":
                                    result = operand1 - operand2;
                                    break;
                            }
                            elements[i - 1] = result.ToString();
                            elements[i] = "";
                            elements[i + 1] = "";
                            elements = elements.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                            i--;
                        }
                    }
                }

                elements = elements.Where(e => !string.IsNullOrEmpty(e)).ToArray();

                if (elements.Length != 1)
                    throw new ArgumentException("Invalid equation - Unresolved equation.");

                return elements[0];
            }
            catch (Exception ex)
            {
                return "Invalid equation: " + ex.Message;
            }
        }

        private void textBoxResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxResult.Text == "0")
            {
                textBoxResult.Clear();
            }
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == '.')
            {
                
                textBoxResult.Text += e.KeyChar;
            }
            else if (e.KeyChar == (char)Keys.Enter)
            {
                // Handle the Enter key (e.g., perform calculations or some action)
                // You can replace the following line with your specific action
                buttonEqual.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                
                if (textBoxResult.Text.Length > 0)
                {
                    textBoxResult.Text = textBoxResult.Text.Substring(0, textBoxResult.Text.Length - 1);
                }
            }

            
            e.Handled = true;
        }

        private void textBoxResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                
                string clipboardText = Clipboard.GetText();
                textBoxResult.AppendText(clipboardText);
                e.Handled = true; 
            }
        }
    }
}
