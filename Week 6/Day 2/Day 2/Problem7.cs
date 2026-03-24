using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_2
{
    // 1. Entity Class
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
    }

    // 2. Repository Interface
    interface IStudentRepository
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
    }

    // 3. Repository Implementation
    class StudentRepository : IStudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudentId == id);
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
                students.Remove(student);
        }
    }

    // 4. Service Layer (Business Logic)
    class StudentService
    {
        private IStudentRepository repository;

        public StudentService(IStudentRepository repo)
        {
            repository = repo;
        }

        public void AddStudent(Student student)
        {
            repository.AddStudent(student);
        }

        public void DisplayAll()
        {
            var students = repository.GetAllStudents();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentId} | {s.StudentName} | {s.Course}");
            }
        }

        public void FindStudent(int id)
        {
            var s = repository.GetStudentById(id);
            if (s != null)
                Console.WriteLine($"Found: {s.StudentName} - {s.Course}");
            else
                Console.WriteLine("Student not found");
        }

        public void DeleteStudent(int id)
        {
            repository.DeleteStudent(id);
            Console.WriteLine("Student deleted (if existed)");
        }
    }

    // 5. Main Program (Client)
    class Problem7
    {
        static void Main(string[] args)
        {
            StudentService service = new StudentService(new StudentRepository());

            // Add Students
            service.AddStudent(new Student { StudentId = 1, StudentName = "Aditi", Course = "BCA" });
            service.AddStudent(new Student { StudentId = 2, StudentName = "Ashish", Course = "BSc" });

            Console.WriteLine("\nAll Students:");
            service.DisplayAll();

            Console.WriteLine("\nFind Student ID 1:");
            service.FindStudent(1);

            Console.WriteLine("\nDelete Student ID 2:");
            service.DeleteStudent(2);

            Console.WriteLine("\nAfter Deletion:");
            service.DisplayAll();
        }
    }
}
