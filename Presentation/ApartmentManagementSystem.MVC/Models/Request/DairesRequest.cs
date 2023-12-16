using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Models.ModelMetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApartmentManagementSystem.MVC.Models.Request
{
    [ModelMetadataType(typeof(DairesMetaData))]
    public class DairesRequest
    {
        public string DaireNo { get; set; }

        public int FloorNo { get; set; }

        public string UserId { get; set; }

        public decimal Subscriptions { get; set; }



    }
}
