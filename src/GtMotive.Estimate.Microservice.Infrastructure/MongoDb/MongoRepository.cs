using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public abstract class MongoRepository<T>(IMongoDatabase database, string collectionName)
            where T : class
    {
        protected IMongoCollection<T> Collection { get; } = database.GetCollection<T>(collectionName);

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Collection.Find(Builders<T>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Collection.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await Collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            await Collection.ReplaceOneAsync(Builders<T>.Filter.Eq("Id", id), entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }
    }
}
