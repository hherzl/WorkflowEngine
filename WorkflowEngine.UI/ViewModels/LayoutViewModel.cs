using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Win32;
using WorkflowEngine.Model.Execution;
using WorkflowEngine.UI.Commands;

namespace WorkflowEngine.UI.ViewModels
{
    public class LayoutViewModel : INotifyPropertyChanged
    {
        public LayoutViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private String m_title;
        private String m_fileName;
        private ExecutionSummary m_executionSummary;

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

        public String FileName
        {
            get
            {
                return m_fileName;
            }
            set
            {
                if (m_fileName != value)
                {
                    m_fileName = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("FileName"));
                    }
                }
            }
        }

        public ExecutionSummary ExecutionSummary
        {
            get
            {
                return m_executionSummary;
            }
            set
            {
                if (m_executionSummary != null)
                {
                    m_executionSummary = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ExecutionSummary"));
                    }
                }
            }
        }

        private ICommand m_loadFileCommand;

        public ICommand LoadFileCommand
        {
            get
            {
                return m_loadFileCommand ?? (m_loadFileCommand = new ViewModelCommand(LoadFileAction, true));
            }
        }

        public void LoadFileAction()
        {
            var dialog = new OpenFileDialog()
            {
                DefaultExt = ".xml"
            };

            var result = dialog.ShowDialog();

            if (result == true)
            {
                FileName = dialog.FileName;
            }
        }
    }
}
