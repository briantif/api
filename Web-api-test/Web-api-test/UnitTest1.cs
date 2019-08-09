using System;
using Xunit;

namespace Web_api_test
{
    public class UnitTest1
    {
      
        
            public class ClientServiceFake : IClientService
        {
            private readonly List<ClientItem> _Client;

            public ClientServiceFake()
            {
                _Client = new List<ClientItem>()
            {
                new ClientItem() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Manufacturer="Orange Tree", Price = 5.00M },
                new ClientItem() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Manufacturer="Cow", Price = 4.00M },
                new ClientItem() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Manufacturer="Uncle Mickey", Price = 12.00M }
            };
            }

            public IEnumerable<ClientItem> GetAllItems()
            {
                return _Client;
            }

            public ClientItem Add(ClientItem newItem)
            {
                newItem.Id = Guid.NewGuid();
                _Client.Add(newItem);
                return newItem;
            }

            public ClientItem GetById(Guid id)
            {
                return _Client.Where(a => a.Id == id)
                    .FirstOrDefault();
            }

            public void Remove(Guid id)
            {
                var existing = _Client.First(a => a.Id == id);
                _Client.Remove(existing);
            }
        }
    
    }
}
