using System;
using System.IO;
using System.Globalization;

namespace ArchiveManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading CSV file (comma-separated values) and manipulating the data inside of it

            try
            {
                Console.Write("Enter file full path (use \\ as separator): ");
                string sourceFilePath = Console.ReadLine();

                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceDirectoryPath = Path.GetDirectoryName(sourceFilePath);
                string newDirectoryPath = sourceDirectoryPath + @"\out";
                string targetFilePath = newDirectoryPath + "\\summary.csv";

                Directory.CreateDirectory(newDirectoryPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string s in lines)
                    {
                        string[] values = s.Split(',');

                        string name = values[0];
                        double preco = double.Parse(values[1], CultureInfo.InvariantCulture);
                        int qnt = int.Parse(values[2]);

                        Product product = new Product(name, preco, qnt);

                        sw.WriteLine(product);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.Write("Error: ");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.Write("Error: ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}