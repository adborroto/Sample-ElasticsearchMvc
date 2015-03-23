using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Web.Models;
using Nest;

namespace Library.Web.ViewModels
{
    public class SearchViewModel
    {
        public string Query { get; set; }

        public IEnumerable<IHit<Book>> Results { get; set; }

        public IDictionary<string, Suggest[]> Suggestions { get; set; }

        public long Elapsed { get; set; }

    }
}