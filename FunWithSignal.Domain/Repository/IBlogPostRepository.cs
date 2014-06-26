using System.Collections.Generic;
using System.Linq;
using FunWithSignal.Domain.Model;

namespace FunWithSignal.Domain.Repository
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
        void CreateBlogPost(BlogPost post);
        BlogPost ReadBlogPost(int id);
        void UpdateBlogPost(BlogPost post);
        void DeleteBlogPost(int id);
    }
}
