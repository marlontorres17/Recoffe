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
    public class BUser_role : IBUser_role
    {
        private readonly IDUser_role data;

        public BUser_role(IDUser_role data)
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

        public async Task<User_roleDto> GetById(int Id)
        {
            User_role user_role = await this.data.GetById(Id);
            User_roleDto User_roleDto = new User_roleDto();

            User_roleDto.Id = user_role.Id;
            User_roleDto.RoleId = user_role.RoleId;


            return User_roleDto;
        }

        public async Task<PagedListDto<User_roleDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<User_role> Save(User_roleDto entity)
        {
            User_role user_role = new User_role();
            user_role = this.mapearDatos(user_role, entity);

            return await this.data.Save(user_role);
        }

        public async Task Update(int Id, User_roleDto entity)
        {
            User_role user_role = await this.data.GetById(Id);
            if (user_role == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user_role = this.mapearDatos(user_role, entity);

            await this.data.Update(user_role);
        }



        private User_role mapearDatos(User_role user_role, User_roleDto entity)
        {
            user_role.Id = entity.Id;
            user_role.RoleId = entity.RoleId;


            return user_role;
        }
    }
}
