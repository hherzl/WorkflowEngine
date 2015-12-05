using System;
using System.ComponentModel;

namespace WorkflowEngine.UI.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoginViewModel()
        {

        }

        private String m_domain;

        public String Domain
        {
            get
            {
                return m_domain;
            }
            set
            {
                if (m_domain != value)
                {
                    m_domain = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Domain"));
                    }
                }
            }
        }

        private String m_user;

        public String User
        {
            get
            {
                return m_user;
            }
            set
            {
                if (m_user != value)
                {
                    m_user = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("User"));
                    }
                }
            }
        }

        private String m_password;

        public String Password
        {
            get
            {
                return m_password;
            }
            set
            {
                if (m_password != value)
                {
                    m_password = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                    }
                }
            }
        }
    }
}
