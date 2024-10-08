﻿using Microsoft.AspNetCore.Mvc;
using Resunet.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace Resunet.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        [Route("/profile")]
        public IActionResult Index()
        {
            return View(new ProfileViewModel());
        }

        [HttpPost]
        [Route("/profile")]
        public async Task<IActionResult> IndexSave(ProfileViewModel model)
        {
            //if (ModelState.IsValid) { }

            string filename = string.Empty;
            var imageData = Request.Form.Files[0];

            if (imageData != null)
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(imageData.FileName);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                string hash = Convert.ToHexString(hashBytes);
                
                var dir = "./wwwroot/images/" + hash.Substring(0, 2) + "/" + hash.Substring(0, 4);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                filename = dir + "/" + imageData.FileName;
                using (var stream = System.IO.File.Create(filename))
                {
                    await imageData.CopyToAsync(stream);
                }
            }

            return View("Index", new ProfileViewModel());
        }
    }
}
