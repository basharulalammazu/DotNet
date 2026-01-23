using DAL.Ef.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        public List<Students> Get()
        {
            return db.Students.ToList();
        }
    }
}
