using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sk.Hw11.Web.Models
{
    public class HomeIndexPageViewModel
    {
        public string RelativePath { get; }

        public IEnumerable<string> Images { get; }

        public HomeIndexPageViewModel(
            string relativePath,
            IEnumerable<string> images)
        {
            RelativePath = relativePath;
            Images = images;
        }
    }
}