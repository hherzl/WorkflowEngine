using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using WorkflowEngine.Model;
using WorkflowEngine.Model.Execution;
using WorkflowEngine.Model.Serialization;
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
        private String m_status;

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
                if (m_executionSummary != value)
                {
                    m_executionSummary = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ExecutionSummary"));
                    }
                }
            }
        }

        public String Status
        {
            get
            {
                return m_status;
            }
            set
            {
                if (m_status != value)
                {
                    m_status = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                    }
                }
            }
        }

        private ICommand m_loadFileCommand;
        private ICommand m_executeCommand;

        public ICommand LoadFileCommand
        {
            get
            {
                return m_loadFileCommand ?? (m_loadFileCommand = new ViewModelCommand(LoadFileAction, true));
            }
        }

        public ICommand ExecuteCommand
        {
            get
            {
                return m_executeCommand ?? (m_executeCommand = new ViewModelCommand(ExecuteAction, true));
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

        public void ExecuteAction()
        {
            if (String.IsNullOrEmpty(FileName))
            {
                return;
            }

            var serializer = new XmlSerializerImplementation() as ISerializer;

            var content = File.ReadAllText(FileName);

            var batch = serializer.Deserialize<WorkflowBatch>(content);

            var runner = new WorkflowRunner(batch);

            ExecutionSummary = runner.Execute();
        }
    }
}
