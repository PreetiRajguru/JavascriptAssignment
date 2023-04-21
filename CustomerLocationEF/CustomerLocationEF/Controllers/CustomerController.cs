using CustomerLocation.Services.Services;
using CustomerLocationEF.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerLocationEF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomer _customerService;

        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        //get all customers
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new
            {
                message = "Ok",
                statusCode = StatusCodes.Status200OK,
                result = _customerService.GetAll()
            });
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(new
            {
                message = "Ok",
                statusCode = StatusCodes.Status200OK,
                result = _customerService.GetById(id)
            });
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        message = ModelState.ValidationState,
                        statusCode = StatusCodes.Status400BadRequest
                    });
                }

                bool isExist = _customerService.GetAll().Where(s => s.Email.ToLower() == customer.Email.ToLower()).Any();

                if (isExist)
                {
                    return BadRequest(new
                    {
                        message = "Customer with same email already exists",
                        statusCode = StatusCodes.Status400BadRequest
                    });
                }

                int response = _customerService.Create(customer);

                if (response > 0)
                {
                    return Ok(new
                    {
                        message = "Ok",
                        statusCode = StatusCodes.Status200OK,
                        result = response
                    });
                }

                return BadRequest(new
                {
                    message = "Error",
                    statusCode = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Error",
                    statusCode = StatusCodes.Status500InternalServerError
                });
            }
        }







        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                int response = _customerService.Update(id, customer);
                return Ok(new
                {
                    message = "Ok",
                    statusCode = StatusCodes.Status200OK,
                    result = response
                });
            }
            return BadRequest(new
            {
                message = "Error",
                statusCode = StatusCodes.Status400BadRequest
            });
        }






        /*
                // PUT api/<CustomerController>/5
                [HttpPut("{id}")]
                public IActionResult Update(int id, Customer customer)
                {
                    if (ModelState.IsValid)
                    {
                        int response = _customerService.Update(id, customer);
                        return Ok(new
                        {
                            message = "Ok",
                            statusCode = StatusCodes.Status200OK,
                            result = response
                        });
                    }
                    return BadRequest(new
                    {
                        message = "Error",
                        statusCode = StatusCodes.Status400BadRequest
                    });
                }
        */

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _customerService.Delete(id)
            ? Ok(new
            {
                message = "Ok",
                statusCode = StatusCodes.Status200OK,
            })
            : BadRequest(new
            {
                message = "Error",
                statusCode = StatusCodes.Status400BadRequest
            });
        }
    }
}