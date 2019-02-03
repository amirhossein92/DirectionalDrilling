using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Platform
{
    public class PlatformService : IPlatformService
    {
        private DirectionalDrillingContext _context;

        public PlatformService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.Platform platform)
        {
            try
            {
                _context.Platforms.Add(platform);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Platform - " + e.Message);
            }
        }

        public Model.Models.Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.Platform> GetPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public void Update(Model.Models.Platform platform)
        {
            var foundPlatform = GetPlatformById(platform.Id);
            if (foundPlatform != null)
            {
                foundPlatform = platform;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.Platform platform)
        {
            _context.Platforms.Remove(platform);
            _context.SaveChanges();
        }
    }
}
