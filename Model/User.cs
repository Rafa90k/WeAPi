using System.ComponentModel.DataAnnotations;

namespace TodoApi.Model
{
    public class User
    {
        public long Id { get; set; }
        
        public string Nome { get; set; }
        
        
        public string Email { get; set; }
        
        [MinLength(11, ErrorMessage = "Esse campo requer 11 numeros!")]
        [MaxLength(11, ErrorMessage = "Esse campo requer 11 numeros")]
        
        public string Cpf { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string DataDeNascimento { get; set; }
        
        [MinLength(8, ErrorMessage = "Esse campo requer no minimo 8 caracteres!")]
         public string Senha { get; set; }
    }
}