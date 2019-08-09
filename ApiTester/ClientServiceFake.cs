using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiTester
{
    public class ClientServiceFake : IClientService
    {
        private readonly List<Client> _client;

        public ClientServiceFake()
        {
            _client = new List<Client>()
            {
                new Client() { ClientId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Jean Carlos",LastName = "Arnaud", Pedidos ="cemento, madera, varillas" },
                new Client() { ClientId = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary",LastName = "Pizza", Pedidos ="Martillo, Roble, arena" },
                new Client() { ClientId = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen ",LastName = "Diary", Pedidos ="Tornillos, llave" }
            };
        }
        public IEnumerable<Client> GetAll()
        {
            return _client;
        }

        public bool Add(Client newItem)
        {
            try
            {
                newItem.ClientId = Guid.NewGuid();
                _client.Add(newItem);
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
                var originalModel = _client.Single(x =>
                    x.ClientId == model.ClientId
                );

                originalModel.Name = model.Name;
                originalModel.LastName = model.LastName;
                originalModel.Pedidos = model.Pedidos;
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }



        public Client Get(Guid id)
        {
            return _client.Where(a => a.ClientId == id)
                .FirstOrDefault();
        }

        public bool Delete(Guid id)
        {
            try { 
            var existing = _client.First(a => a.ClientId == id);
            _client.Remove(existing);
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
