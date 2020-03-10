using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CytelApiValidationMessage.Models;
using System.Resources;
using Microsoft.Extensions.Localization;
using CytelApiValidationMessage.Enums;

namespace CytelApiValidationMessage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ResourceManager _resourceManager;
        private readonly IStringLocalizer<LoginController> _localizer;

        public LoginController(ResourceManager resourceManager, IStringLocalizer<LoginController> localizer)
        {
            _resourceManager = resourceManager;
            _localizer = localizer;
        }

        [HttpGet]
        public ActionResult Index()
        {
            string messageCode;
            try
            {               
                messageCode = "CY-" + (int)ErrorCodesEnum.WelcomeNote;
                return Ok(_localizer[messageCode].Value);
            }
            catch (Exception ex)
            {
                messageCode = "CY-" + (int)ErrorCodesEnum.UnknownError;
                return Ok(_localizer[messageCode].Value);
            }
        }

        [HttpPost]
        public ActionResult Index(LoginModel objuserlogin)

        {

            string messageCode;
            try
            {   var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();

                if (display != null)
                {
                    messageCode = "CY-" + (int)ErrorCodesEnum.CorrectDetails;
                    return Ok(_localizer[messageCode].Value);
                }
                else
                {
                    messageCode = "CY-" + (int)ErrorCodesEnum.WrongDetails;
                    return Ok(_localizer[messageCode].Value);
                }
            }
            catch(Exception ex)
            {
                messageCode = "CY-" + (int)ErrorCodesEnum.UnknownError;
                return Ok(_localizer[messageCode].Value);
            }
                 

        }

        public List<LoginModel> Userloginvalues()

        {
            List<LoginModel> objModel = new List<LoginModel>();
            objModel.Add(new LoginModel { UserName = "user1", UserPassword = "password1" });
            objModel.Add(new LoginModel { UserName = "user2", UserPassword = "password2" });
            objModel.Add(new LoginModel { UserName = "user3", UserPassword = "password3" });
            objModel.Add(new LoginModel { UserName = "user4", UserPassword = "password4" });
            objModel.Add(new LoginModel { UserName = "user5", UserPassword = "password5" });
            return objModel;
        }

       
    }
}