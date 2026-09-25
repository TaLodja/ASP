using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Group
	{
		[Key]
		public int group_id {  get; set; }
		public string group_name { get; set; }
		[Column (TypeName ="TINYINT")]
		public int direction { get; set; }
		[ForeignKey(nameof(direction))]
		public Direction? Direction { get; set; }
		[Column (TypeName ="TINYINT")]
		public int? weekdays { get; set; }
		public TimeOnly? start_time { get; set; }
		public DateOnly? start_date { get; set; }
	}
}
