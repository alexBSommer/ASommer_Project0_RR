using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestarauntReviewerLibrary;
using RestaurauntReviewerDataAccess;
using System.Data.Entity;
using NLog;

namespace RestrauntReviewer0
{
    class Program
    {
        /*
         * Menu of possible actions for the user
         * Gracefully handle invalid input
         * Nlogger
         * 
         * Functionality:
         * display top 3 restaurants by average rating
         * display all restaurants
         * should allow more than one method of sorting
         * display details of a restaurant
         * display all the reviews of a restaurant
         * search restaurants (e.g. by partial name), and display all matching results
         * quit application
         */
        public static Logger logger = LogManager.GetCurrentClassLogger();    
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            //call a review manager from he library
            //in a try-catch
            //give options to quit
            //loop of user input?
            RestaurauntDbCRUD crud = new RestaurauntDbCRUD();
            
            
            string command = null;
            while (true)
            {
                Console.WriteLine("Type a Command: ");
                Console.WriteLine("(show , add, delete, top three, change name, find, reviews, quit)");
                command = Console.ReadLine();
                if (command == "quit")
                    break;
                else switch (command)
                    {
                        case ("show"):
                            try
                            {
                                Console.WriteLine("sort by Id, Name, or City?");
                                List<Restauraunt> fullList = null;
                                foreach (Restauraunt r in crud.db.restauraunts)
                                {
                                    fullList.Add(r);
                                }
                                string choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case ("Name"):
                                        fullList.OrderBy(x => x.Name).ToList();
                                        break;
                                    case ("City"):
                                        fullList.OrderBy(x => x.City).ToList();
                                        break;
                                    default:
                                        Console.WriteLine("sorting by default");
                                        break;
                                }//end of switch statement

                                foreach (Restauraunt r in fullList)
                                {
                                    Console.WriteLine(r.ToString());
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }
                            break;
                        case ("add"):
                            try
                            {
                                Console.WriteLine("Enter the Id, Name, City, State, and Address of the restaraunt to add");
                                Restauraunt target = new Restauraunt(Console.Read(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
                                crud.AddRestaraunt(target);
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }
                            
                            break;
                        case ("delete"):
                            try
                            {
                                Console.WriteLine("Enter the Id number of the Restaraunt to delete:");
                                crud.DeleteRestaraunt(Console.Read());
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }
                            
                            break;
                        case ("top three"):
                            try
                            {
                                List<Restauraunt> fullList = null;
                                foreach (Restauraunt r in crud.db.restauraunts)
                                {
                                    fullList.Add(r);
                                }
                                List<Restauraunt> topList = TopThree.GetTop(fullList);
                                foreach (Restauraunt r in topList)
                                {
                                    Console.WriteLine(r.ToString());
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }
                            
                            break;
                        case ("change name"):
                            try
                            {
                                Console.WriteLine("Enter the Id and new name of the restaraunt to change:");
                                crud.ChangeRestarauntName(Console.Read(), Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }
                            
                            break;
                        case ("find"):
                            try
                            {
                                Console.WriteLine("Enter the name to search for");
                                foreach (Restauraunt r in crud.SearchRestaraunts(Console.ReadLine()))
                                {
                                    Console.WriteLine(r.ToString());
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }
                            break;
                        case ("reviews"):
                            try
                            {
                                Console.WriteLine("Enter the Restaraunt name to search for");
                                foreach (Restauraunt r in crud.SearchRestaraunts(Console.ReadLine()))
                                {
                                    Console.WriteLine(r.ToString());
                                    foreach (Review q in r.Reviews)
                                    {
                                        Console.WriteLine(q.ToString());
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                logger.Error(e.Message);
                                throw;
                            }

                            break;
                        default:
                            Console.WriteLine("Not a valid command.");
                            logger.Error ("User entered an invalid command.");
                            break;
                    }//end of switch statement

            }
            Console.WriteLine("Goodbye!");
            Console.Read();
        }
    }
}
