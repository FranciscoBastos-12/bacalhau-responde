﻿using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "O ID não pode ser nulo.")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID não pode ser menor que 1.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "O nome não pode ter mais de 80 caracteres.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "O e-mail não pode ser nulo.")]
        [MinLength(10, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O nome não pode ter mais de 80 caracteres.")]
        [RegularExpression(
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "O email informado não está válido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha não pode ser nula.")]
        [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "A senha não pode ter mais de 80 caracteres.")]
        public string Password { get; set; }
    }
}