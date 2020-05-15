using Domain.Students;

namespace Domain.IRepository
{
   public interface IStudentRepository: IRepository<Student>

    {

        void Update(Student student);
    }
}
