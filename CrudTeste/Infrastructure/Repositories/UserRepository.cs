using CrudTeste.Domain.Entities;
using CrudTeste.Domain.Model;
using CrudTeste.Domain.VOs;
using CrudTeste.Infrastructure.DbConnection;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CrudTeste.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly IDbConnection _dbSession;


        public UserRepository(IDbConnection connection) : base(connection)
        {
            _dbSession = connection;
        }


   

    



    }
}

