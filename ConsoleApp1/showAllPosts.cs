using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Reflection.Metadata.Ecma335;
/*
 Lösning skapad av Anders Sundin
 Moment 3 i kursen DT071G
 HT-23
 olsu2201
 */
namespace guestBook
{
  
    internal class ShowAllPosts
    {
        
        public void allPosts() {

            //Create a list for posts
            var posts = new List<NewPost>();

            // see if file exists
            if (File.Exists("posts.json"))
            {
                // Save json to file
                string json = File.ReadAllText("posts.json");
                // deserialize with List of type newPost (name and post)
                posts = JsonConvert.DeserializeObject<List<NewPost>>(json);
                for (int i = 0; i < posts.Count; i++)
                {
                    var post = posts[i];
                    Console.WriteLine($" [{i}] {post.name} - {post.post}");
                }
            }
        }
    }
}
