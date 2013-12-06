using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Web;
using System.IO;
using KnockoutBootStrap.Core.ViewModels;
using KnockoutBootStrap.Core.Services;
using KnockoutBootStrap.Core.Util;

namespace KnockoutBootStrap.Core.Services
{
    public class InventoryDataService
    {

        public IEnumerable<KnockoutBootStrap.Core.ViewModels.InventoryViewModel> GetContractList()
        {
            IList<KnockoutBootStrap.Core.ViewModels.InventoryViewModel> returList = new List<KnockoutBootStrap.Core.ViewModels.InventoryViewModel>();
            using (KnockoutBootStrap.Core.KnockoutBootStrapcoreDataContext dbContext = new KnockoutBootStrapcoreDataContext(Common.ConnString))
            {
                returList = dbContext.Inventories.Select(x => new KnockoutBootStrap.Core.ViewModels.InventoryViewModel()
                {
                    CreatedDate = x.CreatedDate,
                    ReorderPoint = x.ReorderPoint,
                    ItemName = x.ItemName,
                    Id = x.Id,
                    text = x.ItemName,
                }).ToList();
            }
            return returList.OrderByDescending(s => s.CreatedDate);
        }

        public KnockoutBootStrap.Core.ViewModels.InventoryViewModel SaveInventoryViewModel(KnockoutBootStrap.Core.ViewModels.InventoryViewModel newInventory)
        {
            KnockoutBootStrap.Core.Inventory obj = new Inventory();
            KnockoutBootStrap.Core.ViewModels.InventoryViewModel objnew = new ViewModels.InventoryViewModel();
            using (KnockoutBootStrap.Core.KnockoutBootStrapcoreDataContext dbContext = new KnockoutBootStrapcoreDataContext(Common.ConnString))
            {
                if (newInventory.UpdateCase == "UpdateCase")
                {
                    KnockoutBootStrap.Core.Inventory existingContract = dbContext.Inventories.SingleOrDefault(m => m.Id == newInventory.Id);
                    existingContract.ItemName = newInventory.ItemName;
                    existingContract.ReorderPoint = newInventory.ReorderPoint;
                    dbContext.SubmitChanges();


                }
                else
                {
                    obj.ItemName = newInventory.ItemName;
                    obj.ReorderPoint = newInventory.ReorderPoint;
                    obj.CreatedDate = DateTime.UtcNow;
                    dbContext.Inventories.InsertOnSubmit(obj);
                    dbContext.SubmitChanges();

                }
            }

            return objnew;
        }
        public KnockoutBootStrap.Core.ViewModels.InventoryViewModel UpdateInventoryViewModel(int id, KnockoutBootStrap.Core.ViewModels.InventoryViewModel newInventory)
        {
            KnockoutBootStrap.Core.Inventory obj = new Inventory();
            KnockoutBootStrap.Core.ViewModels.InventoryViewModel objnew = new ViewModels.InventoryViewModel();
            using (KnockoutBootStrap.Core.KnockoutBootStrapcoreDataContext dbContext = new KnockoutBootStrapcoreDataContext(Common.ConnString))
            {
                obj = dbContext.Inventories.Where(x => x.Id == id).SingleOrDefault();
                obj.ItemName = newInventory.ItemName;
                obj.ReorderPoint = newInventory.ReorderPoint;
                obj.CreatedDate = DateTime.UtcNow;
                dbContext.SubmitChanges();

            }
            objnew.CreatedDate = obj.CreatedDate;
            objnew.Id = obj.Id;
            objnew.ItemName = obj.ItemName;
            objnew.ReorderPoint = obj.ReorderPoint;
            return objnew;
        }
        public void DeleteInventory(int id)
        {

            using (KnockoutBootStrap.Core.KnockoutBootStrapcoreDataContext dbContext = new KnockoutBootStrapcoreDataContext(Common.ConnString))
            {
                KnockoutBootStrap.Core.Inventory obj = new Inventory();
                obj = dbContext.Inventories.Where(m => m.Id == id).FirstOrDefault();
                dbContext.Inventories.DeleteOnSubmit(obj);
                dbContext.SubmitChanges();

            }

        }
        public KnockoutBootStrap.Core.ViewModels.InventoryViewModel GetInventoryViewModel(int id)
        {
            KnockoutBootStrap.Core.Inventory obj = new Inventory();
            KnockoutBootStrap.Core.ViewModels.InventoryViewModel objnew = new ViewModels.InventoryViewModel();
            using (KnockoutBootStrap.Core.KnockoutBootStrapcoreDataContext dbContext = new KnockoutBootStrapcoreDataContext(Common.ConnString))
            {
                obj = dbContext.Inventories.Where(x => x.Id == id).SingleOrDefault();

            }
            objnew.CreatedDate = obj.CreatedDate;
            objnew.Id = obj.Id;
            objnew.ItemName = obj.ItemName;
            objnew.ReorderPoint = obj.ReorderPoint;
            return objnew;
        }
    }
}