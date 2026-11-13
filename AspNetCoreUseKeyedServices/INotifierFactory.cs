namespace AspNetCoreUseKeyedServices
{
    public interface INotifierFactory
    {
        INotifier Get(string key);
    }

    public class NotifierFactory : INotifierFactory
    {
        private readonly IKeyedServiceProvider _keyedServiceProvider;

        public NotifierFactory(IServiceProvider serviceProvider)
        {
            _keyedServiceProvider = serviceProvider as IKeyedServiceProvider
                ?? throw new InvalidOperationException("不支持KeyedService");
        }

        public INotifier Get(string key)
        {
            return _keyedServiceProvider.GetRequiredKeyedService<INotifier>(key);
        }
    }
}
