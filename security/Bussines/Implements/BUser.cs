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
    public class BUser : IBUser
    {
        private readonly IDUser data;

        public BUser(IDUser data)
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

        public async Task<UserDto> GetById(int Id)
        {
            User user = await this.data.GetById(Id);
            UserDto UserDto = new UserDto();

            UserDto.Id = user.Id;
            UserDto.Nombre_usuario = user.Nombre_usuario;
            UserDto.Contraseña = user.Contraseña;


            return UserDto;
        }

        public async Task<PagedListDto<UserDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user = this.mapearDatos(user, entity);

            return await this.data.Save(user);
        }

        public async Task Update(int Id, UserDto entity)
        {
            User user = await this.data.GetById(Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.mapearDatos(user, entity);

            await this.data.Update(user);
        }



        private User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Nombre_usuario = entity.Nombre_usuario;
            user.Contraseña = entity.Contraseña;


            return user;
        }
    }
}
