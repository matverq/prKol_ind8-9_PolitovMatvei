using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace prKol_ind8_PolitovMatvei
{
    internal class FormulaEvaluator
    {
        private Stack<int> _numbers = new Stack<int>();
        private Stack<char> _ops = new Stack<char>();
        public string GetFormulaFromFile(string path, int index)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Файл не найден");
            string[] lines = File.ReadAllLines(path);
            return lines[index];
        }
        public int Evaluate(string formula)
        {
            _numbers.Clear();
            _ops.Clear();

            for (int i = 0; i < formula.Length; i++)
            {
                char c = formula[i];

                if (c == 'M' || c == 'm')
                {
                    _ops.Push(c);
                }
                else if (char.IsDigit(c))
                {
                    _numbers.Push(int.Parse(c.ToString()));
                }
                else if (c == ')')
                {
                    if (_numbers.Count >= 2 && _ops.Count >= 1)
                    {
                        int b = _numbers.Pop();
                        int a = _numbers.Pop();
                        char op = _ops.Pop();

                        int res = (op == 'M') ? Math.Max(a, b) : Math.Min(a, b);
                        _numbers.Push(res);
                    }
                }
            }
            return _numbers.Pop();
        }
    }
}
