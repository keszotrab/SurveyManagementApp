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
    public class Answers
    {
        [Key]
        public int Id { get; set; }
        public Questions Question { get; set; }
        public string Answer { get; init; }
        public string AnswerType { get; init; }
    }
}
