using CrudTeste.Domain.Model;
using CrudTeste.Infrastructure.DbConnection;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using Dapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace CrudTeste.Infrastructure.Repositories
{
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
        private readonly IDbConnection _dbConnection;

        public Repository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            
            return await  _dbConnection.QueryFirstOrDefaultAsync<TEntity>($"SELECT * FROM Users WHERE Id = {id}");
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            
            return await _dbConnection.QueryAsync<TEntity>($"SELECT * FROM Users");
        }

        public void Add(TEntity entity)
        {
     
            _dbConnection.Execute($"INSERT INTO Users (FirstName, MiddleName, LastName, EmailAddress) VALUES (@FirstName, @MiddleName, @LastName, @EmailAddress)", entity);
        }

        public void Update(TEntity entity, int id)
        {       
            _dbConnection.Execute($"UPDATE Users SET @FirstName, @MiddleName, @LastName, @EmailAddress WHERE Id = {id}", entity);
        }

        public void Delete(int id)
        {
            _dbConnection.Execute($"DELETE FROM Users WHERE Id = {id}");
        }

    }
    
}

