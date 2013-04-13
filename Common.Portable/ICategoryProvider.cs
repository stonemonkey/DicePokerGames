using System.Collections.Generic;

namespace Common
{
    public interface ICategoryProvider
    {
        IEnumerable<string> GetIds();

        ICategory GetCategory(string categoryId);
    }
}