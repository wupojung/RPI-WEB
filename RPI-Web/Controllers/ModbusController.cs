using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPI_Web.Services;

namespace RPI_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModbusController : ControllerBase
    {
        private GpioController _controller;
        private int pin = 10;
        private SerialPort sp1;

        public ModbusController()
        {
            sp1.BaudRate = 19200;
            //sp1.PortName = "UART0";
            sp1.PortName = "/dev/ttyAMA0";
            sp1.Parity = Parity.None;
            sp1.DataBits = 8;
            sp1.StopBits = StopBits.One;
            sp1.ReadTimeout = 2000;
            sp1.DataReceived += DataReceivedHandler;

        }

        [HttpGet]
        public string Index()
        {
            sp1.Open();


            byte[] cmd = new byte[6];

            cmd[0] = 0x03;
            cmd[1] = 0x03;
            cmd[2] = 0x00;
            cmd[3] = 0x07;
            cmd[4] = 0x00;
            cmd[5] = 0x01;
            byte[] package = ModbusUtility.PackageWithCRC16(cmd);

            package.ToList().ForEach(i => Console.Write(i.ToString("X2") + " "));
            Console.WriteLine("");

            while (sp1.IsOpen)
            {
                sp1.Write(package, 0, package.Length);
                Thread.Sleep(2000);
            }
            
            return "OK";
        }
        
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            int bytes = sp.BytesToRead;
            byte[] buffer = new byte[bytes];
            sp.Read(buffer, 0, bytes);

            Console.Write("Data Received:");
            foreach (var buf in buffer)
            {
                Console.Write($"{buf:X2}");
            }

            Console.WriteLine("");
        }
    }
}