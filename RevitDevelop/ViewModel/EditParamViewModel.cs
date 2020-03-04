using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.ViewModel
{
    public class EditParamViewModel : Screen
    {
        public Action<string, string, string> EditParam;

        private string _length;
        public string Length
        {
            get { return _length; }
            set
            {
                _length = value;
                NotifyOfPropertyChange(nameof(Length));
            }
        }

        private string _width;
        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(nameof(Width));
            }
        }

        private string _heigth;
        public string Height
        {
            get { return _heigth; }
            set
            {
                _heigth = value;
                NotifyOfPropertyChange(nameof(Height));
            }
        }

        public bool BtnSave()
        {
            if (EditParam != null && !string.IsNullOrEmpty(Length) && !string.IsNullOrEmpty(Width) && !string.IsNullOrEmpty(Height))
            {
                EditParam(Length, Width, Height);
                return true;
            }
            return false;
        }

        public EditParamViewModel(string len, string wid, string hei)
        {
            Length = len;Width = wid;Height = hei;
        }
    }
}
