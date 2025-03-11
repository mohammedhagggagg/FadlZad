using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FadlZ.Models
{
    [MetadataType(typeof(metproduct))]
    public partial class Product
    {

    }

    public class metproduct
    {
        
        [Required]
        [Display(Name ="Name")]
        public string Pro_Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Pro_Description { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string Pro_Type { get; set; }
        
        [Display(Name = "Image")]
        public string Pro_Image { get; set; }
    }

    [MetadataType(typeof(metaCat))]
    public partial class Category
    {

    }

    public class metaCat
    {
        [Display(Name ="Name")]
        [Required]
        public string Cat_Name { get; set; }
        [Display(Name ="Discription")]
        [Required]
        public string Cat_Des { get; set; }
    }

    [MetadataType(typeof(metafeedback))]
    public partial class Feedback
    {
         
    }

    public class metafeedback
    {
        [Required]
        public string Message { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Type { get; set; }
        
        
    }
    [MetadataType(typeof(metacontact))]
    public partial class Contact
    {

    }

    public class metacontact
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }

}