using System.Linq.Expressions;

namespace SmartTestProj.BLL.BackgroundService
{
    public class HangfireBackgroundJobService : IBackgroundJobService
    {
        public void Enqueue(Expression<Action> action)
        {
            Hangfire.BackgroundJob.Enqueue(action);
        }
    }

    public interface IBackgroundJobService
    {
        void Enqueue(Expression<Action> action);
    }

}
