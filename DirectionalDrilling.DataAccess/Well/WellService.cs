using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Well
{
    public class WellService : IWellService
    {
        private DirectionalDrillingContext _context;

        public WellService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.Well well)
        {
            try
            {
                _context.Wells.Add(well);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Well - " + e.Message);
            }
        }

        public Model.Models.Well GetWellById(int id)
        {
            return _context.Wells.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.Well> GetWells()
        {
            return _context.Wells.ToList();
        }

        public void Update(Model.Models.Well well)
        {
            var foundWell = GetWellById(well.Id);
            if (foundWell != null)
            {
                foundWell = well;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.Well well)
        {
            _context.Wells.Remove(well);
            _context.SaveChanges();
        }
    }
}
