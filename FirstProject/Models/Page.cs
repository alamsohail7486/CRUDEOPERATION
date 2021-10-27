using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile ProfileImage { get; set; }


        //public IEnumerable<IFormFile> ProfileImage { get; set; }
        public int Status { get; set; }
        public string strStatus { get; set; }

    }
}
