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
    public class DView : IDView
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public DView(ApplicationDbContexts context, IConfiguration configuration)
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
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Nombre, ' - ', Descripcion) AS TextoMostrar 
                    FROM 
                        Security.Views
                    ORDER BY Id ASC";
            return await this.context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<View> GetById(int id)
        {
            var sql = @"SELECT * FROM security.Views WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }

        public async Task<PagedListDto<ViewDto>> GetDataTable(QueryFilterDto filter)
        {
            int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
            int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

            var sql = @"SELECT
                        vw.Id,
                        vw.Nombre
                        vw.Descripcion
                       
                    FROM security.Views vw
                        
                        ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

            IEnumerable<ViewDto> items = await context.QueryAsync<ViewDto>(sql, new NewRecord(filter.Filter));

            var pagedItems = PagedListDto<ViewDto>.Create(items, pageNumber, pageSize);

            return pagedItems;
        }

        public async Task<View> Save(View entity)
        {
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<View> GetByCode(string code)
        {
            return await this.context.Views.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }


    }
    public record NewRecordV(object Filter);
}
