using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
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
        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public List<StudentDTO> GetAll()
        {
            var student = repo.GetAll();
            var studentDTO = GetMapper().Map<List<StudentDTO>>(student);
            return studentDTO;
        }

        public StudentDTO GetAll(int id)
        {
            var student = repo.GetAll(id);
            var studentDTO = GetMapper().Map<StudentDTO>(student);
            return studentDTO;
        }


        public bool Add(StudentDTO studentDTO)
        {
            var student = GetMapper().Map<Student>(studentDTO);
            return repo.Add(student);
        }

        public bool Update(StudentDTO studentDTO)
        {
            var student = GetMapper().Map<Student>(studentDTO);
            return repo.Update(student);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }



    }
}
