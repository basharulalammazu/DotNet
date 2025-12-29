using AutoMapper;
using BLL.DTOs;
using DAL.Ef.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;

        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Students, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public List<StudentDTO> Get()
        {
            var students = repo.Get();

            var ret = GetMapper().Map<List<StudentDTO>>(students);
            return ret;
        }
    }
}
