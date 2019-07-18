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
        public HttpPostedFileBase ImageFile { get; set; }
        //after the above, go to view, using razer, add the <input type="file" name="ImageFile" required>
    }

    public class FranchiseMetaData
    {
        [DisplayName("First Appearance")]
        [Required(ErrorMessage = "Please enter the year of First Appearance")]
        [RegularExpression(@"^\b[1-9]\d{3}\b", ErrorMessage = "Please enter digitss only")]
        public int FirstAppearance { get; set; }

        [DisplayFormat(NullDisplayText = "logo is not specified")]
        [DisplayName("Upload File")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Please enter the Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the Origin Country")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Please enter the toy type")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please enter the Creator of the toy")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please enter alphabets only")]
        public string CreatedBy { get; set; }
        

        [DisplayName("Likes")]
        public int Count { get; set; }

    }
}