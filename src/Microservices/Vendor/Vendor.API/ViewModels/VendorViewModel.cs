using System.Collections.Generic;
using Vendor.Models.VendorModel;

namespace Vendor.API.ViewModels
{
    public class VendorViewModel
    {
        public int ID { get; set; }
        public string VendorName { get; set; }
        public string ContractNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string PrimaryContactPersonName { get; set; }
        public string PrimaryContactEmail { get; set; }
        public string PrimaryContactNumber { get; set; }
        public string SecondaryContactPersonName { get; set; }
        public string SecondaryContactEmail { get; set; }
        public string SecondaryContactNumber { get; set; }
        public string Website { get; set; }
        public string FaxNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<VendorDocument> VendorDocuments { get; set; }

        

    }
}