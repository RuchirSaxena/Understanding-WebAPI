using CountingKs.Data;
using CountingKs.Data.Entities;
using CountingKs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CountingKs.Controllers
{
    public class MeasuresController : ApiController
    {
        private ModelFactory _modelFactory;
        private ICountingKsRepository _repo;

        public MeasuresController(ICountingKsRepository repo)
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }

        public IEnumerable<MeasureModel> Get(int foodId)
        {
            var results = _repo.GetMeasuresForFood(foodId)
                            .Select(m => _modelFactory.Create(m));

            return results;
                        
        }

    }
}
