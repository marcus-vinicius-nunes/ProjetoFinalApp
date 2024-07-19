using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdutosApp.Infra.Storage.Collections;
using ProdutosApp.Infra.Storage.Contexts;

namespace ProdutosApp.Infra.Storage.Persistence
{
    /// <summary>
    /// Classe para persistência de dados de produto
    /// </summary>
    public class ProdutoPersistence
    {
        private readonly MongoDBContext _mongoDBContext;

        public ProdutoPersistence(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task Insert(ProdutoCollection produto)
        {
            await _mongoDBContext.Produto.InsertOneAsync(produto);
        }

        public async Task Update(ProdutoCollection produto)
        {
            var filter = Builders<ProdutoCollection>.Filter.Eq(t => t.Id, produto.Id);
            await _mongoDBContext.Produto.ReplaceOneAsync(filter, produto);
        }

        public async Task Delete(ProdutoCollection produto)
        {
            var filter = Builders<ProdutoCollection>.Filter.Eq(t => t.Id, produto.Id);
            await _mongoDBContext.Produto.DeleteOneAsync(filter);
        }

        public async Task<List<ProdutoCollection>> FindAll()
        {
            var filter = Builders<ProdutoCollection>.Filter.Where(t => true);
            var result = await _mongoDBContext.Produto.FindAsync(filter);
            return result.ToList();
        }

        public async Task<ProdutoCollection>? Find(Guid id)
        {
            var filter = Builders<ProdutoCollection>.Filter.Eq(t => t.Id, id);
            var result = await _mongoDBContext.Produto.FindAsync(filter);
            return result.FirstOrDefault();
        }
    }
}

