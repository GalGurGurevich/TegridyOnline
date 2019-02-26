using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.ViewModels
{
    public class EditWeedViewModel
    {
        public int? ID { get; set; }
        public WeedType WeedType { get; set; }
        public WeedKind WeedKind { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(15, ErrorMessage = "Must describe the Product between 0 to 15 chars")]
        public string Description { get; set; }

        [MinLength(20, ErrorMessage = "Long Description must be atleast 20 chars long!")]
        public string LongDescription { get; set; }

        [Range(0, 10, ErrorMessage = "Weed must be of minimum strength 0 and the most Powerfull weed of'em all is 10!")]
        public int WeedStrength { get; set; }

        [Range(0, 255, ErrorMessage = "Price must start from 0 up to 255 you expensive bastard!")]
        public int PriceForOunce { get; set; }

        public int Quantity { get; set; }

        public byte[] Pic { get; set; }
        public byte[] Pic2 { get; set; }
        public byte[] Pic3 { get; set; }

        public EditWeedViewModel()
        {
            ID = 0;
        }

        public EditWeedViewModel(Weed weed)
        {
            ID = weed.WeedId;
            WeedType = weed.WeedType;
            WeedKind = weed.WeedKind;
            Title = weed.Title;
            Description = weed.Description;
            LongDescription = weed.LongDescription;
            WeedStrength = weed.WeedStrength;
            PriceForOunce = weed.PriceForOunce;
            Pic = weed.Pic;
            Pic2 = weed.Pic2;
            Pic3 = weed.Pic3;
        }
    }
}