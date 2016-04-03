using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ISerializer serializer;

        public LayoutViewModel()
        {
            serializer = new XmlSerializerImplementation() as ISerializer;
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

                    System.Diagnostics.Debug.WriteLine("{0} - {1}", DateTime.Now, value);
                }
            }
        }

        private  List<ExecutionResult> m_results;

        public List<ExecutionResult> Results
        {
            get
            {
                return m_results ?? (m_results = new List<ExecutionResult>());
            }
            set
            {
                if (m_results != value)
                {
                    m_results = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Results"));
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
                return m_loadFileCommand ?? (m_loadFileCommand = new ViewModelAsyncCommand(LoadFileAction, true));
            }
        }

        public ICommand ExecuteCommand
        {
            get
            {
                return m_executeCommand ?? (m_executeCommand = new ViewModelAsyncCommand(ExecuteAction, true));
            }
        }

        public void LoadFileAction()
        {
            var dialog = new OpenFileDialog()
            {
                DefaultExt = String.Format(".{0}", serializer.FileExtension)
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

            var batch = serializer.DeserializeFrom<WorkflowBatch>(FileName);

            var runner = new WorkflowRunner(batch);

            runner.StartProcessWorkflow += (source, args) =>
            {
                Status = String.Format("Starting workflow: '{0}'", args.Workflow.Name);
            };

            runner.ProcessWorkflow += (source, args) =>
            {
                Status = String.Format("Processing workflow: '{0}'", args.Workflow.Name);
            };

            runner.EndProcessWorkflow += (source, args) =>
            {
                Status = String.Format("Ending workflow: '{0}'", args.Workflow.Name);
            };

            ExecutionSummary = runner.Execute();
        }
    }
}
