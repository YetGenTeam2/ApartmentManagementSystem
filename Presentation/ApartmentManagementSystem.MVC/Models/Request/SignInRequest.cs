using ApartmentManagementSystem.MVC.Models.ModelMetaDataTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApartmentManagementSystem.MVC.Models.Request
{
    [ModelMetadataType(typeof(SignUpMetaData))]
    public class SignInRequest
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
