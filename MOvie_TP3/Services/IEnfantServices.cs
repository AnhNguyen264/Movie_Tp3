using TP2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BW5_ExamenFinalReprise.Services
{
    public interface IEnfantServices : IServiceBaseAsync<Enfant>
    {
        public Task<List<Enfant>> GetAllByParentAsync(int parentId);
        public Task<IReadOnlyList<Enfant>> GetAllIndexAsync();
        bool EnfantNameExist(string name);
    }
}
