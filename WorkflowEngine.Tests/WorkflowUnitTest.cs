using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowEngine.Model.Execution;
using WorkflowEngine.Model.Mocking;
using WorkflowEngine.Model.Serialization;

namespace WorkflowEngine.Tests
{
    [TestClass]
    public class WorkflowUnitTest
    {
        private ISerializer serializer;

        public WorkflowUnitTest()
        {

        }

        private String AppDirectory
        {
            get
            {
                return String.Format(@"{0}\Xml\RegisterCustomer.{1}", Environment.CurrentDirectory.Replace(@"\bin\Debug", String.Empty), serializer.FileExtension);
            }
        }

        private String GetExecutionResultsPath(String fileName)
        {
            return String.Format(@"{0}\ExecutionResults\{1}", Environment.CurrentDirectory.Replace(@"\bin\Debug", String.Empty), fileName);
        }

        [TestInitialize]
        public void Initialize()
        {
            serializer = new XmlSerializerImplementation() as ISerializer;
        }

        [TestMethod]
        public void SerializeRegisterCustomerWorkflow()
        {
            var workflowBatch = WorkflowEngineMock.GetRegisterCustomerWorkflowBatch();

            var serialized = serializer.Serialize(workflowBatch);

            Console.WriteLine(serialized);

            File.WriteAllText(AppDirectory, serialized);
        }

        [TestMethod]
        public void RunBasicWorkflow()
        {
            var batch = WorkflowEngineMock.GetRegisterCustomerWorkflowBatch();

            var runner = new WorkflowRunner(batch);

            var executionSummary = runner.Execute();

            var serialized = serializer.Serialize(executionSummary);

            Console.WriteLine(serialized);

            File.WriteAllText(GetExecutionResultsPath(String.Format("RegisterCustomer.Results.{0}", serializer.FileExtension)), serialized);
        }
    }
}
