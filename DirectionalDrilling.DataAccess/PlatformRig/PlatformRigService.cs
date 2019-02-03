using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.PlatformRig
{
    public class PlatformRigService : IPlatformRigService
    {
        private DirectionalDrillingContext _context;

        public PlatformRigService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.PlatformRig platformRig)
        {
            try
            {
                _context.PlatformRigs.Add(platformRig);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding PlatformRig - " + e.Message);
            }
        }

        public Model.Models.PlatformRig GetPlatformRigById(int id)
        {
            return _context.PlatformRigs.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.PlatformRig> GetPlatformRigs()
        {
           return _context.PlatformRigs.ToList();
        }

        public void Update(Model.Models.PlatformRig platformRig)
        {
            var foundPlatformRig = GetPlatformRigById(platformRig.Id);
            if (foundPlatformRig != null)
            {
                foundPlatformRig = platformRig;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.PlatformRig platformRig)
        {
            _context.PlatformRigs.Remove(platformRig);
            _context.SaveChanges();
        }
    }
}
