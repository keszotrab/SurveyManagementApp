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
    public class DomainCheck
    {
        [Key]
        public int Id { get; set; }

        public Surveys Survey { get; init; } //Czy to jest potrzebne? Chyba? Potrafie sobie wyobrazić działanie bez tego?

        public string Domain_Name { get; init; }

    }
}
