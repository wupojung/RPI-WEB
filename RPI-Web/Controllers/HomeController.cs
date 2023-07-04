using System.Device.Gpio;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RPI_Web.Models;

namespace RPI_Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
  //  private GpioController _controller;
    private int pin = 10;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
      //  _controller = new GpioController(PinNumberingScheme.Board);
      //  _controller.OpenPin(pin, PinMode.Output);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult On()
    {
      //  _controller.Write(pin,PinValue.High);
        return View();
    }

    public IActionResult Off()
    {
      //  _controller.Write(pin,PinValue.Low);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}