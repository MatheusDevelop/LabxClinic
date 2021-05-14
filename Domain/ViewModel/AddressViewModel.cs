using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
    }
}
