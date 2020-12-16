using Fipe.Generics.Factory.Interface;

namespace Fipe.Generics.Factory
{
    public class Factory : IFactory
    {
        public T GetFactory<T>() where T : class, new()
        {
            return new T();
        }
    }
}
