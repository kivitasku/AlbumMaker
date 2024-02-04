using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker
{
    class Program
    {

        static string page = System.IO.File.ReadAllText("example.html");


        static string replacementString;

        readonly static string li = "<li><p>song_name</p><audio controls id= \"index_num\" source src= \"source_src\" type= \"audio/flac\" ></audio ></li > ";





        static void Main(string[] args)
        {
            ReplaceWords();


            AddSongs();




            string filePath = "album.html"; 

            try
            {
                File.WriteAllText(filePath, page);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ReadKey();
            }


        }



        static void ReplaceWords()
        {
            Console.Write("Album img src: ");
            replacementString = Console.ReadLine();
            page = page.Replace("album_image", replacementString);

            Console.Write("Album name: ");
            replacementString = Console.ReadLine();
            page = page.Replace("album_name", replacementString);
            page = page.Replace("album_page", replacementString);

            Console.Write("Album creator: ");
            replacementString = Console.ReadLine();
            page = page.Replace("album_author", replacementString);

            Console.Write("Album info: ");
            replacementString = Console.ReadLine();
            page = page.Replace("album_info", replacementString);

        }

        private static void AddSongs() 
        {



            Console.Write("Enter the file extension: ");
            string fileExtension = Console.ReadLine();

            try
            {
                string[] matchingFiles = Directory.GetFiles(".", "*" + fileExtension);

                Console.WriteLine("Files with the specified extension:");
                int inum = 1;
                string songs = "";
                string songName;
                foreach (string filePath in matchingFiles)
                {
                    string li2 = li;
                    songName = filePath.Substring(2);
                    songName = songName.Replace(".flac", "");

                    li2 = li2.Replace("song_name", songName);

                    li2 = li2.Replace("source_src", filePath);


                    li2 = li2.Replace("index_num", inum.ToString());
                    inum++;
                    songs = songs + li2;





                }
                page = page.Replace("album_songs", songs);
                Console.ReadKey();
            }


            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ReadKey();
            }



        }



    }
}
