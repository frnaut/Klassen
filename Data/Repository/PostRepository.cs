using Core.AppContext;
using Core.IRepository;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class PostRepository : Methods<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
