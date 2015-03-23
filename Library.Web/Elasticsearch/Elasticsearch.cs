using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;

namespace Library.Web.Elasticsearch
{
    public class Elasticsearch
    {
        private static ElasticClient _client;
        public static ElasticClient Client
        {
            get
            {
                if (_client == null)
                {
                    var setting = new ConnectionSettings(ElasticsearchConfiguration.Connection,ElasticsearchConfiguration.DefaultIndex);
                    _client = new ElasticClient(setting);
                }
                return _client;
            }

        }
    }
   
}