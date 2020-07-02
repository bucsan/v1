using v1.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace v1.Services
{
    public class MotoristaService
    {
        private readonly IMongoCollection<Motorista> _motoristas;

        public MotoristaService(IAppV1DatabaseSettings settings)
        {            
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _motoristas = database.GetCollection<Motorista>(settings.AppV1CollectionName);
        }

        public List<Motorista> Get() =>
            _motoristas.Find(motorista => true).ToList();

        public Motorista Get(string id) =>
            _motoristas.Find<Motorista>(motorista => motorista.Id == id).FirstOrDefault();

        public Motorista Create(Motorista motorista)
        {
            _motoristas.InsertOne(motorista);
            return motorista;
        }

        public void Update(string id, Motorista bookIn) =>
            _motoristas.ReplaceOne(motorista => motorista.Id == id, bookIn);

        public void Remove(Motorista bookIn) =>
            _motoristas.DeleteOne(motorista => motorista.Id == bookIn.Id);

        public void Remove(string id) => 
            _motoristas.DeleteOne(motorista => motorista.Id == id);
    }
}