﻿using System;

namespace WorkflowEngine.Model
{
    public class WorkflowParameter
    {
        public WorkflowParameter()
        {

        }

        public String Name { get; set; }

        public String Description { get; set; }

        public String Value { get; set; }

        public String Constant { get; set; }
    }
}
