using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Core.Reindex;
using Elastic.Clients.Elasticsearch.IndexManagement;
using MongoDB.Bson;
using Nest;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseTests
{
    public class Elastic
    {
        public ElasticClient Client;
        string index = "items-index";
        public Elastic(string URI)
        {
            var node = new Uri(URI);
            var settings = new ConnectionSettings(node)
            .DefaultIndex(index);

            Client = new ElasticClient(settings);
        }
        public async Task<Nest.IndexResponse> IndexEntry(UserItem item)
        {
            var response = await Client.IndexAsync(item, request => request.Index(index));

            if (response.IsValid)
            {
                Console.WriteLine($"Index document with ID {response.Id} succeeded.");
            }
            else
            {
                Console.WriteLine(response);
            }
            return response;
        }
        public async Task<System.Collections.Generic.IReadOnlyCollection<IHit<UserItem>>> GetEntries()
        {
            var response = await Client.SearchAsync<UserItem>(s => s
                .From(0)
                .Size(100)
            );

            foreach (var item in response.Hits) 
            {
                Console.WriteLine(item.Id);
            }

            return response.Hits;
        }
        public async Task<UserItem> SearchEntries(string searchID)
        {
            //var response = Client.Get<UserItem>(searchID, g => g.Index(index));

            var response = await Client.SearchAsync<UserItem>(s => s.Index(index).Query(q => q.Match(m => m.Field("_id").Query(searchID))));

            if (response.IsValid && response.Hits.Count > 0)
            {
                var hit = response.Hits.First().Source;
                return hit;
            }
            else
            {
                return null;
            }
        }
        public async Task UpdateEntry(string id, UserItem item)
        {
            var response = await Client.UpdateAsync<UserItem>(id, u => u
              .Index(index)
              .Doc(item));

            Console.WriteLine(response.ApiCall);
        }
        public async Task DeleteEntry(string id)
        {
            var response = await Client.DeleteAsync<UserItem>(id);

            Console.WriteLine(response.ApiCall);
        }
    }
}
