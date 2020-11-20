using System;
using System.Collections.Generic;

namespace GUIPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            GUI gui = new GUI();
            gui.AddRow(2);
            IWindow playerWindow = new BasicWindow();
            IWindow npcWindow = new BasicWindow();
            IWindow secondPlayerWindow = new BasicWindow();
            IWindow secondNpcWindow = new BasicWindow();
            gui.OpenWindows(new List<IWindow>() 
                    {
                    playerWindow,
                    npcWindow
                    }, 0);
            gui.OpenWindows(new List<IWindow>() 
                    {
                    secondPlayerWindow,
                    secondNpcWindow
                    }, 1);
            gui.Refresh();
            playerWindow.Print("I'll go over the colors one more time that we use: Titanium white, Thalo green, Prussian blue, Van Dyke brown, Alizarin crimson, Sap green, Cad yellow, and Permanent red. There isn't a rule. You just practice and find out which way works best for you. Just think about these things in your mind - then bring them into your world. Work on one thing at a time. Don't get carried away - we have plenty of time.  This is unplanned it really just happens. Let that brush dance around there and play. Son of a gun. From all of us here, I want to wish you happy painting and God bless, my friends. You can create the world you want to see and be a part of. You have that power. Let's make a happy little mountain now.  They say everything looks better with odd numbers of things. But sometimes I put even numbers—just to upset the critics. A big strong tree needs big strong roots. Making all those little fluffies that live in the clouds. It's life. It's interesting. It's fun. Put light against light - you have nothing. Put dark against dark - you have nothing. It's the contrast of light and dark that each give the other one meaning. You have to make these big decisions.  Look at them little rascals. You have freedom here. The only guide is your heart. Anytime you learn something your time and energy are not wasted. You can get away with a lot. Everyone needs a friend. Friends are the most valuable things in the world. I'm gonna add just a tiny little amount of Prussian Blue.");
            npcWindow.Print("It's you I like, It's not the things you wear, It's not the way you do your hair But it's you I like The way you are right now, The way down deep inside you Not the things that hide you, Not your toys They're just beside you.But it's you I like Every part of you.  Your skin, your eyes, your feelings Whether old or new.  I hope that you'll remember Even when you're feeling blue That it's you I like, It's you yourself It's you.  It's you I like.");
            //Console.WriteLine($"The original buffer size is {GUI.OrigBufferWidth} x {GUI.OrigBufferHeight}");
            //Console.WriteLine($"playerWindow starts at {playerWindow.BufferLeft}, and npcWindow starts at {npcWindow.BufferLeft}");
            //Console.WriteLine($"Row 1 has {GUI.Rows[0].Windows.Count} windows");
            //Console.CursorTop = 5;
            //Console.CursorLeft = 28;
            Console.ReadLine();
        }
    }
}
