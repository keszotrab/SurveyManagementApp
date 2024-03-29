﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public  class ClosedUserAnswers
    {

        public int Id { get; set; }
        public Users? User { get; set; }
        public Answers Answer { get; set; }
        public string? Email { get; set; }

        public ClosedUserAnswers(int id, Users? user, Answers answer, string? email)
        {
            Id = id;
            User = user;
            Answer = answer;
            Email = email;
        }


    }
}
