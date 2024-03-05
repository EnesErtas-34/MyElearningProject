using FluentValidation;
using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.ValidationRules
{
	public class StudentValidator:AbstractValidator<Student>
	{
		public StudentValidator()
		{
			RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Alanını Boş geçemezsiniz").EmailAddress().WithMessage("Geçerli bir e-posta giriniz lütfen");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre kısmını boş geçemezsiniz");
		}
	}
}