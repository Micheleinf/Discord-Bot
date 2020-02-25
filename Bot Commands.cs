
//File: Bot Original / Bot Commands.cs
//Author: Michele Biondi
//Date: Last Updatet on February 25, 2020
//Description: Various Discord Bot Commands

using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace Bot_Commands.Bot_Commands
{

    public class Kick : ModuleBase<SocketCommandContext>
    {
        //Kick Command / Kicks a User from the Server
        [Command("kick"), Summary("Kicks a user from the guild.")]
        public async Task KickCommand(IGuildUser user, [Remainder] string reason = "no reason")
        {
            user.KickAsync(reason);
        }
    }
}


public class petshop : ModuleBase<SocketCommandContext>

{
    //Pet Shop / Shows the pet shop
    [Command("pls pet")]
    public async Task PingAsync()

    {
        await ReplyAsync("WELCOME TO THE PET SHOP 🛒 \n --------------------------------------------------- \n DOG                 5'000 Coins 🐕 \n CAT                  5'500 Coins 🐈 \n RABBIT            6'000 Coins 🐇 \n BIRD                18'000 Coins 🐦 \n PIG                  25'000 Coins 🐷 \n HORSE           50'000 Coins 🐎 \n TIGER           100'000 Coins 🐅 \n LION             100'500 Coins 🦁 \n BEAR             150'000 Coins 🐻 \n PENGUIN     170'000 Coins 🐧 \n BIG TIGER   200'000 Coins 🐯 \n DRAGON     250'000 Coins 🐉 \n ZOO   TYPE (zoo inf) for more informations \n --------------------------------------------------- \n for buying a pet use: pls buy pet (name of pet) (amount)");

    }
}

public class zoo : ModuleBase<SocketCommandContext>
{
    //Buy Zoo / Zoo information
    [Command("zoo inf")]
    public async Task PingAsync()
    {
        await ReplyAsync("ZOO INFORMATIONEN 🛒 \n --------------------------------------------------- \n DOG, CAT, RABBIT, BIRD, PIG, HORSE, TIGER, LION, BEAR, PENGUIN, BIG TIGER, DRAGON: EVERYTHING FOR JUST 1'000'000'000");


    }
}



public class Moin : ModuleBase<SocketCommandContext>
{
    //Moin Command / First Test Command made
    [Command("moin")]
    public async Task PingAsync()
    {
        await ReplyAsync("bonjour sakre blue");
    }
}



public class WWW3game : ModuleBase<SocketCommandContext>
{
    //Start ww3game Command
    [Command("ww3game")]
    public async Task PingAsync()
    {
        await ReplyAsync("TRUMP: Hello what country do you wanna be ");
        await ReplyAsync("/ canada / switzerland / iran / russia / china /germany");
    }
}

public class switzerland : ModuleBase<SocketCommandContext>
{
    //Part Command of ww3game
    [Command("switzerland")]
    public async Task PingAsync()
    {
        await ReplyAsync("Successfully entered spectator mode");
    }
}

public class iran : ModuleBase<SocketCommandContext>
{
    //Part Command of ww3game
    [Command("iran")]
    public async Task PingAsync()
    {
        await ReplyAsync("You got killed by Trump");
    }
}

public class russia : ModuleBase<SocketCommandContext>
{
    //Part Command of ww3game
    [Command("russia")]
    public async Task PingAsync()
    {
        await ReplyAsync("https://www.youtube.com/watch?v=NvS351QKFV4");
    }
}

public class trump : ModuleBase<SocketCommandContext>
{
    //Trump GIF Command
    [Command("trump")]
    public async Task PingAsync()
    {
        await ReplyAsync("https://tenor.com/view/donald-trump-wink-president-usa-gif-7576941");
    }
}

public class canada : ModuleBase<SocketCommandContext>
{
    //Part Command of ww3game
    [Command("canada")]
    public async Task PingAsync()
    {
        await ReplyAsync("You WON WW3");
    }
}

public class china : ModuleBase<SocketCommandContext>
{
    //Part Command of ww3game
    [Command("china")]
    public async Task PingAsync()
    {
        await ReplyAsync("https://tenor.com/view/china-gif-15414875");
    }
}

public class germany : ModuleBase<SocketCommandContext>
{
    //Part Command of ww3game
    [Command("germany")]
    public async Task PingAsync()
    {
        await ReplyAsync("https://me.me/embed/i/a476e74586cc4c0b84c22c4cc7ca68b3");
    }
}
