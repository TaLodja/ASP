using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Discipline
	{
		[Key]
		[Column(TypeName = "SMALLINT")]
		public int discipline_id {  get; set; }
		public string discipline_name { get; set; }
		[Column(TypeName = "TINYINT")]
		public int number_of_lessons { get; set; }
	}
}
