
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TP2.Models;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP2.ViewModels;
using TP2.Models.Data;
using BW5_ExamenFinalReprise.Services;

namespace TP2.Services
{
    public class ParentServices:ServiceBaseAsync<Parent>, IParentServices
    {
        public ParentServices(TPDbContext dbContext) : base(dbContext)
        {

        }

        public new async Task DeleteAsync(int id)
        {
            var parent = await this.GetByIdAsync(id);
            if (HasAssociatedParent(id))
            {
                parent.IsDisponible = false;
                await this.EditAsync(parent);
            }
            else
            {
                await base.DeleteAsync(id);
            }
        }

        public bool HasAssociatedParent(int id)
        {
            var parent = _dbContext.Enfants.Where(x => x.IdParent == id).Any();
            return parent;
        }

        public IEnumerable<SelectListItem> ListParentDisponible()
        {
            var parentDispo = _dbContext.Parents.Where(zt => zt.IsDisponible == true).Select(t => new SelectListItem
            {
                Text = t.Nom,
                Value = t.Id.ToString()
            }).OrderBy(t => t.Text);

            return ((IEnumerable<SelectListItem>)parentDispo);
        }


    }
}
