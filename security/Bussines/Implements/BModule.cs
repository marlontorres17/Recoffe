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
    public class BModule : IBModule
    {
        private readonly IDModule data;

        public BModule(IDModule data)
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

        public async Task<ModuleDto> GetById(int Id)
        {
            Module module = await this.data.GetById(Id);
            ModuleDto ModuleDto = new ModuleDto();

            ModuleDto.Id = module.Id;
            ModuleDto.Nombre = module.Nombre;
            ModuleDto.Descripcion = module.Descripcion;
            
            return ModuleDto;
        }

        public async Task<PagedListDto<ModuleDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module = this.mapearDatos(module, entity);

            return await this.data.Save(module);
        }

        public async Task Update(int Id, ModuleDto entity)
        {
            Module module = await this.data.GetById(Id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = this.mapearDatos(module, entity);

            await this.data.Update(module);
        }



        private Module mapearDatos(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.Nombre = entity.Nombre;
            module.Descripcion = entity.Descripcion;
          

            return module;
        }
    }
}
