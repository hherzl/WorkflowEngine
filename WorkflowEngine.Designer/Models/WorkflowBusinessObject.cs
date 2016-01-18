using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowBusinessObject : IWorkflowBusinessObject
    {
        private IWorkflowManagerUow Uow;

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

        public async Task<IEnumerable<WorkflowBatch>> GetWorkflowBatches()
        {
            return await Task.Run(() =>
            {
                return Uow.WorkflowBatchRepository.GetAll();
            });
        }

        public async Task<WorkflowBatch> GetWorkflowBatch(WorkflowBatch viewModel)
        {
            return await Task.Run(() =>
            {
                return Uow.WorkflowBatchRepository.Get(new WorkflowBatch { ID = viewModel.ID });
            });
        }

        public async Task<WorkflowBatch> AddWorkflowBatch(WorkflowBatch entity)
        {
            Uow.WorkflowBatchRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<WorkflowBatch> UpdateWorkflowBatch(Int32 id, WorkflowBatch changes)
        {
            var entity = await GetWorkflowBatch(new WorkflowBatch { ID = id });

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                await Uow.CommitChangesAsync();
            }

            return await Task.Run(() => { return entity; });
        }

        public async Task<WorkflowBatch> DeleteWorkflowBatch(Int32 id, WorkflowBatch changes)
        {
            var entity = await GetWorkflowBatch(new WorkflowBatch { ID = id });

            if (entity != null)
            {
                Uow.WorkflowBatchRepository.Delete(entity);

                await Uow.CommitChangesAsync();
            }

            return await Task.Run(() => { return entity; });
        }

        public async Task<WorkflowBatch> CloneWorkflowBatch(Int32 id)
        {
            var source = await GetWorkflowBatch(new WorkflowBatch { ID = id });

            var batch = new WorkflowBatch();

            using (var transaction = Uow.DbContext.Database.BeginTransaction())
            {
                try
                {
                    batch.Name = String.Format("Clone of {0}", source.Name);
                    batch.Description = source.Description;

                    await AddWorkflowBatch(batch);

                    if (source.Constants != null && source.Constants.Count > 0)
                    {
                        foreach (var item in source.Constants)
                        {
                            batch.Constants.Add(new WorkflowConstant { Name = item.Name, Description = item.Description, Value = item.Value });
                        }

                        await Uow.CommitChangesAsync();
                    }

                    if (source.Workflows != null && source.Workflows.Count > 0)
                    {
                        foreach (var item in source.Workflows)
                        {
                            batch.Workflows.Add(new Workflow { Name = item.Name, Description = item.Description, WorkflowBatchID = batch.ID });
                        }

                        await Uow.CommitChangesAsync();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }

            return await Task.Run(() =>
            {
                return batch;
            });
        }

        public async Task<IEnumerable<Workflow>> GetWorkflows()
        {
            return await Task.Run(() =>
            {
                return Uow.WorkflowRepository.GetAll();
            });
        }

        public async Task<Workflow> GetWorkflow(Workflow entity)
        {
            return await Task.Run(() =>
            {
                return Uow.WorkflowRepository.Get(new Workflow { ID = entity.ID });
            });
        }

        public async Task<Workflow> AddWorkflow(Workflow entity)
        {
            Uow.WorkflowRepository.Add(entity);

            await Uow.CommitChangesAsync();

            return entity;
        }

        public async Task<Workflow> UpdateWorkflow(Int32 id, Workflow changes)
        {
            var entity = await GetWorkflow(new Workflow { ID = id });

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                await Uow.CommitChangesAsync();
            }

            return await Task.Run(() => { return entity; });
        }

        public async Task<IEnumerable<WorkflowTask>> GetWorkflowTasks()
        {
            return await Task.Run(() =>
            {
                return Uow.WorkflowTaskRepository.GetAll();
            });
        }

        public async Task<IEnumerable<WorkflowConstant>> GetWorkflowConstants()
        {
            return await Task.Run(() =>
            {
                return Uow.WorkflowConstantRepository.GetAll();
            });
        }
    }
}
