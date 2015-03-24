using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using Library.Web.Models;
using Nest;

namespace Library.Web.Controllers
{
    public class SearchService
    {
        public double MinScore { get {return 0.0005; }}
        public string PreHighlightTag
        {
            get { return @"<strong>"; }
        }

        public string PostHighlightTag
        {
            get { return @"</strong>"; }
        }


        public Tuple< IEnumerable<IHit<Book>>,long> Find(string query, int page = 0, int pageSize = 10)
        {
            var result = Elasticsearch.Elasticsearch.Client.Search<Book>(s => s
                 .From(page * pageSize)
                 .Size(pageSize)
                 .MinScore(MinScore)
                 .Highlight(h => h
                     .PreTags(PreHighlightTag)
                     .PostTags(PostHighlightTag)
                     .OnFields(
                         f => f.OnField(b => b.Foreword),
                         f => f.OnField(b => b.Title)
                         ))
                 .Query(q => q.QueryString(qs => qs.Query(query).UseDisMax())));

            return new Tuple<IEnumerable<IHit<Book>>, long>(result.Hits,result.ElapsedMilliseconds); 
        }

        public IDictionary<string, Suggest[]> FindPhraseSuggestion(string phrase, int page = 0, int pageSize = 5)
        {
            var result = Elasticsearch.Elasticsearch.Client.Search<Book>(s => s
                .From(page*pageSize)
                .Size(pageSize)
                .SuggestPhrase("did-you-mean", ps => ps
                    .Text(phrase)
                    .OnField(f => f.Foreword))
                .Query(q => q.MatchAll()));
            
            return result.Suggest;
        }


        public IEnumerable<IHit<Book>> FindAll()
        {
            var result = Elasticsearch.Elasticsearch.Client.Search<Book>(s => s.AllIndices());
            return result.Hits;
        }

    }
}
