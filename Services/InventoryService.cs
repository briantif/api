using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface IInventoyService
    {
        IEnumerable<Inventory> GetAll();
        Inventory Get(int id);
        bool Add(Inventory model);
        bool Update(Inventory model);
        bool Delete(int id);

    }

    public class InventoryService
    {

        private readonly ClientDbContext _clientDbContext;
        public InventoryService(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
        }
        public IEnumerable<Inventory> GetAll()
        {
            var result = new List<Inventory>();

            try
            {
                result = _clientDbContext.Inventory.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Inventory Get(int id)
        {
            var result = new Inventory();

            try
            {
                result = _clientDbContext.Inventory.Single(x => x.InventoryId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Inventory model)
        {
            try
            {
                _clientDbContext.Add(model);
                _clientDbContext.SaveChanges();
            }
            catch (System.Exception)

            {
                return false;
            }
            return true;
        }
        public bool Update(Inventory model)
        {
            try
            {
                var originalModel = _clientDbContext.Inventory.Single(x =>
                    x.InventoryId == model.InventoryId
                );


                originalModel.ProductID = model.ProductID;
                originalModel.Quantity = model.Quantity
;
                _clientDbContext.Update(originalModel);
                _clientDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                _clientDbContext.Entry(new Inventory { InventoryId = id }).State = EntityState.Deleted; ;
                _clientDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

    }
}
