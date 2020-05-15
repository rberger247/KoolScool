using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DataContext dataContext;

      

        public IStudentRepository StudentRepository { get; private set; }

        public UnitofWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
            StudentRepository = new StudentRepository(dataContext);
        }

        public void Dispose()
        {
            dataContext.Dispose();
         
        }

        public void Save()
        {
            dataContext.SaveChanges();
        }
    }
}
