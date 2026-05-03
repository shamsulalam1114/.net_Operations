using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DepartmentService
    {
        DepartmentRepo repo;
        Mapper mapper;
        public DepartmentService(DepartmentRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }

        public List<DepartmentDTO> Get() {
            var data = repo.Get();
            
            var res = mapper.Map<List<DepartmentDTO>>(data);
            return res;
        }
        public DepartmentDTO Get(int id)
        {          
            var data = repo.Get(id);
            
            return mapper.Map<DepartmentDTO>(data);
        }

        public bool Create(DepartmentDTO d) {
           
            var data = mapper.Map<Department>(d);
            return repo.Create(data);
        }
        
    }
}
