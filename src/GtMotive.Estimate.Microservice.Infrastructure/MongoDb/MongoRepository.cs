using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public abstract class MongoRepository<T>(IMongoDatabase database, string collectionName)
            where T : class
    {
        protected IMongoCollection<T> Collection { get; } = database.GetCollection<T>(collectionName);

        public async Task<T> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            return await Collection.Find(Builders<T>.Filter.Eq("_id", objectId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            var objectId = new ObjectId(id);
            await Collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", objectId), entity);
        }
    }
}
