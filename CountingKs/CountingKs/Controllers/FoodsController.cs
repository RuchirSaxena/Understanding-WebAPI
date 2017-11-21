using CountingKs.Data;
using CountingKs.Data.Entities;
using CountingKs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace CountingKs.Controllers
{

    public class FoodsController : ApiController
    {
        ModelFactory _modelFactory;
        private ICountingKsRepository _repo;

        public FoodsController(ICountingKsRepository repo)
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }



        [HttpGet]
        public IEnumerable<FoodModel> Get()
        {

            var results = _repo.GetAllFoodsWithMeasures()
                    .OrderBy(f => f.Description)
                    .Take(25)
                    .ToList()
                    //.Select(f => new FoodModel()
                    //{
                    //    Description = f.Description,
                    //    Measures = f.Measures.Select(m =>
                    //    new MeasureModel
                    //    {
                    //        Description = m.Description,
                    //        Calories = m.Calories
                    //    })
                    //});
                    //OR Below Code
                    .Select(f => _modelFactory.Create(f));
            return results;

        }

        [HttpGet]
        public FoodModel Get(int id)
        {
            return _modelFactory.Create(_repo.GetFood(id));
        }
    }
}
