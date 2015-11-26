﻿using System.Collections.Generic;
using WorkflowEngine.Model;

namespace WorkflowEngine.Tests.Mocks
{
    public static class WorkflowBatchMock
    {
        public static WorkflowBatch GetRegisterCustomerWorkflowBatch()
        {
            var workflowBatch = new WorkflowBatch();

            workflowBatch.Constants = new List<WorkflowConstant>()
            {
                new WorkflowConstant { Name = "CountryName", Value = "UK" }
            };

            workflowBatch.Workflows = new List<Workflow>()
            {
                new Workflow
                {
                    Name = "Register customer",
                    Description = "Register new customer",
                    Tasks = new List<WorkflowTask>()
                    {
                        new WorkflowTask
                        {
                            Name = "Add customer's data",
                            Description = "Add information for customer's fields",
                            Parameters = new List<WorkflowParameter>()
                            {
                                new WorkflowParameter { Name = "CompanyName", Value = "Acme" },
                                new WorkflowParameter { Name = "ContactName", Value = "John Doe" },
                                new WorkflowParameter { Name = "ContactTitle", Value = "Mr." },
                                new WorkflowParameter { Name = "Country", Constant = "CountryName" },
                            }
                        }
                    }
                }
            };

            return workflowBatch;
        }
    }
}
