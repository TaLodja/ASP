using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;

namespace Academy.Models
{
	public class Human
	{
		[Required]
		[StringLength(50, MinimumLength = 2)]
		[RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Фамилия содержит недопустимые символы")]
		[DisplayName("Фамилия")]
		public string last_name { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 2)]
		[RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Имя содержит недопустимые символы")]
		[DisplayName("Имя")]

		public string first_name { get; set; }

		[StringLength(50, MinimumLength = 2)]
		[RegularExpression("^[A-ZА-Я][a-zа-я]*$", ErrorMessage = "Отчество содержит недопустимые символы")]
		[DisplayName("Отчество")]
		public string? middle_name { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[RangeAttribute(typeof(DateOnly), "1950-01-01", "2020-01-01")]
		public DateOnly birth_date { get; set; }

		public string? email { get; set; }
		public string? phone { get; set; }
		public byte[]? photo { get; set; }
	}
}
