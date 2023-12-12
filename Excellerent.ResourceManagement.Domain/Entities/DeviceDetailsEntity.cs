using Excellerent.ResourceManagement.Domain.Models;
using Excellerent.SharedModules.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Entities
{
    public class DeviceDetailsEntity : BaseEntity<DeviceDetails>
    {
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

        public DeviceDetailsEntity(DeviceDetails t) : base(t)
        {
            Category = t.Category;
            SubCategory = t.SubCategory;
            CompanyAssetCode = t.CompanyAssetCode;
            AssetName = t.AssetName;
            BusinessUnit = t.BusinessUnit;
            IsWorking = t.IsWorking;
            AssetClassification = t.AssetClassification;
            PurchaseDate = t.PurchaseDate;
            Purchaser = t.Purchaser;
            InvoiceNumber = t.InvoiceNumber;
            Manufacturer = t.Manufacturer;
            SerialNumber = t.SerialNumber;
            Warranty = t.Warranty;
            WarrantyEndDate = t.WarrantyEndDate;
            Notes = t.Notes;
        }

        public override DeviceDetails MapToModel()
        {
            DeviceDetails a = new DeviceDetails();
            a.Category = Category;
            a.SubCategory = SubCategory;
            a.CompanyAssetCode = CompanyAssetCode;
            a.AssetName = AssetName;
            a.BusinessUnit = BusinessUnit;
            a.IsWorking = IsWorking;
            a.AssetClassification = AssetClassification;
            a.PurchaseDate = PurchaseDate;
            a.Purchaser = Purchaser;
            a.InvoiceNumber = InvoiceNumber;
            a.Manufacturer = Manufacturer;
            a.SerialNumber = SerialNumber;
            a.Warranty = Warranty;
            a.WarrantyEndDate = WarrantyEndDate;
            a.Notes = Notes;
            return a;
        }

        public override DeviceDetails MapToModel(DeviceDetails t)
        {
            DeviceDetails a = t;
            a.Category = Category;
            a.SubCategory = SubCategory;
            a.CompanyAssetCode = CompanyAssetCode;
            a.AssetName = AssetName;
            a.BusinessUnit = BusinessUnit;
            a.IsWorking = IsWorking;
            a.AssetClassification = AssetClassification;
            a.PurchaseDate = PurchaseDate;
            a.Purchaser = Purchaser;
            a.InvoiceNumber = InvoiceNumber;
            a.Manufacturer = Manufacturer;
            a.SerialNumber = SerialNumber;
            a.Warranty = Warranty;
            a.WarrantyEndDate = WarrantyEndDate;
            a.Notes = Notes;
            return a;
        }
    }
}
