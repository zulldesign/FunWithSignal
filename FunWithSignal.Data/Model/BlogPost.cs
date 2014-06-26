using System.ComponentModel.DataAnnotations;

namespace FunWithSignal.Data.Model
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Post { get; set; }

        public FunWithSignal.Domain.Model.BlogPost ToDomainBlogPost()
        {
            return new Domain.Model.BlogPost
            {
                Id = this.Id,
                Title = this.Title,
                Post = this.Post
            };
        }
    }
}