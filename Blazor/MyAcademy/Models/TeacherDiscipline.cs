using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAcademy.Models
{
	public class TeacherDiscipline
	{
		[Column("teacher", TypeName = "SMALLINT")]
		[ForeignKey(nameof(Teacher))]
		public int teacher {  get; set; }

		[Column("discipline", TypeName = "SMALLINT")]
		[ForeignKey(nameof(Discipline))]
		public int discipline { get; set; }

		//Navigation properties:
		public Teacher Teacher { get; set; }
		public Discipline Discipline { get; set; }
	}
}
