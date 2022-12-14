using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public DateTime LastUpdateOn {get; set;}

        public int LastUpdatedBy { get; set; }
    }
}