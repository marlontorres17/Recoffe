﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Model
{
    internal class GenericConfig
    {
        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(pancracio => pancracio.Nombre_usuario).IsUnique();
        }

        public void ConfigurePersona(EntityTypeBuilder<Person> builder)
        {
            builder.HasIndex(pancracio => pancracio.Documento).IsUnique();
            builder.HasIndex(pancracio => pancracio.Email).IsUnique();
        }
    }
}
