using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP2.Models;
using TP2.Models.Data;

namespace BW5_ExamenFinalReprise.Services
{
    public class EnfantServices : ServiceBaseAsync<Enfant>, IEnfantServices
    {
        public EnfantServices(TPDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Enfant>> GetAllByParentAsync(int parentId)
        {
            var zombies = await _dbContext.Enfants.Where(x => x.IdParent == parentId).ToListAsync();
            return zombies;
        }

        public async Task<IReadOnlyList<Enfant>> GetAllIndexAsync()
        {
            return await _dbContext.Set<Enfant>().OrderBy(z => z.Nom).Include(z => z.Parent).ToListAsync();
        }

        bool IEnfantServices.EnfantNameExist(string name)
        {
            var memeNom = _dbContext.Enfants.Where(x => x.Nom == name).Any();
            return memeNom;
        }


    }
}
