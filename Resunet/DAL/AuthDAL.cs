﻿using Dapper;
using Npgsql;
using Resunet.DAL.Models;

namespace Resunet.DAL
{
    public class AuthDAL : IAuthDAL
    {
        public async Task<UserModel> GetUser(string email)
        {
            using (var connection = new NpgsqlConnection(DbHelper.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(@"
					SELECT UserId, Email, Password, Salt, Status
					FROM AppUser
					WHERE Email = @email", new { email }) ?? new UserModel();
            }
        }

        public async Task<UserModel> GetUser(int id)
        {
            using (var connection = new NpgsqlConnection(DbHelper.ConnectionString))
            {
                await connection.OpenAsync();

                return await connection.QueryFirstOrDefaultAsync<UserModel>(@"
					SELECT UserId, Email, Password, Salt, Status
					FROM AppUser
					WHERE UserId = @id", new { id }) ?? new UserModel();
            }
        }

        public async Task<int> CreateUser(UserModel model)
        {
            using (var connection = new NpgsqlConnection(DbHelper.ConnectionString))
            {
                await connection.OpenAsync();
                string sql = @"
					INSERT INTO AppUser(Email, Password, Salt, Status)
					VALUES(@Email, @Password, @Salt, @Status)
                    RETURNING UserId";

                return await connection.QuerySingleAsync<int>(sql, model);
            }
        }
    }
}
