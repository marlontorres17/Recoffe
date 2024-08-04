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
    public class BRole_View : IBRole_View
    {
        private readonly IDRole_View data;

        public BRole_View(IDRole_View data)
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

        public async Task<Role_ViewDto> GetById(int Id)
        {
            Role_View role_view = await this.data.GetById(Id);
            Role_ViewDto Role_ViewDto = new Role_ViewDto();

            Role_ViewDto.Id = role_view.Id;
            Role_ViewDto.RoleId = role_view.RoleId;


            return Role_ViewDto;
        }

        public async Task<PagedListDto<Role_ViewDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<Role_View> Save(Role_ViewDto entity)
        {
            Role_View role_view = new Role_View();
            role_view = this.mapearDatos(role_view, entity);

            return await this.data.Save(role_view);
        }

        public async Task Update(int Id, Role_ViewDto entity)
        {
            Role_View role_view = await this.data.GetById(Id);
            if (role_view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role_view = this.mapearDatos(role_view, entity);

            await this.data.Update(role_view);
        }



        private Role_View mapearDatos(Role_View role_view, Role_ViewDto entity)

        {
            role_view.Id = entity.Id;
            role_view.RoleId = entity.RoleId;
            role_view.ViewId = entity.ViewId;
            return role_view;
        }
    }
}
