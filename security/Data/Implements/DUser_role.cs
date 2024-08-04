using Entity.DTO;
using Data.Interface;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class DUser_role : IDUser_role
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DUser_role(ApplicationDbContexts context, IConfiguration configuration)
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
            context.Users_roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                    FROM 
                        Security.Users_roles
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<User_role> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Users_roles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User_role>(sql, new { Id = id });
        }

        public async Task<PagedListDto<User_roleDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        ur.Id,
                       
                       
                    FROM security.Users_roles ur
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<User_roleDto> items = await context.QueryAsync<User_roleDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<User_roleDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<User_role> Save(User_role entity)
        {
            context.Users_roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(User_role entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

       

    }
    public record NewRecordUR(object Filter);
}
