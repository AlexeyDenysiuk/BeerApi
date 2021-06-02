using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerApi.Clients;
using BeerApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerFindController : ControllerBase
    {
        

        private readonly ILogger<BeerFindController> _logger;
        private readonly BeerClient _beerClient;

        public BeerFindController(ILogger<BeerFindController> logger, BeerClient beerClient)
        {
            _logger = logger;
            _beerClient = beerClient;
        }
     
        [HttpGet("beerName")]
        public async Task<IEnumerable<BeerInfo>> BeerByName([FromQuery] BeerNameParameters parameters)
        {
           
            var beer = await _beerClient.BeerByName(parameters.Name);

            
            return beer;
        }
        [HttpGet("beerAbv")]
        public async Task<IEnumerable<BeerInfo>> BeerByAbv([FromQuery] BeerAbvParameters parameters)
        {

            var beer = await _beerClient.BeerByAbv(parameters.Abv);


            return beer;
        }
        [HttpGet("beerIbu")]
        public async Task<IEnumerable<BeerInfo>> BeerByIbu([FromQuery] BeerIbuParameters parameters)
        {

            var beer = await _beerClient.BeerByIbu(parameters.Ibu);


            return beer;
        }
        [HttpGet("beerRandom")]
        public async Task<IEnumerable<BeerInfo>> BeerByRandom()
        {

            var beer = await _beerClient.BeerByRandom();

            return beer;
        }
        [HttpGet("beerEbc")]
        public async Task<IEnumerable<BeerInfo>> BeerByEbc([FromQuery] BeerEbcParameters parameters)
        {

            var beer = await _beerClient.BeerByEbc(parameters.Ebc);


            return beer;
        }
      
    }
}
