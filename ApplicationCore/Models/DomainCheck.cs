using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class DomainCheck
    {
        public int Id { get; set; }

        public Surveys Survey { get; init; } 

        public string Domain_Name { get; init; }

    }
}
