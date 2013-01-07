using System;
using System.Linq;
using ToolDepot.Core.Domain.Tasks;
using ToolDepot.Data;

namespace ToolDepot.Services.Tasks
{
    /// <summary>
    /// Task service
    /// </summary>
    public partial class ScheduleTaskService :CrudService<ScheduleTask>, IScheduleTaskService
    {
        #region Fields

        

        #endregion

        #region Ctor

        public ScheduleTaskService(IRepository<ScheduleTask> taskRepository)
            : base(taskRepository)
        {
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets a task by its type
        /// </summary>
        /// <param name="type">Task type</param>
        /// <returns>Task</returns>
        public virtual ScheduleTask GetTaskByType(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
                return null;

            var query = repo.Table;
            query = query.Where(st => st.Type == type);
            query = query.OrderByDescending(t => t.Id);

            var task = query.FirstOrDefault();
            return task;
        }
        #endregion
    }
}
