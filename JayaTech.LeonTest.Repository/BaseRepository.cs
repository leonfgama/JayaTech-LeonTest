using Dapper;
using Dapper.Contrib.Extensions;
using JayaTech.LeonTest.Domain.Entities;
using JayaTech.LeonTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JayaTech.LeonTest.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable
        where TEntity : BaseEntity
    {
        public BaseRepository(string tableName)
        {
            this.TableName = TableName;
        }

        public string TableName { get; set; }

        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                    _connectionString = @"Server=jayatech.con4fsljjivp.us-east-2.rds.amazonaws.com;Database=JayaTech;User Id=admin;Password=admin123;";

                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        private SqlConnection _connection;
        public SqlConnection Connection
        {
            get
            {
                if (_connection == null || string.IsNullOrWhiteSpace(_connection.ConnectionString))
                {
                    _connection = this.GetConnection();
                }
                return _connection;
            }
            set
            {
                _connection = value;
            }

        }

        public SqlConnection GetConnection(bool mars = false)
        {
            string cs = this.ConnectionString;
            if (mars)
            {
                var scsb = new SqlConnectionStringBuilder(cs)
                {
                    MultipleActiveResultSets = true
                };
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);
            return connection;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Insert(TEntity obj, IDbTransaction sqlTransaction = null)
        {
            if (obj == null)
                throw new NullReferenceException($"Entity is null. Table {this.TableName}");

            int id = await this.Connection.InsertAsync<TEntity>(obj, sqlTransaction);

            return await this.Get(id, sqlTransaction);
        }

        public async Task<TEntity> Update(TEntity obj, IDbTransaction sqlTransaction = null)
        {
            if (obj == null)
                throw new NullReferenceException($"Entity is null. Table {this.TableName}");

            bool success = await this.Connection.UpdateAsync<TEntity>(obj, sqlTransaction);
            if (!success)
                throw new Exception("Object not changed!");

            return await this.Get(obj.Id, sqlTransaction);
        }

        public async Task Delete(TEntity obj, IDbTransaction sqlTransaction = null)
        {
            await this.Delete(obj.Id, sqlTransaction);
        }

        public async Task Delete(int id, IDbTransaction sqlTransaction = null)
        {
            await this.Connection.ExecuteAsync($"DELETE [{this.TableName}] WHERE ID = @Id", new { Id = id }, sqlTransaction);
        }

        public Task<IList<TEntity>> Search(Expression<Func<TEntity, bool>> expression, IDbTransaction sqlTransaction = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SearchFirst(Expression<Func<TEntity, bool>> expression, IDbTransaction sqlTransaction = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Get(int id, IDbTransaction sqlTransaction = null)
        {
            string sqlCommand = $"SELECT * FROM [{this.TableName}] WHERE Id = @Id";
            return await this.Connection.QueryFirstOrDefaultAsync<TEntity>(sqlCommand, new { Id = id }, sqlTransaction);
        }
    }
}
