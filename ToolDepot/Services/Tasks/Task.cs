using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Integration.Mvc;
using ToolDepot.Core;
using ToolDepot.Core.Domain.Tasks;
using ToolDepot.Services.Logging;


namespace ToolDepot.Services.Tasks
{
    /// <summary>
    /// Task
    /// </summary>
    public partial class Task
    {
        /// <summary>
        /// Ctor for Task
        /// </summary>
        private Task()
        {
            this.Enabled = true;
        }

        /// <summary>
        /// Ctor for Task
        /// </summary>
        /// <param name="task">Task </param>
        public Task(ScheduleTask task)
        {
            this.Type = task.Type;
            this.Enabled = task.Enabled;
            this.StopOnError = task.StopOnError;
            this.Name = task.Name;
        }

        public object ResolveUnregistered(ILifetimeScope timerScope, Type type)
        {
            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                try
                {
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    foreach (var parameter in parameters)
                    {
                        var service = timerScope.Resolve(parameter.ParameterType);
                        if (service == null) 
                            throw new AppException("Unkown dependency");
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (AppException)
                {

                }
            }
            throw new AppException("No contructor was found that had all the dependencies satisfied.");
        }
        private ITask CreateTask(ILifetimeScope timerScope)
        {
            ITask task = null;
            if (this.Enabled)
            {
                var type2 = System.Type.GetType(this.Type);
                if (type2 != null)
                {
                    object instance;
                    if (!timerScope.TryResolve(type2, out instance))
                    {
                        instance = ResolveUnregistered(timerScope,type2);
                    }

                    task = instance as ITask;
                }
            }
            return task;
        }

        /// <summary>
        /// Executes the task
        /// </summary>
        public void Execute()
        {
            this.IsRunning = true;
            using (var timerScope = AutofacDependencyResolver.Current.ApplicationContainer.BeginLifetimeScope("httpRequest"))
            {
                //var scheduleTaskService = DependencyResolver.Current.GetService<IScheduleTaskService>();
                var scheduleTaskService = timerScope.Resolve<IScheduleTaskService>();
                var scheduleTask = scheduleTaskService.GetTaskByType(this.Type);

                
                try
                {
                    var task = this.CreateTask(timerScope);
                    if (task != null)
                    {
                        this.LastStartUtc = DateTime.UtcNow;
                        if (scheduleTask != null)
                        {
                            //update appropriate datetime properties
                            scheduleTask.LastStartUtc = this.LastStartUtc;
                            scheduleTaskService.Update(scheduleTask);
                        }

                        //execute task
                        task.Execute();
                        this.LastEndUtc = this.LastSuccessUtc = DateTime.UtcNow;
                    }
                }
                catch (Exception exc)
                {
                    this.Enabled = !this.StopOnError;
                    this.LastEndUtc = DateTime.UtcNow;

                    //log error
                    var logger = timerScope.Resolve<ILogger>();
                    logger.Error(
                        string.Format("Error while running the '{0}' schedule task. {1}", this.Name, exc.Message), exc);
                }

                if (scheduleTask != null)
                {
                    //update appropriate datetime properties
                    scheduleTask.LastEndUtc = this.LastEndUtc;
                    scheduleTask.LastSuccessUtc = this.LastSuccessUtc;
                    scheduleTaskService.Update(scheduleTask);
                }
                
                this.IsRunning = false;
            }
        }

        /// <summary>
        /// A value indicating whether a task is running
        /// </summary>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Datetime of the last start
        /// </summary>
        public DateTime? LastStartUtc { get; private set; }

        /// <summary>
        /// Datetime of the last end
        /// </summary>
        public DateTime? LastEndUtc { get; private set; }

        /// <summary>
        /// Datetime of the last success
        /// </summary>
        public DateTime? LastSuccessUtc { get; private set; }

        /// <summary>
        /// A value indicating type of the task
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// A value indicating whether to stop task on error
        /// </summary>
        public bool StopOnError { get; private set; }

        /// <summary>
        /// Get the task name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A value indicating whether the task is enabled
        /// </summary>
        public bool Enabled { get; private set; }
    }
}
