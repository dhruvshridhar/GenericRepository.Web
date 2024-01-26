using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenericRepository.Web.Entities
{
    public class Book
	{
		[Key]
		public string? Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[ForeignKey("Author")]
		public string? AuthorId { get; set; }
		public virtual Author? Author { get; set; }
	}
}

