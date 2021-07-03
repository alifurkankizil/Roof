using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class EntityConfiguration
    {
        public static void BaseEntityBuilder<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : BaseEntity
        {
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
