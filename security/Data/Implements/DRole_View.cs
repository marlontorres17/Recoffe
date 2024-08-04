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
    public class DRole_View : IDRole_View
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DRole_View(ApplicationDbContexts context, IConfiguration configuration)
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
            context.Roles_views.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                    FROM 
                        Security.Roles_views
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Role_View> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Roles_views WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role_View>(sql, new { Id = id });
        }

        public async Task<PagedListDto<Role_ViewDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        rv.Id,
                       
                       
                    FROM security.Roles_Views rv
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<Role_ViewDto> items = await context.QueryAsync<Role_ViewDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<Role_ViewDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<Role_View> Save(Role_View entity)
        {
            context.Roles_views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Role_View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        


    }
    public record NewRecordRV(object Filter);
}
