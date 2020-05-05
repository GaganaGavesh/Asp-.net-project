using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

        
        public ApplicationUser Artist { get; set; }
        //methanin gannawa asp.net wala hadala tyna users gig property ekata gannawa
        //foreign key property ekak inroduce karanna thama hadanne.ethakota artist id eka ehemama model eken ganna ahaki
        //amathara database call ekak ona wenne nee
        [Required]
        public string ArtistId { get; set; }
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        public Genre Genre { get; set; }//Methanin thama Genre property ekath ekka sambanda wenne,mehema dammama 
                                        //foreign key widiyata watenawa
        [Required]
        public byte GenreId { get; set; }
        //methanin gannawa asp.net wala hadala tyna users gig property ekata gannawa
        //foreign key property ekak inroduce karanna thama hadanne.ethakota genre id eka ehemama model eken ganna ahaki
        //amathara database call ekak ona wenne nee

        //////////Mehema model eka edit kalama aniwa migration ekak hadala db eka updaet karanna onaaa/////////

    }
}