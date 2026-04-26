using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;
        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        public Object Get()
        {
            //
            //

            repo.Get();
            //logics
            return new object();
        }
        public Object Get(int id)
        {

            repo.Get(id);
            return new object();
        }
        public Object Create()
        {
            repo.Create();
            return new object();
        }
        public bool Delete()
        {

            return false;
        }
    }
}