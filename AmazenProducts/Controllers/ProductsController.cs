using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmazenProducts.Models;
using AmazenProducts.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmazenProducts.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _ps;


    public ProductsController(ProductsService ps)
    {
      _ps = ps;

    }

    [HttpGet]

    public ActionResult<IEnumerable<Product>> GetAll()
    {
      try
      {
        IEnumerable<Product> recipes = _ps.GetAll();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<Product> GetById(int id)
    {
      try
      {
        Product found = _ps.GetById(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]


    public ActionResult<IEnumerable<Product>> Create([FromBody] Product newProduct)
    {
      try
      {
        Product recipe = _ps.Create(newProduct);
        return Ok(recipe);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public ActionResult<Product> Delete(int id)
    {
      try
      {

        _ps.Delete(id);
        return Ok("Delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]

    public ActionResult<Product> Update(int id, [FromBody] Product update)
    {
      try
      {
        update.Id = id;
        Product updated = _ps.Update(update);
        return Ok(updated);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



  }
}



