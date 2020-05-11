﻿using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DataLayer.Model
{
   public class Team
    {
       [Key]
        public int Stamnummer {get;set;}
        public string Naam {get;set;}
        public string Bijnaam {get;set;}
        public string Trainer { get; set;}
        public List<Speler> spelers = new List<Speler>();

        public Team(int stamnummer, string naam, string Bijnaam, string trainer)
        {
            this.Stamnummer = stamnummer;
            this.Naam = naam;
            this.Bijnaam = Bijnaam;
            this.Trainer = trainer;

        }
        public Team() { }


    }
}
