namespace AspNetCoreUseKeyedServices
{
    public interface INotifier
    {
        Task SendAsync(string message);
    }

    /// <summary>
    /// 短信通知器
    /// </summary>
    public class SmsNotifier : INotifier
    {
        public Task SendAsync(string message)
        {
            Console.WriteLine($"【短信】发送：{message}");
            return Task.CompletedTask;
        }
    }
     
    /// <summary>
    /// 邮件通知器
    /// </summary>
    public class EmailNotifier : INotifier
    {
        public Task SendAsync(string message)
        {
            Console.WriteLine($"【邮件】发送：{message}");
            return Task.CompletedTask;
        }
    }
}
