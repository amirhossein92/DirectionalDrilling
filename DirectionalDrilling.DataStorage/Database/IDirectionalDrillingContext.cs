using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Models;

namespace DirectionalDrilling.DataStorage.Database
{
    public interface IDirectionalDrillingContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        void SaveChanges();
    }
}
