using LasApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LasApi.Controllers
{
    [Route("api/rest/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MockDataManager _mockDataManager;

        public ValuesController(MockDataManager mockDataManager)
        {
            _mockDataManager = mockDataManager;
        }

        [HttpGet]
        [ServiceFilter(typeof(ExampleFilter))]
        public IActionResult GetList()
        {
            var result = _mockDataManager.GetAll();
            return Ok(new
            {
                Message = "Sistemsel Sorun !!!!!!",
                StatusCode = 200,
                ShowUser = false,
                data = result
            });
        }
        //[FromQuery] => localhost:7281/api/rest/values?id=2
        //[FromRoute] => localhost:7281/api/rest/values/singleData/2
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            var result = _mockDataManager.GetData(id);
            return Ok(result);
        }
        [HttpPost("create")]
        public IActionResult AddData([FromBody]MockData mockData)
        {
            _mockDataManager.AddData(mockData);
            return Created();
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveData([FromRoute]int id)
        {
            var data =  _mockDataManager.GetData(id);
            _mockDataManager.RemoveData(data);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateData([FromBody]MockData data)
        {
            _mockDataManager.UpdateData(data);
            return Ok();
        }
    }
}
