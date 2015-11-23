using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkflowEngine.Model.Execution;
using WorkflowEngine.Model.Serialization;
using WorkflowEngine.Tests.Mocks;

namespace WorkflowEngine.Tests
{
    [TestClass]
    public class WorkflowUnitTest
    {
        String AppDirectory
        {
            get
            {
                return String.Format(@"{0}\Xml\RegisterCustomer.xml", Environment.CurrentDirectory.Replace(@"\bin\Debug", String.Empty));
            }
        }

        [TestMethod]
        public void SerializeRegisterCustomerWorkflow()
        {
            var workflowBatch = WorkflowBatchMock.GetRegisterCustomerWorkflowBatch();

            var serializer = new XmlSerializerImplementation() as ISerializer;

            var xml = serializer.Serialize(workflowBatch);

            Console.WriteLine(xml);

            // <?xml-stylesheet type='text/xsl" href="RegisterCustomer.Results.xsl" ?>
            File.WriteAllText(AppDirectory, xml);
        }

        [TestMethod]
        public void RunBasicWorkflow()
        {
            var runner = new WorkflowRunner(WorkflowBatchMock.GetRegisterCustomerWorkflowBatch());

            var executionSummary = runner.Execute();

            var serializer = new XmlSerializerImplementation() as ISerializer;

            var xml = serializer.Serialize(executionSummary);

            Console.WriteLine(xml);

            File.WriteAllText(String.Format(@"{0}\ExecutionResults\RegisterCustomer.Results.xml", Environment.CurrentDirectory.Replace(@"\bin\Debug", String.Empty)), xml);
        }
    }
}
