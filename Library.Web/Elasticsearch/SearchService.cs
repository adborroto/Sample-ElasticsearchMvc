using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Library.Web.Models;
using Nest;

namespace Library.Web.Controllers
{
    public class SearchService
    {
        public IEnumerable<IHit<Book>> Find(string query, int page=0,int pageSize=10)
        {
           var result=  Elasticsearch.Elasticsearch.Client.Search<Book>(s => s
                .From(page*pageSize)
                .Size(pageSize)
                .Query(q => q.QueryString(qs => qs.Query(query))));

            return result.Hits;
        }

        public IEnumerable<IHit<Book>> FindAll()
        {
            var result = Elasticsearch.Elasticsearch.Client.Search<Book>(s => s.AllIndices());
            return result.Hits;
        }

    }
}
