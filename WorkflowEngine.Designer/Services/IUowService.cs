﻿using WorkflowEngine.Designer.Models.Contracts;

namespace WorkflowEngine.Designer.Services
{
    public interface IUowService
    {
        IWorkflowManagerUow GetWorkflowManagerUow();
    }
}
