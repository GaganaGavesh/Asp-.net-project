using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate] //methanin future date class ekatat ghilla thama meka run wenne,eke value ekat
                     //methana input value eka pass wenawa
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime()
        {//meke time eka set karanne ne...apata datetime eka ganna witharai ona e nisa set kiyana methd ekamethana ne
            
                return DateTime.Parse(String.Format("{0} {1}", Date, Time));
            
        }
    }
}