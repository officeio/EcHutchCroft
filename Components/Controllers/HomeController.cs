using CommonMark;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OfficeIO.EcHutchCroft.Website.Components.Extensions;
using OfficeIO.EcHutchCroft.Website.Components.Models.Home;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IoFile = System.IO.File;

namespace OfficeIO.EcHutchCroft.Website.Components.Controllers
{
    public class HomeController : Controller
    {
        #region Constructor
        public HomeController(IHostingEnvironment environment)
        {
            Environment = environment;
        } 
        #endregion

        #region Properties
        public IHostingEnvironment Environment { get; private set; } 
        #endregion

        [HttpGet("~/")]
        public IActionResult ServeHomePage()
        {
            var model = new HomeModel();
            model.Testimonials.AddRange(LoadTestimonials());
            return View("Home", model);
        }

        protected IEnumerable<TestimonialModel> LoadTestimonials()
        {
            // Workout the path to the testimonials directory.
            var directoryPath = Path.Combine(Environment.ContentRootPath, "Testimonials");

            // Find all the Markdown files inside the directory.
            var filePaths = Directory
                .GetFiles(directoryPath, "*.md")
                .OrderBy(f => f)
                .ToArray();

            // Iterate over every file.
            foreach (var filePath in filePaths) {

                // Read in the file, and convert the markdown to HTML.
                var fileName = Path.GetFileName(filePath);
                var fileContents = IoFile.ReadAllText(filePath);
                var htmlContents = CommonMarkConverter.Convert(fileContents);
                var testimonial = new TestimonialModel() { Content = htmlContents };

                yield return testimonial;

            }

        }
    }
}
