using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IUnitofWork : IDisposable
    {

        IStudentRepository StudentRepository{get;}

        void Save();

    }
}
