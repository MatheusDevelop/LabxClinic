using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain.ViewModels
{
    public class FilterViewModel
    {
        public int ItemsByPage { get; set; } = 20;
        public int NumberOfPage { get; set; } = 1;
        [BindNever]
        public int TotalInDatabase { get; set; }
        public string OrderColumn { get; set; }
        public string Quicksearch { get; set; } = "";
        public string Order { get; set; } = "asc";

    }
}
