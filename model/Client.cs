﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pedidos { get; set; }
    }
}
