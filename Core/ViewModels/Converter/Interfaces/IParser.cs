using System.Collections.Generic;

namespace Core.ViewModels.Converter.Interfaces
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
