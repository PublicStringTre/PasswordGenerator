using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;

namespace PasswordGenerator.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            PasswordViewModel model = new PasswordViewModel();
           
            return View(model);
        }
        
        public IActionResult GeneratePassword(PasswordViewModel model)
        {
            Random random = new Random();

            string passwordResult = "";
            string specialCharResult = "";
            string capLetterResult = "";
            string capandspecResult = "";
            string defaultPassword = "";

           if (model.UseCapitalLetter && model.UseSpecialCharacters)
            {
                string values = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*(_)+=|][:'/.,;1234567890";
                
                for(int i =0; i < model.PasswordLength; i++)
                {
                    int value = random.Next(0,values.Length);
                    char character = values[value];
                    capandspecResult += character;
                }
                passwordResult = capandspecResult;
            }
           
           else if(model.UseSpecialCharacters)
            {
                string values = @"abcdefghijklmnopqrstuvwxyz!@#$%^&*(_)+=|][:'/.,;1234567890";
                for(int i =0; i < model.PasswordLength; i++)
                {
                    int value = random.Next(0, values.Length);
                    char character = values[value];
                    specialCharResult += character;
                }
                passwordResult = specialCharResult;
            }
           else if(model.UseCapitalLetter)
            {
                string values = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                for(int i =0; i < model.PasswordLength; i++)
                {
                    int value = random.Next(0, values.Length);
                    char character = values[value];
                    capLetterResult += character;
                }
                passwordResult = capLetterResult;
            }
           else
            {
                string values = "abcdefghijklmnopqrstuvwxyz1234567890";
                for(int i =0; i < model.PasswordLength; i++)
                {
                    int value = random.Next(0, values.Length);
                    char character = values[value];
                    defaultPassword += character;
                }
                passwordResult = defaultPassword;
            }
            model.PasswordResult = passwordResult;
            return View("Index",model);
        }

    }
}
