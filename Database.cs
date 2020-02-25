//File: Bot Original / Database.cs
//Author: Michele Biondi
//Date: Last Updatet on February 25, 2020
//Description: Economy Command (Coins and Balance), Pet Shop Command (for buying a pet)

using System;
using System.Threading.Tasks;
using Discord.Commands;
using System.Data.SqlClient;

namespace Bot_Commands.Bot_Commands
{
    public class coins : ModuleBase<SocketCommandContext>
    {
        [Command("pls coins")]

        public async Task Coins()
        {
            Console.WriteLine("Coin System Open");
            Random rnd = new Random();
            int randomzahl = rnd.Next(1, 100);

            string autor = Context.Message.Author.Username;
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\biond\Documents\Coins.mdf;Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Open!");

            Guid newGUID = Guid.NewGuid();


            await ReplyAsync(autor + " you received " + randomzahl + " Coins");
            string insertQuery = "Update Coins Set bank = bank + " + randomzahl + " where username = '" + autor + "'; ";
            SqlCommand com = new SqlCommand(insertQuery, cnn);



            com.ExecuteNonQuery();



            cnn.Close();
            Console.WriteLine("Coin System Closed");
        }

        [Command("pls balance")]
        public async Task balance()
        {
            int coins = 0;
            string coiins = "";
            string author = Context.Message.Author.Username;

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\biond\Documents\Coins.mdf;Integrated Security=True;Connect Timeout=30";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Opend");

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Select bank from Coins Where Username = '" + author + "'; ", cnn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //Console.WriteLine(myReader["Coins"].ToString());
                    coiins = myReader["bank"].ToString();
                    coins = Convert.ToInt32(coiins);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            cnn.Close();
            Console.WriteLine("Connection Closed\n");

            await ReplyAsync(author + " you have " + coins + " Coins");
        }
        [Command("pls buy pet")]
        public async Task buy(string item, int anz)
        {
            string author = Context.User.Username;
            string cost2 = "";
            int cost = 0;
            int zahle = 2;
            string coiins;
            int coins = 0;
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\biond\Documents\Coins.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Pet Store Opend");
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Select Cost from Petstore Where Pet = '" + item + "'; ", cnn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //Console.WriteLine(myReader["Coins"].ToString());
                    coiins = myReader["Cost"].ToString();
                    coins = Convert.ToInt32(coiins);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Select bank from Coins Where Username ='" + author + "'", cnn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    //Console.WriteLine(myReader["Coins"].ToString());
                    cost2 = myReader["bank"].ToString();
                    cost = Convert.ToInt32(cost2);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            zahle = Convert.ToInt32(coins) * Convert.ToInt32(anz);
            if (cost < zahle)
            {
                await ReplyAsync(Context.Message.Author.Mention + " bro you need more Money to get this item");
            }
            else
            {
                string insertQuery = "Update Items Set " + item + " = " + item + " + " + anz + " where Username = '" + author + "';";

                SqlCommand com = new SqlCommand(insertQuery, cnn);
                com.ExecuteNonQuery();

                insertQuery = "Update Coins Set bank = bank - " + zahle + " where Username = '" + author + "'; ";

                SqlCommand com2 = new SqlCommand(insertQuery, cnn);
                com2.ExecuteNonQuery();

                cnn.Close();
                Console.WriteLine("Connection Pet Store Closed");
                await ReplyAsync(Context.Message.Author.Mention + " you have bought " + anz + " " + item + " for " + zahle + " coins");

                //Console.WriteLine("Zahlt: " + zahle + "\nKostet: " + cost + "\nItem: " + item + "\nQuery: " + insertQuery + "\n");
            }
        }
        [Command("pls pet inventory")]
        public async Task inventar()
        {
            int[] item = new int[13];

            string[] itemname = new string[13];
            itemname[0] = "dog";
            itemname[1] = "cat";
            itemname[2] = "rabbit";
            itemname[3] = "bird";
            itemname[4] = "pig";
            itemname[5] = "horse";
            itemname[6] = "tiger";
            itemname[7] = "lion";
            itemname[8] = "bear";
            itemname[9] = "penguin";
            itemname[10] = "bigtiger";
            itemname[11] = "dragon";
            itemname[12] = "zoo";

            int i = 0;
            string pc2 = "";
            int times = 0;
            string author = Context.Message.Author.Username;

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\biond\Documents\Coins.mdf;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            Console.WriteLine("Connection Opend");

            try
            {
                while (times < 13)
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("Select " + itemname[i] + " from Items Where Username = '" + author + "'; ", cnn);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        //Console.WriteLine(myReader["Coins"].ToString());
                        pc2 = myReader[itemname[i]].ToString();
                        item[i] = Convert.ToInt32(pc2);
                    }
                    times++;
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            cnn.Close();
            Console.WriteLine("Connection Closed");
            await ReplyAsync(Context.Message.Author.Mention + " Pet Inventory of " + author + "\n" + itemname[0] + ": " + item[0] + "\n" + itemname[1] + ": " + item[1] + "\n" + itemname[2] + ": " + item[2] + "\n" + itemname[3] + ": " + item[3] + "\n" + itemname[4] + ": " + item[4] + "\n" + itemname[5] + ": " + item[5] + "\n" + itemname[6] + ": " + item[6] + "\n" + itemname[7] + ": " + item[7] + "\n" + itemname[8] + ": " + item[8] + "\n" + itemname[9] + ": " + item[9] + "\n" + itemname[10] + ": " + item[10] + "\n" + itemname[11] + ": " + item[11] + "\n" + itemname[12] + ": " + item[12]);


        }
    }
}
