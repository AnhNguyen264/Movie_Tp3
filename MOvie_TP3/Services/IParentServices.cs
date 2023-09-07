using BW5_ExamenFinalReprise.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP2.Models;

namespace TP2.Services
{
    public interface IParentServices: IServiceBaseAsync<Parent>
    {

        Task DeleteAsync(int id);
        bool HasAssociatedParent(int id);

        IEnumerable<SelectListItem> ListParentDisponible();
    }
}
