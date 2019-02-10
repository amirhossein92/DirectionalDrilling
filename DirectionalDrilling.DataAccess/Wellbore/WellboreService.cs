using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Wellbore
{
    public class WellboreService : IWellboreService
    {
        private DirectionalDrillingContext _context;

        public WellboreService(DirectionalDrillingContext context)
        {
            _context = context;
        }

        public void Add(Model.Models.Wellbore wellbore)
        {
            _context.Wellbores.Add(wellbore);
            _context.SaveChanges();

        }

        public Model.Models.Wellbore GetWellboreById(int id)
        {
            return _context.Wellbores.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.Wellbore> GetWellbores()
        {
            return _context.Wellbores.ToList();
        }

        public List<Model.Models.Wellbore> GetWellboresByWellId(int id)
        {
            return _context.Wellbores.Where(item => item.Well.Id == id).ToList();
        }

        public void Update(Model.Models.Wellbore wellbore)
        {
            _context.Entry(wellbore).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public void Delete(Model.Models.Wellbore wellbore)
        {
            _context.Wellbores.Remove(wellbore);
            _context.SaveChanges();
        }
    }
}
