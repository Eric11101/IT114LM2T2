using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterClone.App.Posts;

namespace TwitterClone
{
    public partial class Default : System.Web.UI.Page
    {
        public IEnumerable<Post> posts = new List<Post>();
 

            
        protected void Page_Load(object sender, EventArgs e)
        {
            var repository = new PostRepository();
            posts = repository.GetPostOfUser("joblipat");

            repository.CreatePost(new Post()
            {
                Content = "This is a new post",
                PostedBy = "joblipat",
                PostedOn = DateTime.Now
            });

            //PostsRepeater.DataSource = posts;
            //PostsRepeater.DataBind();

        }
    }
}