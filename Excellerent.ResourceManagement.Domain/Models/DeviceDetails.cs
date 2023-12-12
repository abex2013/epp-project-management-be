using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Models
{
    public class DeviceDetails : BaseAuditModel
    {
        public override Guid Guid { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string CompanyAssetCode { get; set; }
        public string AssetName { get; set; }
        public string BusinessUnit { get; set; }
        public Boolean IsWorking { get; set; }
        public string AssetClassification { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Purchaser { get; set; }
        public string InvoiceNumber { get; set; }
        public string Manufacturer { get; set; }
        public string SerialNumber { get; set; }
        public string Warranty { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public string Notes { get; set; }
    }
}
