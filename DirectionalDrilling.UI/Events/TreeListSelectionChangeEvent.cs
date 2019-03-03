using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.DataProviders;
using Prism.Events;

namespace DirectionalDrilling.UI.Events
{
    public class TreeListSelectionChangeEvent : PubSubEvent<TreeListSelectionItem>
    {
    }

    public class TreeListSelectionItem
    {
        public TreeListStatus SelectedObject { get; set; }
        public int SelectedObjectId { get; set; }

        public TreeListSelectionItem(TreeListStatus selectedObject, int selectedObjectId)
        {
            SelectedObject = selectedObject;
            SelectedObjectId = selectedObjectId;
        }
    }
}
