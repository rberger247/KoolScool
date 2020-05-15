using System;
using System.Linq;
using Domain.IRepository;
using Domain.Students;


namespace Domain.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly DataContext dataContext;

        public StudentRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Update(Student student)
        {
            var dbStudent = dataContext.Students.FirstOrDefault(x => x.StudentId == student.StudentId);
            if(dbStudent != null)
            {
                dbStudent.FirstName = student.FirstName;

            }
            throw new NotImplementedException();
        }
    }
}
