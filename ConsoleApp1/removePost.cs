using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Dynamic;
/*
 Lösning skapad av Anders Sundin
 Moment 3 i kursen DT071G
 HT-23
 olsu2201
 */
namespace guestBook
{
    internal class RemovePost
    {

        public bool deleteIndex(string input)
        {
            // Parse input string to int
            if (int.TryParse(input, out int inputIndex)){

                // Read post file
                if (File.Exists("posts.json"))
                {
                    //Create a list for posts
                    var posts = new List<NewPost>();

                    // Save from json to string
                    string json = File.ReadAllText("posts.json");

                    // deserialize with List of type newPost (name and post)
                    posts = JsonConvert.DeserializeObject<List<NewPost>>(json);

                    //remove post att right index after checking if inputIndex is whithin range of post index range
                    if (inputIndex >= 0 && inputIndex < posts.Count)
                    { 
                        posts.RemoveAt(inputIndex);

                    // Convert to JSON

                    string newJson = JsonConvert.SerializeObject(posts, Formatting.Indented);

                    //Write to the file

                    File.WriteAllText("posts.json", newJson);

                    } else
                    {
                        return false;
                    }
                }

                return true;

            } else
            {
                Console.WriteLine("Du måste ange ett nummer som matchar en post");
                return false;
            }
        }
    }
}
