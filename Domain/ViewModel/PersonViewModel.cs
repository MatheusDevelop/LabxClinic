using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModel
{
    public class PersonViewModel
    {
        public string Document { get; set; }
        public string Name { get; set; }
        public string ProfilePicUrl { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid Id { get; set; }
    }
}
