using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public interface ISellingService
    {
        IEnumerable<Selling> GetAll();
        Selling Get(Guid id);
        bool Add(Selling model);
        bool Update(Selling model);
        bool Delete(Guid id);
    }

    public class SellingService : ISellingService
    {
        private readonly ClientDbContext _clientDbContext;
        public SellingService(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
        }
        public IEnumerable<Selling> GetAll()
        {
            var result = new List<Selling>();

            try
            {
                result = _clientDbContext.Selling.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Selling Get(Guid id)
        {
            var result = new Selling();

            try
            {
                result = _clientDbContext.Selling.Single(x => x.SellingId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Selling model)
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
        public bool Update(Selling model)
        {
            try
            {
                var originalModel = _clientDbContext.Selling.Single(x =>
                    x.SellingId == model.SellingId
                );

                originalModel.ClientId = model.ClientId;
                originalModel.ProductID = model.ProductID;
                originalModel.Total = model.Total
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
        public bool Delete(Guid id)
        {
            try
            {
                _clientDbContext.Entry(new Selling { SellingId = id }).State = EntityState.Deleted; ;
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
