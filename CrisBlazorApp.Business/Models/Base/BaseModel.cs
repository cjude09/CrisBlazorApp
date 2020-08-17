using System;
using System.Collections.Generic;
using System.Text;

namespace CrisBlazorApp.Business.Models.Base
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }

        // Common
        public string Id { get; set; }

        // Audit Fields
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
