using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Formation
{
    public class FormationService : IFormationService
    {
        private DirectionalDrillingContext _context;

        public FormationService(DirectionalDrillingContext context)
        {
            _context = context;
        }

        public void Add(Model.Models.Formation formation)
        {
            _context.Formations.Add(formation);
            _context.SaveChanges();
        }

        public Model.Models.Formation GetformationById(int id)
        {
            return _context.Formations.Find(id);
        }

        public List<Model.Models.Formation> Getformations()
        {
            return _context.Formations.ToList();
        }

        public List<Model.Models.Formation> GetformationsByWellboreId(int id)
        {
            return _context.Formations.Where(item => item.WellboreId == id).ToList();
        }

        public void Update(Model.Models.Formation formation)
        {
            _context.Entry(formation).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Model.Models.Formation formation)
        {
            _context.Entry(formation).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
