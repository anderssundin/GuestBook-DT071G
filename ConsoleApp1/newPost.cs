using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


/*
 Lösning skapad av Anders Sundin
 Moment 3 i kursen DT071G
 HT-23
 olsu2201
 */
namespace guestBook
{


    class NewPost
    {
        //Name of author
        public string name { get; set; }
        //Post content
        public string post { get; set; }

        // Method for saving new post
        public void addNewPost(string author, string content)
        {

            //Create a list for posts
            List<NewPost> posts = new List<NewPost>();
           
            // see if file exists
            if (File.Exists("posts.json")) 
            {
                string json = File.ReadAllText("posts.json");
                posts = JsonConvert.DeserializeObject<List<NewPost>>(json);
            }

            // Add new post to file

            posts.Add(new NewPost { name = author, post = content });

            // Convert to JSON

            string newJson = JsonConvert.SerializeObject(posts, Formatting.Indented);

            //Write to the file

            File.WriteAllText("posts.json", newJson);
            Console.Clear();
            Console.WriteLine($"\n    Nytt inlägg skapat av {author}:\n \n    {content}. \n\n " +
                $"----------------------------------------------------- \n\n" +
                $"Klicka på någon knapp för att återvända till menyn");
        }
    }


}
