namespace Structures2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Group.Track);
            var students = new Student[5]
            {
                new Student("Bob", 18),
                new Student("Marley", 20),
                new Student("Bill", 18),
                new Student("Volodya", 19),
                new Student("Antuan", 20)
            };
            students[0].Exam(5);
            Console.WriteLine(students[0].Marks[0]);
            
            
            var group = new Group("BIVTIKI");
            group.AddStudent(students);
            group.Print();
            //group.Sort();

            Console.WriteLine();
            Student.Sort(students);
            foreach (var student in students)
                student.Print();

            Console.WriteLine();
            group.Print();
        }
    }
    public struct Student
    {
        private string _name;
        private int _age;
        private int _id;
        private static int _sec;
        private int[] _marks;
        private int _indexMark;
        public string Name => _name;
        public int Age => _age;
        public int Id => _id;

        public int[] Marks
        {
            get
            {
                if (_marks == null) return null;
                
                return (int[])_marks.Clone();
                return _marks.ToArray();
            }
        }
        static Student()
        {
            _sec = 1;
        }
        public Student(string name, int age)
        {
            this._name = name;
            _age = age;
            _id = _sec;
            _sec++;
            _marks = new int[4];
            _indexMark = 0;

        }

        public void Exam(int mark)
        {
            if (mark >= 2 && mark <= 5 && _indexMark < _marks.Length)
            {
                _marks[_indexMark] = mark;
                _indexMark++;
            }
        }
        public static void Sort(Student[] students)
        {
            for (int i = 1; i < students.Length; i++)
            {
                var student = students[i];
                var j = i;
                while (j > 0 && students[j - 1].Name.CompareTo(student.Name) == 1)
                {
                    students[j] = students[j - 1];
                    j--;
                }
                students[j] = student;
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
        private static string _track;
        public string Name => _name;
        public Student[] Students => _students;

        public static string Track
        {
            get
            {
                return $"{typeof(Group)}_{_track}";
            }
        }

        public string MyTrack
        {
            get
            {
                return this.GetType().ToString();
                return Track;
            }
        }
        static Group()
        {
            _track = "BIVT";
        }
        public Group(string name)
        {
            _name = name;
            _students = new Student[0];
        }
        public void AddStudent(Student student)
        {
            Array.Resize(ref _students, _students.Length + 1);
            _students[^1] = student;
        }

        public Group(Group another)
        {
            _name = another._name;
            _students = another._students;
            if (another._students.Length == 0)
                this.AddStudent(default(Student));
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
