using Eqwel.ViewModels.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eqwel.Interfaces
{
    public interface IApiManager
    {
        Task<List<DictoinaryViewModel>> GetDictionaryAsync();
    }
}
