using Hogwarts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hogwarts.Services
{
    public class ServiceArchivo : IRepositorio
    {
        private readonly string archivo = "Inscripciones.txt";

        public List<Solicitud> Get()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            try
            {
                var datos = File.ReadAllText(archivo); 
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);
            }
            catch (Exception ex)
            {
                var json = JsonSerializer.Serialize(solicitudes);
                File.WriteAllText(archivo, json);

                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);
            }

            return solicitudes;
        }

        public void Post(Solicitud model)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();
            Solicitud solicitud = new Solicitud();
        
            solicitud.Nombre = model.Nombre;
            solicitud.Apellido = model.Apellido;
            solicitud.Identificador = model.Identificador;
            solicitud.Edad = model.Edad;
            solicitud.Casa = model.Casa;

            try
            {
                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);
            }
            catch (Exception ex)
            {
                var jso = JsonSerializer.Serialize(solicitudes);
                File.WriteAllText(archivo, jso);

                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);
            }
            
            solicitudes.Add(solicitud);

            var json = JsonSerializer.Serialize(solicitudes);
            File.WriteAllText(archivo, json);
        }

        public void Put(Solicitud model)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            try
            {
                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);
            }
            catch (Exception ex)
            {
                var jso = JsonSerializer.Serialize(solicitudes);
                File.WriteAllText(archivo, jso);

                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);

            }

            Solicitud solicitud = solicitudes.Where(d => d.Identificador == model.Identificador).FirstOrDefault();

            if(solicitud == null)
            {
                throw new Exception("No existe ningun registro con ese identificador");
            }

            solicitud.Nombre = model.Nombre;
            solicitud.Apellido = model.Apellido;
            solicitud.Casa = model.Casa;
            solicitud.Edad = model.Edad;

            solicitudes.RemoveAll(d => d.Identificador == solicitud.Identificador);
            solicitudes.Add(solicitud);

            var json = JsonSerializer.Serialize(solicitudes);
            File.WriteAllText(archivo, json);
        }

        public void Delete(long identificador)
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            try
            {
                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);
            }
            catch (Exception ex)
            {
                var jso = JsonSerializer.Serialize(solicitudes);
                File.WriteAllText(archivo, jso);

                var datos = File.ReadAllText(archivo);
                solicitudes = JsonSerializer.Deserialize<List<Solicitud>>(datos);

            }

            Solicitud solicitud = solicitudes.Where(d => d.Identificador == identificador).FirstOrDefault();

            if(solicitud == null)
            {
                throw new Exception("El identificador es incorrecto");
            }

            solicitudes.RemoveAll(d => d.Identificador == solicitud.Identificador);

            var json = JsonSerializer.Serialize(solicitudes);
            File.WriteAllText(archivo, json);
        }
    }
}
