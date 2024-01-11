using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Data_Access_Layer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data_Access_Layer.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        ApplicationDbContext _repositoryContext;
        public AuthenticationRepository(ApplicationDbContext repositoryContext) 
        {
            _repositoryContext = repositoryContext;

        }
        public async Task Login(Student loginstudent)
        {
            _repositoryContext.Update(loginstudent);
            _repositoryContext.SaveChangesAsync();
        }

        public async Task Register(Student registerstudent)
        {
            await _repositoryContext.AddAsync(registerstudent);
            await _repositoryContext.SaveChangesAsync();
           
        }
    }
}
