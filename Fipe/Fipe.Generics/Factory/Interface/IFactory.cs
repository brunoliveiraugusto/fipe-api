using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Generics.Factory.Interface
{
    public interface IFactory
    {
        T GetFactory<T>() where T : class, new();
    }
}
