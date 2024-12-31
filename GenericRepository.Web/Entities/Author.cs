using System.ComponentModel.DataAnnotations;

namespace GenericRepository.Web.Entities
{
    public class Author
	{
		[Key]
		public string? Id { get; init; }
		[Required]
		public string? Name { get; init; }
	}
}

