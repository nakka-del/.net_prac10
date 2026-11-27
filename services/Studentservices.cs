using StudentManagementAPI.Models;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Rahul",
                Email = "rahul@gmail.com",
                Course = "BCA",
                Age = 21
            }
        };

        public List<Student> GetAll()
        {
            return students;
        }

        public Student? GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            student.Id = students.Count == 0
                ? 1
                : students.Max(s => s.Id) + 1;

            students.Add(student);
        }

        public bool Update(int id, Student student)
        {
            var existing = GetById(id);

            if (existing == null)
                return false;

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Course = student.Course;
            existing.Age = student.Age;

            return true;
        }

        public bool Delete(int id)
        {
            var student = GetById(id);

            if (student == null)
                return false;

            students.Remove(student);
            return true;
        }
    }
}
