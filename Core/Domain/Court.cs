using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Court
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
