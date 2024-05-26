using Microsoft.Win32;
using System;

class Program
{
    
    static void Main()
    {
        List<string> AchWon = [
            "Acidic Atoll",
            "Aftershock Arena",
            "Altitude Attack",
            "Animal Arithmetic",
            "Barn Brawl",
            "Batty Batters",
            "Billiard Battle",
            "Bouncing Balls",
            "Bounding Blocks",
            "Breaking Blocks",
            "Bullet Barrage",
            "Cannon Circle",
            "Crown Capture",
            "Daring Dogfight",
            "Elemental Escalation",
            "Explosive Exchange",
            "Foggy Fall",
            "Forklift Fling",
            "Fractured Faces",
            "Gift Grab",
            "Grifting Gifts",
            "House Hunting",
            "Laser Leap",
            "Magma & Mages",
            "Memory Menu",
            "Miniature Motors",
            "Morphing Maze",
            "Mortar Mayhem",
            "Motor Murder",
            "Mystery Maze",
            "Pack And Pile",
            "Pummel Punch",
            "Risky Rubberbands",
            "Rockin Rhythm",
            "Rolly Ragdolls",
            "Rotor Race",
            "Rusty Racers",
            "Sandy Search",
            "Searing Spotlights",
            "Selfish Stride",
            "SharkySwim",
            "Sidestep Slope",
            "Slippery Sprint",
            "Snowy Spin",
            "Sorcerers Sprint",
            "Speedy Sabers",
            "Spooky Spikes",
            "Strategic Shockwave",
            "Swift Shooters",
            "Temporal Trails",
            "Thunderous Trench",
            "Traffic Theft",
            "Tunneling Tanks",
            "Word Wars"
        ];
        List<string> AchLost = [.. AchWon];
        do Calc(AchWon, AchLost);
        while (Console.ReadKey().Key == ConsoleKey.Enter);
    }

    static void Calc(List<string> AchWon, List<string> AchLost)
    {
        string keyPath = @"SOFTWARE\Rebuilt Games\Pummel Party";
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
        {
            if (key is not null)
            {
                foreach (string valueName in key.GetValueNames())
                {
                    if (valueName.IndexOf("_ACH_WON_") != -1)
                        AchWon.Remove(valueName.Split('_')[0]);
                    else if (valueName.IndexOf("_ACH_LOST_") != -1)
                        AchLost.Remove(valueName.Split('_')[0]);
                }
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Missing Ach won: ");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var item in AchWon)
                {
                    Console.WriteLine("\t" + item);
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Missing Ach lost: ");
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var item in AchLost)
                {
                    Console.WriteLine("\t" + item);
                }
            }
            else
            {
                Console.WriteLine($"Cannot find key: {keyPath}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter to update");
        }
    }
}