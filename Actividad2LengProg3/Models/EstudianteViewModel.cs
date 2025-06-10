using System.ComponentModel.DataAnnotations;

namespace Actividad2LengProg3.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "El nombre completo es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La matrícula debe tener entre 6 y 15 caracteres")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El correo institucional es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string CorreoInstitucional { get; set; }

        [Phone(ErrorMessage = "Ingrese un número de teléfono válido")]
        [MinLength(10, ErrorMessage = "El teléfono debe tener al menos 10 dígitos")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El turno es obligatorio")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "El tipo de ingreso es obligatorio")]
        public string TipoIngreso { get; set; }

        public bool EstaBecado { get; set; }

        [Range(0, 100, ErrorMessage = "El porcentaje de beca debe estar entre 0 y 100")]
        public decimal? PorcentajeBeca { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Debe aceptar los términos y condiciones")]
        public bool TerminosYCondiciones { get; set; }
    }
}
