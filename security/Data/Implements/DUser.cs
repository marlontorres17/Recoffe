using Entity.DTO;
using Data.Interface;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implements
{
    public class DUser : IDUser
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DUser(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre_usuario, ' - ', Contraseña) AS TextoMostrar 
                    FROM 
                        Security.Users
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Users WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }

        public async Task<PagedListDto<UserDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        us.Id,
                        us.Nombre_usuario
                        us.Contraseña
                       
                    FROM security.Users us
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<UserDto> items = await context.QueryAsync<UserDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<UserDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<User> Save(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<User> GetByCode(string code)
        {
            return await this.context.Users.AsNoTracking().Where(item => item.Nombre_usuario == code).FirstOrDefaultAsync();
        }


    }
    public record NewRecordU(object Filter);
}
