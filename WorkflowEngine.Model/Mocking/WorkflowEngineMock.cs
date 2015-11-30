﻿using System.Collections.Generic;

namespace WorkflowEngine.Model.Mocking
{
    public static class WorkflowEngineMock
    {
        public static IEnumerable<WorkflowTask> GetTasks()
        {
            return new List<WorkflowTask>()
            {
                new WorkflowTask { Name = "Add customer's data", Description = "Add information for customer's fields" },
                new WorkflowTask { Name = "Create order", Description = "Create order for customer" },
                new WorkflowTask { Name = "Request recent orders", Description = "Request a list of recent orders" }
            };
        }

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