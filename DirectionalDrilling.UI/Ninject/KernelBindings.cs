using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Report;
using DirectionalDrilling.UI.WindowManagement;
using Ninject.Modules;
using Prism.Events;

namespace DirectionalDrilling.UI.Ninject
{
    public class KernelBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<IWindowManagementService>().To<WindowManagementService>().InSingletonScope();

            Bind<ISectionViewReportService>().To<SectionViewReportService>();

        }
    }
}
