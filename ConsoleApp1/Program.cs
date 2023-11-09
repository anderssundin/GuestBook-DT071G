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
            var allPosts = new showAllPosts();
            allPosts.allPosts();
        }
        printOptions();
       
     

        while (validChoice == false)
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    //Logic for adding post
                    Console.Clear();
                    validChoice = true;
                   // get instanse of newPost
                    var addPost = new newPost();
                    // get name input
                    Console.WriteLine("Vad heter du?");
                    addPost.name = Console.ReadLine();
                   // get post input
                    Console.WriteLine($" Hej {addPost.name}. Skriv ditt inlägg: ");
                    addPost.post =  Console.ReadLine();
                    // write to file
                    addPost.addNewPost(addPost.name, addPost.post);
                   
                    validChoice = false;
                    break;
                case "2":
                    //funktion här
                    Console.WriteLine("du valde 2");
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
