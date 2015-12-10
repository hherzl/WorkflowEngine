using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowEngine.Designer.Models.Contracts;
using WorkflowEngine.Model;

namespace WorkflowEngine.Designer.Models
{
    public class WorkflowBusinessObject : IWorkflowBusinessObject
    {
        private IWorkflowManagerUow m_uow;

        public WorkflowBusinessObject(IWorkflowManagerUow uow)
        {
            m_uow = uow;
        }

        public async Task<IEnumerable<WorkflowBatch>> GetWorkflowBatches()
        {
            return await Task.Run(() =>
            {
                return m_uow.WorkflowBatchRepository.GetAll();
            });
        }

        public async Task<WorkflowBatch> GetWorkflowBatch(WorkflowBatch viewModel)
        {
            return await Task.Run(() =>
            {
                return m_uow.WorkflowBatchRepository.Get(new WorkflowBatch { ID = viewModel.ID });
            });
        }

        public async Task<WorkflowBatch> AddWorkflowBatch(WorkflowBatch entity)
        {
            m_uow.WorkflowBatchRepository.Add(entity);

            await m_uow.CommitChangesAsync();

            return entity;
        }

        public async Task<WorkflowBatch> UpdateWorkflowBatch(Int32 id, WorkflowBatch changes)
        {
            var entity = await GetWorkflowBatch(new WorkflowBatch { ID = id });

            if (entity != null)
            {
                entity.Name = changes.Name;
                entity.Description = changes.Description;

                await m_uow.CommitChangesAsync();
            }

            return await Task.Run(() => { return entity; });
        }

        public async Task<WorkflowBatch> DeleteWorkflowBatch(Int32 id, WorkflowBatch changes)
        {
            var entity = await GetWorkflowBatch(new WorkflowBatch { ID = id });

            if (entity != null)
            {
                m_uow.WorkflowBatchRepository.Delete(entity);

                await m_uow.CommitChangesAsync();
            }

            return await Task.Run(() => { return entity; });
        }

        public async Task<WorkflowBatch> CloneWorkflowBatch(Int32 id)
        {
            var source = await GetWorkflowBatch(new WorkflowBatch { ID = id });

            var batch = new WorkflowBatch();

            using (var transaction = m_uow.DbContext.Database.BeginTransaction())
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

                        await m_uow.CommitChangesAsync();
                    }

                    if (source.Workflows != null && source.Workflows.Count > 0)
                    {
                        foreach (var item in source.Workflows)
                        {
                            batch.Workflows.Add(new Workflow { Name = item.Name, Description = item.Description, WorkflowBatchID = batch.ID });
                        }

                        await m_uow.CommitChangesAsync();
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
    }
}
