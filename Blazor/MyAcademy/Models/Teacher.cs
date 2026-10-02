using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	public class Teacher
	{
		[Key]
		[Column(TypeName = "SMALLINT")]
		public int teacher_id { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR")]
		public string last_name { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR")]
		public string first_name { get; set; }

		[Column(TypeName = "NVARCHAR")]
		public string? middle_name { get; set; }

		[Required]
		[Column(TypeName = "DATE")]
		public DateOnly birth_date { get; set; }

		[Column(TypeName = "NVARCHAR(50)")]
		public string? email { get; set; }

		[Column(TypeName = "NCHAR(16)")]
		public string? phone { get; set; }

		public byte[]? photo { get; set; }

		[Column(TypeName = "DATE")]
		public DateOnly? work_since { get; set; }

		[Column(TypeName = "SMALLMONEY")]
		public decimal? rate { get; set; }

		//Navigation properties:
		public ICollection<TeacherDiscipline> TeacherDisciplines { get; set; }
	}
}
