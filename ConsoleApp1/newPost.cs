using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace guestBook
{


    class newPost
    {
        //Name of author
        public string name { get; set; }
        //Post content
        public string post { get; set; }

        // Method for saving new post
        public void addNewPost(string author, string content)
        {

            //Create a list for posts
            List<newPost> posts = new List<newPost>();
           
            // see if file exists
            if (File.Exists("posts.json")) 
            {
                string json = File.ReadAllText("posts.json");
                posts = JsonConvert.DeserializeObject<List<newPost>>(json);
            }

            // Add new post to file

            posts.Add(new newPost { name = author, post = content });

            // Convert to JSON

            string newJson = JsonConvert.SerializeObject(posts, Formatting.Indented);

            //Write to the file

            File.WriteAllText("posts.json", newJson);

            Console.WriteLine($"Nytt inlägg skapat av {author}: {content}. \n Klicka på någon knapp för att återvända till menyn");
        }
    }


}
