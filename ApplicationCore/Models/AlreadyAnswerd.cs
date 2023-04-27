using BackendLab01;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    /// Pytanie czy ta klasa modelu jest wogle potrzebna?
    public class AlreadyAnswerd
    {
        public int Id { get; set; }
        public Users Users { get; set; }
        public Answers Answer { get; set; }
        //public string Email { get; set; } //czy jest potrzebne???
    }
}

