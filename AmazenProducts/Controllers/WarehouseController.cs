using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehousesController : ControllerBase
  {
    private readonly WarehouseService _warehousesService;

    public WarehousesController(WarehouseService ws)
    {
      _warehousesService = ws;
    }

    [HttpGet]
    public ActionResult<List<Warehouse>> GetAll()
    {
      try
      {
        List<Warehouse> warehouses = _warehouseService.GetAll();
        return Ok(warehouses);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")]
    public ActionResult<List<WarehouseProductViewModel>> GetWarehouseProducts(int id)
    {
      try
      {
        List<WarehouseProductViewModel> products = _warehouseService.GetProducts(id);
        return Ok(products);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }

  public class WarehouseService
  {
    internal List<Warehouse> GetAll()
    {
      throw new NotImplementedException();
    }
  }
}