using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OriginChallenge.Filters;
using OriginChallenge.Helpers;
using OriginChallenge.Models;
using OriginChallenge.ModelsExtend;
using OriginChallenge.Repository.Interfaces;
//using MVC_Core.Models;

namespace OriginChallenge.Controllers
{
    [Authorize()]
    public class OperacionController : Controller
    {
        private readonly ITarjetaRepository TarjetaRepository;
        private readonly IOperacionRepository OperacionRepository;

        public OperacionController(ITarjetaRepository tarjetaRepository, IOperacionRepository operacionRepository)
        {
            TarjetaRepository = tarjetaRepository;
            OperacionRepository = operacionRepository;
        }
        
        public IActionResult Index()
        {
            
            return View();
        }

        
        public IActionResult Balance()
        {
            string numeroTarjetaCifrada = HttpContext.Session.GetString("Tarjeta");

            Tarjeta tarjeta = TarjetaRepository.GetByNumeroEncriptado(numeroTarjetaCifrada);

            Operacion operacion = new OperacionBalance(tarjeta, eEstadoOperacion.OK);

            OperacionRepository.Add(operacion);

            return View(tarjeta);
        }

        public IActionResult Retiro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarRetiro(string monto)
        {
            string numeroTarjetaCifrada = HttpContext.Session.GetString("Tarjeta");
            string mensaje = "";
            bool isError = false;
            Tarjeta tarjeta = TarjetaRepository.GetByNumeroEncriptado(numeroTarjetaCifrada);

            decimal saldoRetiro = Convert.ToDecimal(monto);

            Operacion operacion;
            if (tarjeta.Saldo < saldoRetiro)
            {
                operacion = new OperacionRetiro(tarjeta, eEstadoOperacion.Error);
                isError = true;
                mensaje = "No se puede realizar el retiro.<br/>El monto a retirar es mayor al saldo disponible.";
            }
            else
            {
                operacion = new OperacionRetiro(tarjeta, eEstadoOperacion.OK);
                mensaje = "El retiro fue exitoso.";
                tarjeta.Saldo -= saldoRetiro;
            }

            OperacionRepository.Update(operacion);


            TempData["IsError"] = isError;
            TempData["Controller"] = "Operacion";
            TempData["Action"] = "Index";
            TempData["Mensaje"] = mensaje;

            return RedirectToAction("Index", "Mensaje");

        }


        public IActionResult Reporte()
        {
            string numeroTarjetaCifrada = HttpContext.Session.GetString("Tarjeta");
            Tarjeta tarjeta = TarjetaRepository.GetByNumeroEncriptado(numeroTarjetaCifrada);
            var lista = OperacionRepository.GetByIdTarjeta(tarjeta.Id);
            return View(lista);
        }
    }
}
