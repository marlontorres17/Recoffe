using Bussines.Interface;
using Data.Implements;
using Data.Interface;
using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Implements
{
    public class BView : IBView
    {
        private readonly IDView data;

        public BView(IDView data)
        {
            this.data = data;
        }

        public async Task Delete(int Id)
        {
            await this.data.Delete(Id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<ViewDto> GetById(int Id)
        {
            View view = await this.data.GetById(Id);
            ViewDto ViewDto = new ViewDto();

            ViewDto.Id = view.Id;
            ViewDto.Nombre = view.Nombre;
            ViewDto.Descripcion = view.Descripcion;


            return ViewDto;
        }

        public async Task<PagedListDto<ViewDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<View> Save(ViewDto entity)
        {
            View view = new View();
            view = this.mapearDatos(view, entity);

            return await this.data.Save(view);
        }

        public async Task Update(int Id, ViewDto entity)
        {
            View view = await this.data.GetById(Id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.mapearDatos(view, entity);

            await this.data.Update(view);
        }



        private View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Nombre = entity.Nombre;
            view.Descripcion = entity.Descripcion;


            return view;
        }
    }
}
