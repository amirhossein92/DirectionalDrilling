using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;

namespace DirectionalDrilling.ViewModel
{
    public class NavigationViewModel
    {
        private UnitOfWork unitOfWork;
        public NavigationViewModel()
        {
            Wells = new ObservableCollection<Well>();
        }
        public ObservableCollection<Well> Wells { get; private set; }

        public void Load()
        {
            unitOfWork = new UnitOfWork();
        
            foreach (var item in unitOfWork.WellService.GetWells())
            {
                Wells.Add(item);
            }
        }
    }
}
