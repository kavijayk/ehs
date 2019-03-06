using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    public class MultipleModel
    {
        [Required]
        public Seller sellerModel { get; set; }
        [Required]
        public User userModel { get; set; }
        [Required]
        public State stateModel { get; set; }
        [Required]
        public City cityModel { get; set; }
        [Required]
        public Buyer buyerModel { get; set; }
    }
}