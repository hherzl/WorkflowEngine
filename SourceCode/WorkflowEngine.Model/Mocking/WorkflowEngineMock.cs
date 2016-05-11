using System.Collections.Generic;

namespace WorkflowEngine.Model.Mocking
{
    public static class WorkflowEngineMock
    {
        public static IEnumerable<WorkflowConstant> GetConstants()
        {
            return new List<WorkflowConstant>()
            {
                new WorkflowConstant { Name = "CountryName", Value = "UK" },
                new WorkflowConstant { Name = "CountryName", Value = "UK" }
            };
        }

        public static IEnumerable<WorkflowBatch> GetBatches()
        {
            return new List<WorkflowBatch>()
            {
                new WorkflowBatch
                {
                    Name = "Store workflow",
                    Description = "Orders actions"
                },
                new WorkflowBatch
                {
                    Name = "Customer common actions",
                    Description = "Request customer's information"
                }
            };
        }

        public static IEnumerable<Workflow> GetWorkflows()
        {
            return new List<Workflow>()
            {
                new Workflow
                {
                    Name = "Register customer",
                    Description = "Register new customer"
                }
            };
        }

        public static IEnumerable<WorkflowTask> GetTasks()
        {
            return new List<WorkflowTask>()
            {
                new WorkflowTask
                {
                    Name = "Add customer's data",
                    Description = "Add information for customer's fields"
                },
                new WorkflowTask
                {
                    Name = "Create order",
                    Description = "Create order for customer"
                },
                new WorkflowTask
                {
                    Name = "Request recent orders",
                    Description = "Request a list of recent orders"
                }
            };
        }

        public static WorkflowBatch GetRegisterCustomerWorkflowBatch()
        {
            var workflowBatch = new WorkflowBatch
            {
                Name = "Register Customer"
            };

            workflowBatch.Constants = new List<WorkflowConstant>()
            {
                new WorkflowConstant { Name = "CountryName", Value = "UK" }
            };

            workflowBatch.Workflows = new List<Workflow>()
            {
                new Workflow
                {
                    Name = "Authentication",
                    Description = "Authenticate user against system",
                    Tasks = new List<WorkflowTask>()
                    {
                        new WorkflowTask
                        {
                            Name = "Log In",
                            Description = "User login",
                            Parameters = new List<WorkflowParameter>()
                            {
                                new WorkflowParameter { Name = "UserName", Value = "JuanPerez" },
                                new WorkflowParameter { Name = "Password", Value = "abcd2016" }
                            },
                            Delay = 3000
                        }
                    }
                },

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
                            },
                            Delay = 5000
                        }
                    }
                },

                new Workflow
                {
                    Name = "Logging off",
                    Description = "Logging off user's session",
                    Tasks = new List<WorkflowTask>()
                    {
                        new WorkflowTask
                        {
                            Name = "Sign Out",
                            Description = "Sign out",
                            Delay = 2000
                        }
                    }
                }
            };

            return workflowBatch;
        }
    }
}
