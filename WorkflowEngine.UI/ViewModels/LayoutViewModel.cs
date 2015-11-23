using System;
using System.ComponentModel;

namespace WorkflowEngine.UI.ViewModels
{
    public class LayoutViewModel : INotifyPropertyChanged
    {
        public LayoutViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private String m_title;

        public String Title
        {
            get
            {
                return m_title;
            }
            set
            {
                if (m_title != value)
                {
                    m_title = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                    }
                }
            }
        }
    }
}
