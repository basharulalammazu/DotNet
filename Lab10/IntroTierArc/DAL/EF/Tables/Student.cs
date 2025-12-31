using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Tables
{
    public class Student
    {
        public int Id { get; set; }
        [Column(TypeName = "Varchar(100)")]
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }
    }
}
