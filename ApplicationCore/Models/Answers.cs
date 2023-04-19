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
    internal class Answers
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Survey")]
        public int Question_Id { get; init; }

        public string Answer { get; init; }

        public string AnswerType { get; init; }

        public virtual Questions Question { get; set; }
    }
}
