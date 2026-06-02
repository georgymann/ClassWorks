namespace cw_10_02;

class Program
{
    static void Main(string[] args)
    {
        var students = new Student[5]
        {
            new Student("Bob", 18),
            new Student("Marley", 20),
            new Student("Rob", 18),
            new Student("Andrew", 19),
            new Student("Peter", 21)
        };
        var group = new Group("BIVTIKI");
        {
            group.AddStudent(students);
            group.Print();
        };
        group.Sort();
        group.Print();
    }
    public struct Student
    {
        private string _name;
        private int _age;
        private int _id;
        private static int _sec;
        public string Name => _name;
        public int Age => _age;

        public Student()
        {
            _sec = 1;
        }
        public Student(string name, int age)
        {
            this._name = name;
            _age = age;
            _id = _sec;
            _sec++;
        }

        public void Sort(Student[] students)
        {
            for (int i = 0; i < students.Length - 1; i++)
            {
                for (int j = 0; j < students.Length - 1 - i; j++)
                {
                    if (students[j].Name.CompareTo(students[j + 1]) >0)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }
        public void Print()
        {
            Console.WriteLine($"Student {_id}: {_name}, {_age}");
        }
    }
    public struct Group
    {
        private string _name;
        private Student[] _students;
        public string Name => _name;
        public Student[] Students => _students;
        public Group(string name)
        {
            _name = name;
            _students = new Student[0];
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref _students, _students.Length+1);
            _students[^1] = student;
        }

        public void AddStudent(Student[] students)
        {
            foreach (Student student in students)
            {
                AddStudent(student);
            }
        }

        public void Sort()
        {
            _students = _students.OrderBy(std => std.Name).ToArray();
        }
        public void Print()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Students:");
            foreach (var student in _students)
            {
                student.Print();
            }
        }
    }

    
}