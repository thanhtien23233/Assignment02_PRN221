using Candidate_Services.JobPostingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManageWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataTableController : ControllerBase
    {
        private readonly IJobPostingService _jobPostingService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DataTableController(IJobPostingService jobPostingService, IWebHostEnvironment webHostEnvironment)
        {
            _jobPostingService = jobPostingService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("get-jobPostings")]
        public IActionResult GetProducts()
        {
            var jobPostings = _jobPostingService.GetJobPostings().ToList();
            return new JsonResult(new { data = jobPostings });
        }

        //[HttpDelete("jobPosting")]
        //public IActionResult DeleteJobPosting(string? id)
        //{
        //    var productToBeDeleted = _jobPostingService.GetJobPosting(id);
        //    if (productToBeDeleted == null)
        //    {
        //        return new JsonResult(new { success = false, message = "error while deleting" });
        //    }

        //    //string productPath = Path.Combine("images", "products", $"product-{id}");
        //    //string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

        //    if (Directory.Exists(finalPath))
        //    {
        //        string[] filePaths = Directory.GetFiles(finalPath);
        //        foreach (string filePath in filePaths)
        //        {
        //            System.IO.File.Delete(filePath);
        //        }
        //        Directory.Delete(finalPath);
        //    }


        //    //delete product
        //    _productService.DeleteProduct(productToBeDeleted);
        //    return new JsonResult(new { success = true, message = "Delete Successful" });
        //}
    }
}
