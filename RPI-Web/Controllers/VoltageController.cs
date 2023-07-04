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
            SlackApi.Token = "xoxb-5539719593553-5529537940724-MFPuoz1xGaFGz0jguYwLk9mX";
        }

        [Route("")]
        [HttpGet]
        public IList<VoltageModel> List()
        {
            return _service.List();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<VoltageModel> GetAsync(int id)
        {
            VoltageModel result = null;
            result = _service.Get(id);
            SlackApi.ChatPostMessage data = new SlackApi.ChatPostMessage()
            {
                channel = "#rpi",
                text = $"#{id} voltage = {result.Value} "
            };
            await SlackApi.PostAsync(data);

            return result;
        }
    }
}