using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class CompanyCategoryViewModel
    {
        public List<Company> companies;
        public SelectList categories;
        public string companyCategory { get; set; }
    }
}
