using AIARestApi;
using AIAUniversalApp.Shared.Helpers;
using AIAUniversalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIAUniversalApp.Controllers
{
    public class RegistrationController
    {
        public RegistrationViewModel registrationViewModel { get; set; }

        public RegistrationController()
        {
            registrationViewModel = new RegistrationViewModel();
        }

        public void Register()
        {
            AIAUser newUser = new AIAUser();
            newUser.FirstName = registrationViewModel.FirstName;
            newUser.LastName = registrationViewModel.LastName;
            newUser.UserName = registrationViewModel.UserName;
            newUser.CanUseSystem = 0;
            Helper.Post<AIAUser>(newUser); 
        }
    }
}
