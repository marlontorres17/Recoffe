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
    public class BRole : IBRole
    {
        private readonly IDRole data;

        public BRole(IDRole data)
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

        public async Task<RoleDto> GetById(int Id)
        {
            Role role = await this.data.GetById(Id);
            RoleDto RoleDto = new RoleDto();

            RoleDto.Id = role.Id;
            RoleDto.Nombre = role.Nombre;
            RoleDto.Descripcion = role.Descripcion;
            

            return RoleDto;
        }

        public async Task<PagedListDto<RoleDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();
            role = this.mapearDatos(role, entity);

            return await this.data.Save(role);
        }

        public async Task Update(int Id, RoleDto entity)
        {
            Role role = await this.data.GetById(Id);
            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            role = this.mapearDatos(role, entity);

            await this.data.Update(role);
        }



        private Role mapearDatos(Role role, RoleDto entity)
        {
            role.Id = entity.Id;
            role.Nombre = entity.Nombre;
            role.Descripcion = entity.Descripcion;
         

            return role;
        }
    }
}
