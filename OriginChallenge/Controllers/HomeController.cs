using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OriginChallenge.Models;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using OriginChallenge.Filters;
using OriginChallenge.Repository.Interfaces;

namespace OriginChallenge.Controllers
{
    [Authorize()]
    public class HomeController : Controller
    {
        private readonly ITarjetaRepository TarjetaRepository;

        public HomeController(ITarjetaRepository tarjetaRepositorio)
        {
            TarjetaRepository = tarjetaRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Pin()
        {
            string numeroTarjeta = Request.Form["numeroTarjeta"];
            string numeroEncriptado = GetEncrypt(numeroTarjeta);

            Tarjeta tarjeta = TarjetaRepository.GetByNumeroEncriptado(numeroEncriptado);

            //Valida que exista
            if (tarjeta == null)
            {
                string mensaje = $"La tarjeta ingresada no existe.";

                TempData["IsError"] = true;
                TempData["Controller"] = "Home";
                TempData["Action"] = "Index";
                TempData["Mensaje"] = mensaje;

                return RedirectToAction("Index", "Mensaje");
            }

            //Valida que este habilitada
            if (tarjeta.EstadoEnum == eEstadoTarjeta.Bloqueada)
            {
                string mensaje = $"La tarjeta se encuentra bloqueda.<br/> Vuelva a intentarlo más tarde.";

                TempData["IsError"] = true;
                TempData["Controller"] = "Home";
                TempData["Action"] = "Index";
                TempData["Mensaje"] = mensaje;

                return RedirectToAction("Index", "Mensaje");
            }

            ViewBag.NumeroTarjeta = numeroTarjeta;
            return View();
        }

        [HttpPost]
        public IActionResult ValidarLogin(string numeroTarjeta, string pin)
        {
            
            string numeroEncriptado = GetEncrypt(numeroTarjeta);
            string pinEncriptado = GetEncrypt(pin);
            Tarjeta tarjeta = TarjetaRepository.Loguear(numeroEncriptado, pinEncriptado);
         

            if (tarjeta == null)
            {
                bool redireccionarHome = false;
                if (CantidadIntentosLogin(HttpContext, numeroEncriptado) == 4)
                {
                    redireccionarHome = true;

                    Tarjeta tarjetaBloquear = TarjetaRepository.GetByNumeroEncriptado(numeroEncriptado);
                    tarjetaBloquear.Estado = 2;
                    TarjetaRepository.Update(tarjetaBloquear);
                }

                //Si se bloquea la tarjeta se reedirecciona al home sino vuelve a intentar
                if (redireccionarHome)
                {
                    string mensaje = $"La tarjeta ha sido bloqueada";
                    TempData["IsError"] = true;
                    TempData["Controller"] = "Home";
                    TempData["Action"] = "Index";
                    TempData["Mensaje"] = mensaje;
                    

                    return RedirectToAction("Index", "Mensaje");
                }
                else
                {
                    string mensaje = $"El PIN ingresado es incorrecto.<br/>" +
                                      $"Ante reiterados intentos se le bloqueara la tarjeta";

                    TempData["IsError"] = true;
                    TempData["Controller"] = "Home";
                    TempData["Action"] = "Pin";
                    TempData["Mensaje"] = mensaje;
                    Dictionary<string, string> diccionario = new Dictionary<string, string>();
                    diccionario.Add("numeroTarjeta", numeroTarjeta);
                    TempData["Parametros"] = JsonSerializer.Serialize(diccionario);

                    return RedirectToAction("Index", "Mensaje");
                }

            }

            
            HttpContext.Session.SetString("Tarjeta", numeroEncriptado);

            return RedirectToAction("Index", "Operacion");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Tarjeta");
            return RedirectToAction("Index");
        }


        #region Métodos auxiliares
        private string GetEncrypt(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private int CantidadIntentosLogin(HttpContext context, string key)
        {
            int intentos = Convert.ToInt32(context.Session.GetInt32(key));
            intentos++;

            context.Session.SetInt32(key, intentos);

            return intentos;
        } 
        #endregion
    }
}
