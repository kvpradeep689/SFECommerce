using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;

namespace SalesFusionECommerce
{
    public class ElasticDbAccess
    {
        private static ElasticClient _elasticClient = null;
        public static ElasticClient ESClient
        {
            get
            {
                if (_elasticClient == null || _elasticClient.ClusterHealth().IsValid)
                {
                    _elasticClient = Connect();
                }
                return _elasticClient;
            }
        }

        protected static ElasticClient Connect()
        {
            if (_elasticClient == null || _elasticClient.ClusterHealth().IsValid)
            {
                var nodes = new Uri[]
                {
                    new Uri("http://search-fittery-challenge-pv7vc3ugoko5hngpgxdh4szuqm.us-east-1.es.amazonaws.com/"),
                    //Fallback url
                    //new Uri("http://localhost:9200/")
                };
                //var local = new Uri("http://localhost:9200");
                //var settings = new ConnectionSettings(local);
                var connectionPool = new StaticConnectionPool(nodes);
                var settings = new ConnectionSettings(connectionPool);
                _elasticClient = new ElasticClient(settings);

                //var res = _elasticClient.ClusterHealth();

                //Console.WriteLine(res.IsValid);
            }
            return _elasticClient;
        }

        public static IList<item> GetAllProductItems()
        {
            var response = ESClient.Search<item>(s => s
                .Index("items")
                .Query(q => q.MatchAll()));
            IList<item> items = new List<item>();
            foreach (var hit in response.Hits)
            {
                items.Add(hit.Source);
            } 
            return items;
        }
    }
}
