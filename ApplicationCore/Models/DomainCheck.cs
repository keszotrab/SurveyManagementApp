using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendLab01;

namespace ApplicationCore.Models
{
    internal class DomainCheck
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Survey")]
        public int Survey_Id { get; init; }

        public string Domain_Name { get; init; }

        public virtual Surveys Survey { get; set; }

    }
}
