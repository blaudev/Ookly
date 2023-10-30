using Microsoft.Extensions.Options;

using Nest;

using Ookly.Core.AdAggregate;
using Ookly.Core.AdDocumentAggregate;

namespace Ookly.Infrastructure.Elastic;

public class AdDocumentRepository(ElasticClient client, IOptions<ElasticOptions> elasticOptions) : IAdDocumentRepository
{
    private readonly ElasticOptions options = elasticOptions.Value;

    public async Task AddAsync(AdDocument adDocument)
    {
        await client.IndexDocumentAsync(adDocument);
    }

    public Task<List<Ad>> SearchAsync()
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAdIndexAsync()
    {
        var r = await client.Indices.DeleteAsync(options.IndexName);
    }

    public async Task CreateIndexAsync()
    {
        var r = await client.Indices.CreateAsync(options.IndexName, c => c
            .Map<AdDocument>(m => m
                .AutoMap()
                .Properties(p => p
                    .Text(t => t
                        .Name(n => n.Title)
                        .Analyzer("spanish")
                    )
                )
            )
        );
    }
}
