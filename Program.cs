using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prKol_ind8_PolitovMatvei
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FormulaEvaluator evaluator = new FormulaEvaluator();
            string filePath = "formulas.txt";

            Console.WriteLine("Выберите структуру формулы (1-8):");
            Console.WriteLine("1: mmm | 2: mmM | 3: mMm | 4: Mmm");
            Console.WriteLine("5: mMM | 6: MmM | 7: MMm | 8: MMM");

            string choice = Console.ReadLine();
            int lineIndex = 0;

            switch (choice)
            {
                case "1": lineIndex = 0; break; 
                case "2": lineIndex = 1; break; 
                case "3": lineIndex = 2; break;
                case "4": lineIndex = 3; break;
                case "5": lineIndex = 4; break;
                case "6": lineIndex = 5; break;
                case "7": lineIndex = 6; break;
                case "8": lineIndex = 7; break;
                default:
                    Console.WriteLine("Ошибка: неверный выбор.");
                    return;
            }
            try
            {
                string formula = evaluator.GetFormulaFromFile(filePath, lineIndex);
                int result = evaluator.Evaluate(formula);
                Console.WriteLine($"\nИтоговый результат");
                Console.WriteLine($"Формула из файла: {formula}");
                Console.WriteLine($"Вычисленное значение: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}
