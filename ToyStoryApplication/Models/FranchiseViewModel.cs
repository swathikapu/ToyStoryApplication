using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace ToyStoryApplication.Models
{
    [MetadataType(typeof(FranchiseMetaData))]
    public partial class Franchise
    {
        //the following proprety is added to upload image
        [Required(ErrorMessage = "Please upload a logo image")]
        public HttpPostedFileBase ImageFile { get; set; }
        //after the above, go to view, using razer, add the <input type="file" name="ImageFile" required>
    }

    public class FranchiseMetaData
    {
        [DisplayName("Year")]
        [Required(ErrorMessage = "Please enter the year of first appearance")]
        [RegularExpression(@"^\b[1-9]\d{3}\b", ErrorMessage = "Please enter digitss only")]
        public int FirstAppearance { get; set; }

        [DisplayFormat(NullDisplayText = "logo is not specified")]
        //[Required(ErrorMessage = "Please upload a logo image")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Please enter the toy name")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*$", ErrorMessage = "Please enter alphabets only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter country of origin")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*$", ErrorMessage = "Please enter alphabets only")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Please enter toy type")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*$", ErrorMessage = "Please enter alphabets only")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter creator of the toy")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s]*$", ErrorMessage = "Please enter alphabets only")]
        [DisplayName("Creator")]
        public string CreatedBy { get; set; }

        [DisplayName("Likes")]
        public int Count { get; set; }

    }
}