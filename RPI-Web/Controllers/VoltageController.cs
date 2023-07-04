using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPI_Web.Models;
using RPI_Web.Services;

namespace RPI_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoltageController : ControllerBase
    {
        private VoltageService _service;

        public VoltageController()
        {
            _service = new VoltageService();
        }

        [Route("")]
        [HttpGet]
        public IList<VoltageModel> List()
        {
            return _service.List();
        }

        [Route("{id}")]
        [HttpGet]
        public VoltageModel Get(int id)
        {
            return _service.Get(id);
        }
    }
}