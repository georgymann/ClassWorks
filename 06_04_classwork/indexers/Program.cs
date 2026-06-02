using System.Text;
using System.Text.RegularExpressions;

namespace indexers;

class Program
{
    static void Main(string[] args)
    {
        var students = new Student[]
        {
            new Student("A", "a", new int[,] { { 1, 2, 3 }, { 5, 5, 5 } }),
            new Student("B", "b", new int[,] { { 1, 2, 1 }, { 3, 2, 2 } }),
            new Student("C", "c", new int[,] { { 4, 3, 4 }, { 4, 5, 5 } })
        };
        // foreach (var s in students)
        // {
        //     Console.WriteLine(s[0,1]);
        // }

        string str = "I am a good student!";
        string str2 = "Not! A am!";
        str = "Not! I am!";
        str2 = str;
        Console.WriteLine(str2);
        //str2 = str.Replace("am", "you");
        //str2 = str.Replace("c", "a");
        //str2 = str.Substring(4,3);
        // int a = str.IndexOf('a');
        // Console.WriteLine(a);
        var strings = str.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine(str2);

        foreach (var c in "В 9-й работе разрешены методы следующих классов: Console, Math, Random, Array, Linq.")
        {
            bool isLetter = Char.IsLetter(c);
            bool isDigit = Char.IsDigit(c);
            bool isSpaceTabNewLine = Char.IsSeparator(c);
            bool isPunctuation = Char.IsPunctuation(c);
        }

        string output = $"New\ntext\n\ron\r\neach{Environment.NewLine}line!";
        
        Console.WriteLine(str2);

        StringBuilder sb = new StringBuilder();
        sb.Append("fsfs");
        sb.Remove(1, 5);
        // преобразование динамического массива символов в строку
        sb.ToString();

        //изучить regex
        
        // Regex regex = new Regex("[/d+]");
        // var result = regex.Match(
        //     "В 9-й работе разрешены методы следующих классов: " +
        //     "Console, Math, Random, Array, Linq.");
        // foreach (var match in result.Value)
        // {
        //     Console.WriteLine(match);
        // }
    }
    
}

public class Student
{
    private string _name;
    private string _surname;
    private int[,] _marks;
    private double[] _averageMarks;

    public char this[int idx]
    {
        get
        {
            return _name[idx];
        }
    }
    public int[,] Marks => (int[,]) _marks.Clone();
    public double[] AverageMarks
    {
        get
        {
            if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
            var average = new double[_marks.GetLength(0)];
            for (int i = 0; i < average.Length; i++)
            {
                for (int j = 0; j < average.GetLength(1); j++)
                {
                    average[i] += (double) _marks[i, j] / _marks.GetLength(1);
                }
            }
            return average;
        }
    }

    // public double this[int idx]
    // {
    //     get
    //     {
    //         return AverageMarks[idx];
    //     }
    // }

    public int this[int i, int j]
    {
        get
        {
            return _marks[i, j];
        }
        // set
        // {
        //     if (value >= 2 && value <= 5)
        //         _marks[i, j] = value;
        // }
    }
    
    public Student(string name, string surname, int[,] marks = null)
    {
        _name = name;
        _surname = surname;
        if (marks != null)
        {
            _marks = (int[,])marks.Clone();
        }
    }

    public override string ToString()
    {
        var output =  _name + " " + _surname;
        for (int i = 0; i < _marks.GetLength(0); i++)
        {
            for (int j = 0; j < _marks.GetLength(1); j++)
            {
                output += _marks[i, j] + " ";
            }

            output = output.TrimEnd();
            output += Environment.NewLine;
        }

        return output;

        StringBuilder sb = new StringBuilder(_name);
        sb.Append(" ");
        sb.AppendLine(_surname);
        for (int i = 0; i < _marks.GetLength(0); i++)
        {
            for (int j = 0; j < _marks.GetLength(1); j++)
            {
                sb.Append(_marks[i, j]).Append(" ");
            }

            sb = sb.Remove(sb.Length - 1, 1);
            sb.AppendLine();
        }
    }
}