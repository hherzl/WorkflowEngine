using System;
using System.Collections.Generic;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowBusinessObject : IWorkflowBusinessObject
    {
        private readonly IWorkflowManagerUow Uow;

        public WorkflowBusinessObject(IWorkflowManagerUow uow)
        {
            Uow = uow;
        }

        public void Release()
        {
            if (Uow != null)
            {
                Uow.Dispose();
            }
        }

        public IEnumerable<WorkflowBatch> GetWorkflowBatches()
        {
            return Uow.WorkflowBatchRepository.GetAll();
        }

        public WorkflowBatch GetWorkflowBatch(WorkflowBatch viewModel)
        {
            return Uow.WorkflowBatchRepository.Get(new WorkflowBatch(viewModel.ID));
        }

        public WorkflowBatch AddWorkflowBatch(WorkflowBatch entity)
        {
            Uow.WorkflowBatchRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public WorkflowBatch UpdateWorkflowBatch(Int32 id, WorkflowBatch changes)
        {
            var entity = GetWorkflowBatch(new WorkflowBatch(id));

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                Uow.CommitChanges();
            }

            return entity;
        }

        public WorkflowBatch DeleteWorkflowBatch(Int32 id, WorkflowBatch changes)
        {
            var entity = GetWorkflowBatch(new WorkflowBatch(id));

            if (entity != null)
            {
                Uow.WorkflowBatchRepository.Delete(entity);

                Uow.CommitChanges();
            }

            return entity;
        }

        public WorkflowBatch CloneWorkflowBatch(Int32 id)
        {
            var source = GetWorkflowBatch(new WorkflowBatch(id));

            var batch = new WorkflowBatch();

            using (var transaction = Uow.BeginTransaction())
            {
                try
                {
                    batch.Name = String.Format("Clone of {0}", source.Name);
                    batch.Description = source.Description;

                    AddWorkflowBatch(batch);

                    if (source.Constants != null && source.Constants.Count > 0)
                    {
                        foreach (var item in source.Constants)
                        {
                            batch.Constants.Add(new WorkflowConstant { Name = item.Name, Description = item.Description, Value = item.Value });
                        }

                        Uow.CommitChanges();
                    }

                    if (source.Workflows != null && source.Workflows.Count > 0)
                    {
                        foreach (var item in source.Workflows)
                        {
                            batch.Workflows.Add(new Workflow { Name = item.Name, Description = item.Description, WorkflowBatchID = batch.ID });
                        }

                        Uow.CommitChanges();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return batch;
        }

        public IEnumerable<Workflow> GetWorkflows()
        {
            return Uow.WorkflowRepository.GetAll();
        }

        public Workflow GetWorkflow(Workflow entity)
        {
            return Uow.WorkflowRepository.Get(new Workflow { ID = entity.ID });
        }

        public Workflow AddWorkflow(Workflow entity)
        {
            Uow.WorkflowRepository.Add(entity);

            Uow.CommitChanges();

            return entity;
        }

        public Workflow UpdateWorkflow(Int32 id, Workflow changes)
        {
            var entity = GetWorkflow(new Workflow { ID = id });

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                Uow.CommitChanges();
            }

            return entity;
        }

        public IEnumerable<WorkflowTask> GetWorkflowTasks()
        {
            return Uow.WorkflowTaskRepository.GetAll();
        }

        public IEnumerable<WorkflowConstant> GetWorkflowConstants()
        {
            return Uow.WorkflowConstantRepository.GetAll();
        }
    }
}
