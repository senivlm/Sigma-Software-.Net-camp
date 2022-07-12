using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12._3
{
    static internal class Calculator
    {
        #region methods
        static private byte GetPriority(char c)
        {
            switch (c)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                case 's': return 5;
                case 'c': return 5;
                case 't': return 5;
                default: return 6;
            }
        }
        static private bool IsOperator(char c)
        {
            //для додавання нових операцій і функцій треба додати їх тут також
            if (("+-/*^()sct".Contains(c)))
                return true;
            return false;
        }
        #endregion methods
        static public double Calculate(string input)
        {
            input = Delimiter(input);
            input = Constants(input);
            input = Trigonometry(input);
            string output = GetExpression(input);
            double result = Counting(output);
            return result;
        }
        #region parsing
        static private string Delimiter(string input)
        {
            input = input.Replace(".", ",");
            return input;
        }
        static private string Constants(string input)
        {
            input = input.Replace("pi", Convert.ToString(Math.PI));
            input = input.Replace("e", Convert.ToString(Math.E));
            return input;
        }
        static private string Trigonometry(string input)
        {
            input = input.Replace("sin", "s");
            input = input.Replace("cos", "c");
            input = input.Replace("tan", "t");
            return input;
        }
        #endregion parsing
        static private string GetExpression(string input)
        {
            string output = string.Empty;
            //операції можуть мати і більше одного символа. Тут Ви вже зробили обмеження для операцій
            //REPLY: операції син, кос ми парсимо до одного символу і цей момент не можна оминути, адже читати вираз користувача все одно треба
            //тому разом з читанням замінюємо операцію на якийсь символ. 
            Stack<char> operStack = new Stack<char>();
            try
            {
                if (input != null)
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (Char.IsDigit(input[i]))
                        {
                            while (input[i] != ' ' && !IsOperator(input[i]))
                            {
                                output += input[i];
                                i++;

                                if (i == input.Length) break;
                            }

                            output += " ";
                            i--;
                        }


                        if (IsOperator(input[i]))
                        {
                            if (input[i] == '(')
                                operStack.Push(input[i]);
                            else if (input[i] == ')')
                            {

                                char s = operStack.Pop();

                                while (s != '(')
                                {
                                    output += s.ToString() + ' ';
                                    s = operStack.Pop();
                                }
                            }
                            else
                            {
                                if (operStack.Count > 0)
                                    if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                        output += operStack.Pop().ToString() + " ";

                                operStack.Push(char.Parse(input[i].ToString()));

                            }
                        }
                    }
                else
                    throw new Exception("Empty expression received at calculating");

                while (operStack.Count > 0)
                    output += operStack.Pop() + " ";

                return output;
            }
            catch (Exception e)
            {
                if (e != null)
                    Console.WriteLine("Помилка введення. Код помилки: " + e.Message);
            }
            return null;
        }
        static private double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();
            try
            {
                for (int i = 0; i < input.Length; i++)
                {

                    if (Char.IsDigit(input[i]))
                    {
                        string a = string.Empty;

                        while (input[i] != ' ' && !IsOperator(input[i]))
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        temp.Push(double.Parse(a));
                        i--;
                    }
                    else if (IsOperator(input[i]))
                    {
                        if (temp.Count >= 1)
                        {
                            double a = temp.Pop();
                            bool flag = false;
                            if (temp.Count == 0)//якщо оператор унарний(мінус чи тригонометричний), то замість б буде заглушка
                            {
                                flag = true;
                                temp.Push(0);
                            }
                            double b = temp.Pop();

                            switch (input[i])
                            {
                                //для додавання нових операцій і функцій треба додати їх тут. можна було б зробити коллекцію операцій
                                //але все одно треба їх знати наперед, адже в коді після case треба прописати фактичну операцію, що буде виконано
                                //або делегат, який буде додано
                                case '+': result = b + a; break;
                                case '-': result = b - a; if(flag) temp.Push(b); break;
                                case '*': result = b * a; break;
                                case '/': result = b / a; break;
                                case '^': result = Math.Pow(b, a); break;
                                case 's': result = Math.Sin(a); temp.Push(b); break;// треба повернути б, бо ми його втратимо
                                case 'c': result = Math.Cos(a); temp.Push(b); break;
                                case 't': result = Math.Tan(a); temp.Push(b); break;
                            }
                        }
                        temp.Push(result);
                    }
                }
                return temp.Peek();
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка введення. Код помилки: " + e.Message);
            }
            return 0;
        }
    }
}
