using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.UI.Base
{
    public class TabItemBase : Prism.Mvvm.BindableBase
    {
        private string _header;
        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        private object _content;
        public object Content{
            get => _content;
            set => SetProperty(ref _content, value);
        }

        public TabItemBase(string header, object content)
        {
            Header = header;
            Content = content;
        }

        public TabItemBase()
        {
            
        }
    }
}
