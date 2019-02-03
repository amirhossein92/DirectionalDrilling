using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Rig
{
    public class RigService : IRigService
    {
        private DirectionalDrillingContext _context;

        public RigService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.Rig rig)
        {
            try
            {
                _context.Rigs.Add(rig);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Rig - " + e.Message);
            }
        }

        public Model.Models.Rig GetRigById(int id)
        {
            return _context.Rigs.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.Rig> GetRigs()
        {
            return _context.Rigs.ToList();
        }

        public void Update(Model.Models.Rig rig)
        {
            var foundRig = GetRigById(rig.Id);
            if (foundRig != null)
            {
                foundRig = rig;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.Rig rig)
        {
            _context.Rigs.Remove(rig);
            _context.SaveChanges();
        }
    }
}
