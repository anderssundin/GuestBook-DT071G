using System;
using System.Collections.Generic;
using guestBook;





class Program
{
    static void Main(string[] args)
    {

        // Variables
        bool validChoice = false;

        // put menu in function for resuable purposes
        void printOptions()
        {
            // Header
            Console.WriteLine(" A N D E R S    G U E S T B O O K \n \n");
            
            //choices
            Console.WriteLine("1. Skriv i gästboken");
            Console.WriteLine("2. Ta bort inlägg \n");
            Console.WriteLine("X Avsluta \n");
            
            //display stored posts
            var allPosts = new ShowAllPosts();
            allPosts.allPosts();
        }
        printOptions();
       
     

        while (validChoice == false)
        {
            string choice = Console.ReadLine();
            // make to lowercase
            choice = choice.ToLower();
            switch (choice)
            {
                case "1":
                    //Logic for adding post
                    Console.Clear();
                    validChoice = true;
                   // get instanse of newPost
                    var addPost = new NewPost();
                    // get name input
                    Console.WriteLine("Vad heter du?");
                    addPost.name = Console.ReadLine();
                    if (addPost.name.Length > 0)
                    {
                        // get post input
                        Console.WriteLine($" Hej {addPost.name}. Skriv ditt inlägg: ");
                        addPost.post = Console.ReadLine();

                        if (addPost.post.Length  > 0)
                        {
                            // write to file
                            addPost.addNewPost(addPost.name, addPost.post);
                        }
                        else 
                        {
                            Console.WriteLine("Du måste ange en text");
                        }
                    } else 
                    {
                        Console.WriteLine("Du måste ange ett namn");
                    }
                  

                    
                   
                    
                    validChoice = false;
                    break;
                case "2":
                    Boolean validIndex = false;
                    while (!validIndex) {
                    Console.Clear();
                    Console.WriteLine(" R A D E R A  P O S T \n \n");
                    Console.WriteLine("Välj post att radera genom att välja dess nummer. \n Klicka på 'b' för att komma till huvudmenyn");
                       
                        // show all posts
                        var allPosts = new ShowAllPosts();
                        allPosts.allPosts();

                        string input = Console.ReadLine();
                   
                        if (input == "b" || input == "B")
                        {
                            validIndex = true;
                        } else
                        {
                          var removePost = new RemovePost();
                           if (removePost.deleteIndex(input)) 
                            { 
                            validIndex = true;
                            }
                        }
                    }
                    break;
                case "x":
                    // Avsluta
                    Environment.Exit(0);
                    validChoice = true;
                    break;
                //börja om
                default:
                    Console.Clear();
                    printOptions();
                    break;
            }
        }

    }
}
