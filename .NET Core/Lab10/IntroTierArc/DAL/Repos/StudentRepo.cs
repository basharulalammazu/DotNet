using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class StudentRepo
    {
        UMSContext db;

        public StudentRepo(UMSContext db)
        {
            this.db = db;
        }

        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public Student GetAll(int id)
        {
            return db.Students.Find(id);
        }

        public bool Add(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = GetAll(id);
            db.Students.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Student student)
        {
            var ex = GetAll(student.Id);
            db.Entry(ex).CurrentValues.SetValues(student);
            return db.SaveChanges() > 0;
        }
    }
}
