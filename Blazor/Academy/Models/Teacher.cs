using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Teacher:Human
	{
		[Key]
		[Column(TypeName = "SMALLINT")]
		public int teacher_id { get; set; }

		public DateOnly? work_since { get; set; }

		[Column(TypeName = "SMALLMONEY")]
		public int? rate { get; set; }
	}
}
