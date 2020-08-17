using CrisBlazorApp.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrisBlazorApp.Business.Models
{
    public class BlazorModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Json { get; set; }
    }
}
