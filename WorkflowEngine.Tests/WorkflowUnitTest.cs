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
        String AppDirectory
        {
            get
            {
                return String.Format(@"{0}\Xml\RegisterCustomer.xml", Environment.CurrentDirectory.Replace(@"\bin\Debug", String.Empty));
            }
        }

        String GetExecutionResultsPath(String fileName)
        {
            return String.Format(@"{0}\ExecutionResults\{1}", Environment.CurrentDirectory.Replace(@"\bin\Debug", String.Empty), fileName);
        }

        [TestMethod]
        public void SerializeRegisterCustomerWorkflow()
        {
            var workflowBatch = WorkflowEngineMock.GetRegisterCustomerWorkflowBatch();

            var serializer = new XmlSerializerImplementation() as ISerializer;

            var xml = serializer.Serialize(workflowBatch);

            Console.WriteLine(xml);

            // <?xml-stylesheet type='text/xsl" href="RegisterCustomer.Results.xsl" ?>
            File.WriteAllText(AppDirectory, xml);
        }

        [TestMethod]
        public void RunBasicWorkflow()
        {
            var batch = WorkflowEngineMock.GetRegisterCustomerWorkflowBatch();

            var runner = new WorkflowRunner(batch);

            var executionSummary = runner.Execute();

            var serializer = new XmlSerializerImplementation() as ISerializer;

            var xml = serializer.Serialize(executionSummary);

            Console.WriteLine(xml);

            File.WriteAllText(GetExecutionResultsPath(@"RegisterCustomer.Results.xml"), xml);
        }
    }
}
