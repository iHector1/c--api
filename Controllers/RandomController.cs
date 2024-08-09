using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services; 
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomServiceSingleton;
        private IRandomService _randomServiceScoped;
        private IRandomService _randomServiceTransient;

        private IRandomService _randomServiceSingleton2;
        private IRandomService _randomServiceScoped2;
        private IRandomService _randomServiceTransient2;
        public RandomController([FromKeyedServices("RandomServiceSingleton")]IRandomService randomServiceSingleton,
                                [FromKeyedServices("RandomServiceScoped")]IRandomService randomServiceScoped,
                                [FromKeyedServices("RandomServiceTransient")]IRandomService randomServiceTransient,
                                [FromKeyedServices("RandomServiceSingleton")]IRandomService randomServiceSingleton2,
                                [FromKeyedServices("RandomServiceScoped")]IRandomService randomServiceScoped2,
                                [FromKeyedServices("RandomServiceTransient")]IRandomService randomServiceTransient2)
        {
            _randomServiceSingleton = randomServiceSingleton;
            _randomServiceScoped = randomServiceScoped;
            _randomServiceTransient = randomServiceTransient;
            _randomServiceSingleton2 = randomServiceSingleton2;
            _randomServiceScoped2 = randomServiceScoped2;
            _randomServiceTransient2 = randomServiceTransient2;
        }
        [HttpGet]
        public ActionResult<Dictionary<string,int>> Get()
        {
            var result = new Dictionary<string, int>();

            result.Add("Singleton1", _randomServiceSingleton.Value);
            result.Add("Scoped1", _randomServiceScoped.Value);
            result.Add("Transient1", _randomServiceTransient.Value);

            result.Add("Singleton2", _randomServiceSingleton2.Value);
            result.Add("Scoped2", _randomServiceScoped2.Value);
            result.Add("Transient2", _randomServiceTransient2.Value);

            return result;
        }
    }
}
