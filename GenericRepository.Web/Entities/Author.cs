using System.ComponentModel.DataAnnotations;

namespace GenericRepository.Web.Entities
{
    public class Author
	{
		[Key]
		public string? Id { get; set; }
		[Required]
		public string? Name { get; set; }
	}
}

