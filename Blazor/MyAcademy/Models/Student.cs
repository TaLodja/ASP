using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	public class Student
	{
		[Key]
		public int stud_id { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR(50)")]
		public string last_name { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR(50)")]
		public string first_name { get; set; }

		[Column(TypeName = "NVARCHAR(50)")]
		public string? middle_name { get; set; }

		[Required]
		[Column(TypeName = "DATE")]
		public DateOnly birth_date { get; set; }

		[Column(TypeName = "NVARCHAR(50)")]
		public string? email { get; set; }

		[Column(TypeName = "NCHAR(16)")]
		public string? phone { get; set; }

		public byte[]? photo { get; set; }

		[Required]
		[Column("group", TypeName = "INT")]
		[ForeignKey(nameof(Group))]
		public int group { get; set; }

		//Navigation properties:
		public Group Group { get; set; }
	}
}
