using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Teacher
	{
		[Key]
		[Column(TypeName = "SMALLINT")]
		public int teacher_id { get; set; }
		public string last_name { get; set; }
		public string first_name { get; set; }
		public string? middle_name { get; set; }
		public DateOnly birth_date { get; set; }
		public string? email { get; set; }
		public string? phone { get; set; }
		public byte[]? photo { get; set; }
		public DateOnly? work_since { get; set; }
		[Column(TypeName ="SMALLMONEY")]
		public decimal? rate { get; set; }
	}
}
