using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.IO;
using Technical_solution.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Technical_solution.Controllers
{
    public class HomeController : Controller
    {
        SentencesContext db;
        IHostingEnvironment _appEnvironment;
        public HomeController(SentencesContext context, IHostingEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Index() => View(db.sentenсes.ToList());

        [HttpPost]
        public IActionResult Index(IFormFile uploadedFile, string search)
        {
            if (uploadedFile != null && !String.IsNullOrEmpty(search))
            {
                string path = "/Files/" + uploadedFile.FileName;
                
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
                using (var reader = new StreamReader(_appEnvironment.WebRootPath + path))
                {
                    List<Sentenсes> temp = new List<Sentenсes>();
                    var sentences = reader.ReadToEnd().Split('.').Where(x => x.ToLowerInvariant().Contains(search));
                    foreach (var sentence in sentences)
                    {
                        temp.Add(new Sentenсes()
                        {
                            Sentenсe = ReverseString(sentence),
                            FileName = uploadedFile.FileName,
                            Count = sentence.ToLowerInvariant()
                            .Split(new string[] { search.ToLowerInvariant() }, StringSplitOptions.None)
                            .Count() - 1,
                            SearchWord = search
                        });
                    }
                    db.sentenсes.AddRange(temp);
                    db.SaveChanges();
                }
                
            }
            return RedirectToAction("Index");
        }

        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
