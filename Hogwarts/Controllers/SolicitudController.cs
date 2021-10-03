using Hogwarts.Models;
using Hogwarts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hogwarts.Controllers
{
    [Route("Hogwarts/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public SolicitudController(IRepositorio repositorio)
        {
           this._repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            List<Solicitud> solicitudes = new List<Solicitud>();

            solicitudes = _repositorio.Get();
            respuesta.Datos = solicitudes;

            if (solicitudes.Count < 1)
            {
                respuesta.Mensage = "No existen solicitudes";
            }

            return Ok(respuesta);
        }

        [HttpPost]
        public IActionResult Post(Solicitud model)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _repositorio.Post(model);
                respuesta.Mensage = "Solicitud guardada con exito";
                respuesta.Datos = model;
            }
            catch (Exception ex)
            {
                respuesta.Mensage = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Put(Solicitud model)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _repositorio.Put(model);
                respuesta.Mensage = "Se ha modificado la solicitud";
                respuesta.Datos = model;
            }
            catch (Exception ex)
            {
                respuesta.Mensage = ex.Message;
            }

            return Ok(respuesta);
        }

        [HttpDelete("{identificador}")]
        public IActionResult Delete(long identificador)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                _repositorio.Delete(identificador);
                respuesta.Mensage = "Se ha borrado con exito la inscripcion";
            }
            catch (Exception ex)
            {
                respuesta.Mensage = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}
