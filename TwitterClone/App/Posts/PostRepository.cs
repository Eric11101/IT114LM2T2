using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TwitterClone.App.Posts
{
    public class PostRepository
    {

        public IEnumerable<Post> GetAllPost()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\it114l-a54-10\source\repos\TwitterClone\TwitterClone\App_Data\TwitterClone.mdf;Integrated Security=True";
            using (var connection = new SqlConnection
                (connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Posts";
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Post()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBY"],
                        PostedOn = (DateTime)row["postedOn"],
                    })
                    .ToList();


            }            
        }

        public IEnumerable<Post> GetPostOfUser(string username)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\it114l-a54-10\source\repos\TwitterClone\TwitterClone\App_Data\TwitterClone.mdf;Integrated Security=True";
            using (var connection = new SqlConnection
                (connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "SELECT * FROM Posts WHERE postedBy ='{username}'";
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Post()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBY"],
                        PostedOn = (DateTime)row["postedOn"],
                    })
                    .ToList();


            }
        }

        public void CreatePost(Post post)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\it114l-a54-10\source\repos\TwitterClone\TwitterClone\App_Data\TwitterClone.mdf;Integrated Security=True";
            using (var connection = new SqlConnection
                (connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"INSERT INTO Posts(content,postedOn,postedBy) "+
                    $"VALUES(@content,@postedOn,@postedBy)";
                command.Parameters.AddWithValue("content", post.Content);
                command.Parameters.AddWithValue("postedOn", post.PostedOn);
                command.Parameters.AddWithValue("postedBy", post.PostedBy);

                int rowsAffected = command.ExecuteNonQuery();




            }
        }
        //public IEnumerable<Post> GetAllPost()
        //{
        //    return new List<Post>
        //    {
        //        new Post()
        //        {
        //            Content = "Hello World",
        //            PostedBy = "joblipat",
        //            PostedOn = DateTime.Now,
        //        },
        //        new Post()
        //        {
        //            Content = "Hello new World",
        //            PostedBy = "Joemama",
        //            PostedOn = DateTime.Now,
        //        },
        //        new Post()
        //        {
        //            Content = "Hello new new World",
        //            PostedBy = "JoeBiden",
        //            PostedOn = DateTime.Now,
        //        },
        //    };
        //}


    }
}