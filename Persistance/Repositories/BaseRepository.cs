using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Settings;
using Core.Models;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    internal class BaseRepository<T> where T : IEntity
    {
        // Constructors.
        public BaseRepository(DatabaseSettings dbSettings, string databaseName, string collectionName, IMongoClient mongoClient)
        {
            DatabaseSettings = dbSettings;
            MongoClient = mongoClient;
            Database = MongoClient.GetDatabase(databaseName);
            Collection = Database.GetCollection<T>(collectionName);
        }

        // Properties.
        public DatabaseSettings DatabaseSettings { get; set; }
        public IMongoClient MongoClient { get; set; }
        public IMongoDatabase Database { get; set; }
        public IMongoCollection<T> Collection { get; set; }
        public List<BsonDocument> Aggregates { get; set; } = new List<BsonDocument>();

        // Create.
        public async Task<T> AddDocumentAsync(T document)
        {
            await Collection.InsertOneAsync(document);
            return document;
        }
        public async Task<IEnumerable<T>> AddDocumentsAsync(IEnumerable<T> documents)
        {
            await Collection.InsertManyAsync(documents);
            return documents;
        }

        // Read.
        public async Task<T> GetDocumentAsync(string id)
        {
            var cursor = await Collection.FindAsync(Builders<T>.Filter.Eq(document => document.Id, id));
            return await cursor.SingleOrDefaultAsync();
        }
        public async Task<T> GetDocumentWithReferencesAsync(string id)
        {
            var aggregates = new List<BsonDocument>()
            {
                new BsonDocument("$match",
                new BsonDocument("_id",
                new ObjectId(id))),
            };
            aggregates.AddRange(Aggregates);

            var pipeline = PipelineDefinition<T, T>.Create(aggregates);
            var cursor = await Collection.AggregateAsync(pipeline);

            return await cursor.SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetDocumentsAsync()
        {
            var cursor = await Collection.FindAsync(filter => true);
            return await cursor.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetDocumentsAsync(Expression<Func<T, bool>> filter)
        {
            var cursor = await Collection.FindAsync(Builders<T>.Filter.Where(filter));
            return await cursor.ToListAsync();
        }
        public async Task<IEnumerable<T>> GetDocumentsWithReferencesAsync()
        {
            var pipeline = PipelineDefinition<T, T>.Create(Aggregates);
            var cursor = await Collection.AggregateAsync(pipeline);
            return await cursor.ToListAsync();
        }

        // Update.
        public async Task<T> UpdateDocumentAsync(T document)
        {
            await Collection.FindOneAndReplaceAsync(Builders<T>.Filter.Eq(filterDocument => filterDocument.Id, document.Id), document);
            return document;
        }
        public async Task<IEnumerable<T>> UpdateDocumentsAsync(IEnumerable<T> documents)
        {
            var updates = new List<WriteModel<T>>();
            foreach (var document in documents)
            {
                var filter = Builders<T>.Filter.Eq(filterDocument => filterDocument.Id, document.Id);
                updates.Add(new ReplaceOneModel<T>(filter, document));
            }

            await Collection.BulkWriteAsync(updates);
            return documents;
        }

        // Delete.
        public async Task<bool> DeleteDocumentAsync(string id)
        {
            var result = await Collection.DeleteOneAsync(Builders<T>.Filter.Eq(document => document.Id, id));
            if (!result.IsAcknowledged) return false;
            return result.DeletedCount == 1;
        }
        public async Task<long> DeleteDocumentsAsync(IEnumerable<string> ids)
        {
            var result = await Collection.DeleteManyAsync(Builders<T>.Filter.In(document => document.Id, ids));
            if (!result.IsAcknowledged) return 0;
            return result.DeletedCount;
        }
    }
}
