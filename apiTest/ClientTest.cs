using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace apiTest
{
   public  class ClientTest
    {

        public class ClientServiceFake : IClientService
        {
            private readonly List<Client> _Client;

            public ClientServiceFake()
            {
                _Client = new List<Client>()
            {
                new Client() { ClientId = 1,
                    Name = "Jean Carlos", LastName="Arnaud", Pedidos = "Madera, marmol, cemento" },
               new Client() { ClientId = 2,
                    Name = "Brian", LastName="Tifa", Pedidos = "Madera, cemento" },
               new Client() { ClientId = 1,
                    Name = "luis", LastName="Orange ", Pedidos = "Tornillos, martillo, llave" },
            };
            }

            public IEnumerable<Client> GetAll()
            {
                return _Client;
            }
            public Client Get(int id)
            {
                 var result = new Client();

                try
                {
                    result = _Client.Single(x => x.ClientId == id);
                }
                catch (System.Exception)
                {

                }

                return result;
            }
            public bool Add(Client model)
            {
                try
            {
                    _Client.Add(model);
                    _Client.SaveChanges();
                }
            catch (System.Exception)
                {
                    return false;
                }
                return true;
            }

            public bool Update(Client model)
            {
                try
                {
                    var originalModel = _Client.Single(x =>
                        x.ClientId == model.ClientId
                    );

                    originalModel.Name = model.Name;
                    originalModel.LastName = model.LastName;
                    originalModel.Pedidos = model.Pedidos;
                    _Client.Update(originalModel);
                    _Client.SaveChanges();
                }
                catch (System.Exception)
                {
                    return false;
                }
                return true;

                public Client GetById(int id)
            {
                return _Client.Where(a => a.ClientId == id)
                    .FirstOrDefault();
            }

            public void Delete(int id)
            {
                var existing = _Client.First(a => a.ClientId == id);
                _Client.Delete(existing);
            }
        }

    }
}
