using ApartmentManagementSystem.MVC.Models.ModelMetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Models.Request
{
    [ModelMetadataType(typeof(SignUpMetaData))]
    public class SignUpRequest
    {
        public string? Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
