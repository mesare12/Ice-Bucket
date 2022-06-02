using Microsoft.AspNetCore.Mvc;
using IceCreamAPIMongoDB.Models;
using MongoDB.Driver;

namespace IceCreamAPIMongoDB.Controllers
{
    public class ScoopController : Controller
    {
        private readonly IMongoCollection<ScoopItem> _Scoop;
        public ScoopController(IMongoCollection<ScoopItem> Scoop)
        {
            _Scoop = Scoop; 
        }
    }
}
