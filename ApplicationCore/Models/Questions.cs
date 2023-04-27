using BackendLab01;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }
        public Surveys Surveys { get; init; }
        public string Question { get; init; }
        public List<Answers> Answers { get; init; }
    }
}
