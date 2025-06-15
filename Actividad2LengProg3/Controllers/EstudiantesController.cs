using Actividad4LengProg3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private static List<EstudianteViewModel> estudiantes = new List<EstudianteViewModel>();
        private object listaEstudiantes;

        public object ListaEstudiantes { get; private set; }

        // GET: Estudiantes
        public IActionResult Index()
        {
            CargarListas();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(EstudianteViewModel estudiante)
        {
            CargarListas();

            if (ModelState.IsValid)
            {
                estudiantes.Add(estudiante);
                return RedirectToAction("Lista");
            }

            return View("Index", estudiante);
        }

        public IActionResult Lista()
        {
            return View(estudiantes);
        }

        public IActionResult Editar(string matricula)
        {
            CargarListas();
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        [HttpPost]
        public IActionResult Editar(EstudianteViewModel estudiante)
        {
            if (!ModelState.IsValid)
            {
                return View(estudiante);
            }

           
            var existente = estudiantes.FirstOrDefault(e => e.Matricula == estudiante.Matricula);
            if (existente == null)
            {
                return HttpNotFound();
            }

            // Actualizar los datos del estudiante
            existente.NombreCompleto = estudiante.NombreCompleto;
            existente.Carrera = estudiante.Carrera;
            existente.CorreoInstitucional = estudiante.CorreoInstitucional;
            existente.Telefono = estudiante.Telefono;
            existente.FechaNacimiento = estudiante.FechaNacimiento;
            existente.Genero = estudiante.Genero;
            existente.Turno = estudiante.Turno;
            existente.TipoIngreso = estudiante.TipoIngreso;
            existente.EstaBecado = estudiante.EstaBecado;
            existente.PorcentajeBeca = estudiante.PorcentajeBeca;
            existente.TerminosYCondiciones = estudiante.TerminosYCondiciones;

            return RedirectToAction("Lista");
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public object GetListaEstudiantes()
        {
            return listaEstudiantes;
        }

        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);

            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante); 
        }
        public IActionResult Buscar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View("Detalles", estudiante);
        }


        [HttpPost]
        [ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);

            if (estudiante != null)
            {
                estudiantes.Remove(estudiante);
            }

            return RedirectToAction("Lista");
        }

        private void CargarListas()
        {
            ViewBag.Carreras = new List<string> { "Ingeniería en Sistemas", "Medicina", "Derecho", "Administración", "Arquitectura" };
            ViewBag.Generos = new List<string> { "Masculino", "Femenino", "Otro" };
            ViewBag.Turnos = new List<string> { "Mañana", "Tarde", "Noche" };
            ViewBag.TiposIngreso = new List<string> { "Regular", "PAA", "Transferencia", "Convenio" };
        }
    }
}