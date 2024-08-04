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
    public class BPerson : IBPerson
    {
        private readonly IDPerson data;

        public BPerson(IDPerson data)
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

        public async Task<PersonDto> GetById(int Id)
        {
            Person person = await this.data.GetById(Id);
            PersonDto PersonDto = new PersonDto();

            PersonDto.Id = person.Id;
            PersonDto.Primer_nombre = person.Primer_nombre;
            PersonDto.Segundo_nombre = person.Segundo_nombre;
            PersonDto.Primer_nombre = person.Primer_nombre;
            PersonDto.Segundo_apellido = person.Segundo_apellido;

            return PersonDto;
        }

        public async Task<PagedListDto<PersonDto>> GetDataTable(QueryFilterDto filters)
        {
            return await this.data.GetDataTable(filters);
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person = this.mapearDatos(person, entity);

            return await this.data.Save(person);
        }

        public async Task Update(int Id, PersonDto entity)
        {
            Person person = await this.data.GetById(Id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.mapearDatos(person, entity);

            await this.data.Update(person);
        }

       

        private Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.Primer_nombre = entity.Primer_nombre;
            person.Segundo_apellido = entity.Segundo_apellido;
            person.Primer_aPellido = entity.Primer_aPellido;
            person.Segundo_apellido = entity.Segundo_apellido;

            return person;
        }
    }
}
