using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vendor.Models.VendorModel
{
    public class VendorDocument : BaseEntity
    {

        [Key]
        public int ID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public Byte[] DocumentContent { get; set; }
        public DateTime DocumentExpiry { get; set; }

        public int VendorMasterID { get; set; }

        [ForeignKey("VendorMasterID")]
        public VendorMaster VendorMaster { get; set; }


    }
}
