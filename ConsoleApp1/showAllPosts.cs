using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace guestBook
{
  
    internal class showAllPosts
    {
        
        public void allPosts() {

            //Create a list for posts
            var posts = new List<newPost>();

            // see if file exists
            if (File.Exists("posts.json"))
            {
                // Save json to file
                string json = File.ReadAllText("posts.json");
                // deserialize with List of type newPost (name and post)
                posts = JsonConvert.DeserializeObject<List<newPost>>(json);
                for (int i = 0; i < posts.Count; i++)
                {
                    var post = posts[i];
                    Console.WriteLine($" [{i}] {post.name} - {post.post}");
                }
            }
        }
    }
}
