using CustomerLocation.Services.Services;
using CustomerLocationEF.Data.Models;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                return Ok(new
                {
                    message = "Ok",
                    statusCode = StatusCodes.Status200OK,
                    result = _customerService.GetAll()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {

                if(id == 0)
                {
                    return BadRequest(new
                    {
                        message = "Invalid Id",
                        statusCode = StatusCodes.Status400BadRequest
                    });
                }
                else
                {
                    return Ok(new
                    {
                        message = "Ok",
                        statusCode = StatusCodes.Status200OK,
                        result = _customerService.GetById(id)
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
                return StatusCode(500, $"Error creating Customer: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
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

                bool isExist = _customerService.GetAll().Where(s => s.Email.ToLower() == customer.Email.ToLower() && s.Id!=id && !s.IsDeleted).Any();

                if (isExist)
                {
                    return BadRequest(new
                    {
                        message = "Customer with same email already exists",
                        statusCode = StatusCodes.Status400BadRequest
                    });
                }

                int response = _customerService.Update(id, customer);

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
                return StatusCode(500, $"Error updating Customer: {ex.Message}");
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}