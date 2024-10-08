﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Conexion a base de datos termianda");
            Thread.Sleep(1000);
            Console.WriteLine("Envio del correo electronico");
            
            sw.Stop();
            return Ok(sw.Elapsed);
        }
        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var task1 = new Task<int>(() => { 
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a base de datos terminada");
                return 8;
            });
            var task2 = new Task<int>(() => {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de email terminado");
                return 2;
            });
            task1.Start();
            task2.Start();
            Console.WriteLine("HAgo otra cosa");

            var result = await task1;
            var result2 = await task2;

            Console.WriteLine("Todo ha terminado");
            sw.Stop();
            return Ok(result +" "+result2+" "+sw.Elapsed);
        }
    }
}
