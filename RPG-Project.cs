class rpgGame
{
    // The game state as static fields
    static int playerHealth = 100;
    static int playerGold = 15; // will use in scene 3
    static string playerName = "";
    static string playerWeapon = "Weathered Blade";
    static int playerDamage = 20;
    static bool gameOver = false; // creates a game over state to use later
    static int currentScene = 1;
    static int soldiersFreed = 0;
    static void Main()
    {
        while (!gameOver)
        {
            switch (currentScene)
            {
                case 1: runIntro(); break;
                case 2: runCave(); break;
                case 3: runBattle(); break;
            }
        }
        Console.WriteLine("Game Over.");
    }
    static void runIntro()
    {
        Console.WriteLine("Controls:\n- Press 1 to choose the first option\n- Press 2 to choose the second option\n- Type 'Exit' to quit the game\n- Type 'Stats' to view your character's stats");
        Console.WriteLine("You awake on a battlefield, the battle already over. You are taken captive, the sole survivor of your army.The commander of the rival kingdom looks at you and asks you your name.");
        Console.Write("Enter your name: "); 
        playerName = Console.ReadLine() ?? "";
        Console.WriteLine($"\"Welcome to our kingdom, {playerName}! The dungeon master will be so excited to meet an invader like you.\""); 
        Console.WriteLine("1. \"Wait! I have gold on me, it's yours if you let me go.\""); 
        Console.WriteLine("2. \"Wait! I will fight for your army if you let me live.\""); 

        int firstChoice = getChoice(1, 2); 

        switch (firstChoice) 
        {
            case 1: 
                Console.WriteLine("\"Ha! You think a measly few coins will save your hide? Off to the stockades with you!\""); 
                Console.WriteLine("You spend the rest of your days in a foreign dungeon alone.");
                gameOver = true;
                break;
            case 2: 
                Console.WriteLine("\"So you think you can just join our army to save yourself? I'll entertain it, but first you must prove yourself!\""); 
                Console.WriteLine("You are thrown into a circle of soldiers along with a fellow captive from your own army. \"Each of you kill the other. Whoever lives shall join our army.\""); 
                fightPrisoner();
                if (!gameOver)
                {
                    Console.WriteLine($"\"Congratulations, {playerName}!\" the commander says. \"You've proven yourself worthy of being fodder for the front line.\"");
                    chooseWeapon();
                    Console.WriteLine($"Now that you have a weapon, you rest up and recover from your wounds before officially joining the foreign army.");
                    playerHealth = 100;
                    Console.WriteLine($"Player Health has been restored to {playerHealth}.");
                    currentScene = 2;
                }
                break;
        }
    }

    static void runCave()
    {
        Console.WriteLine("Six Months Later...");
        Console.WriteLine("You are now a member of the foreign army, serving under the commander.");
        Console.WriteLine("You are sent with a team of 5 other soldiers into a cave that has been rumored to be a hideout for an enemy kingdom.");
        Console.WriteLine("You come across a split in the cave path.");
        Console.WriteLine($"\"Alright soldiers, let's split up and search this cave. {playerName}! Do you want to search the left or the right?\"");
        Console.WriteLine("1. I will search the left path.");
        Console.WriteLine("2. I will search the right path.");
        int secondChoice = getChoice(1, 2);
        switch (secondChoice)
        {
            case 1:
                Console.WriteLine("You choose to search the left path. The rest of the soldiers go down the right path.");
                Console.WriteLine("You come across a large chamber with spider webs everywhere.");
                Console.WriteLine("An enemy soldier cries out from the webbing.");
                Console.WriteLine("\"Help! Any longer and they'll return!\"");
                Console.WriteLine("1. Help free the soldier.");
                Console.WriteLine("2. Take the soldier's money and mock him.");
                int thirdChoice = getChoice(1, 2);
                switch (thirdChoice)
                {
                    case 1:
                        soldiersFreed++;
                        Console.WriteLine("You cut the webbing and free the enemy soldier");
                        Console.WriteLine("He joins your group, and you attempt to go deeper into the cave.");
                        Console.WriteLine("A Giant Spider jumps out at you.");
                        fightSpiders1();
                        if (!gameOver)
                        {
                            Console.WriteLine("You defeat the spider and move further into the cave with your new companion.");
                            Console.WriteLine("Up ahead in the next room, there is another trapped soldier.");
                            Console.WriteLine("1. Free him.");
                            Console.WriteLine("2. Walk past him.");
                            int fourthChoice = getChoice(1, 2);
                            switch (fourthChoice)
                            {
                                case 1:
                                    soldiersFreed++;
                                    Console.WriteLine("You free the second soldier, who joins your group.");
                                    Console.WriteLine("Another giant spider jumps out at you.");
                                    fightSpiders1();
                                    if (!gameOver)
                                    {
                                        Console.WriteLine("You defeat the spider and move further into the cave with your companions.");
                                        Console.WriteLine("You and your companions make your way into a massive room at the end of the cave.");
                                        Console.WriteLine("You find massive queen spider, and she attacks.");
                                        Console.WriteLine("With the help of your new companions, you defeat the Queen Spider and emerge victorious.");
                                        currentScene = 3;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("You walk past the second soldier, leaving him to his fate.");
                                    Console.WriteLine("Another giant spider jumps out at you.");
                                    fightSpiders1();
                                    if (!gameOver)
                                    {
                                        Console.WriteLine("You defeat the spider and move further into the cave with your companions.");
                                        Console.WriteLine("You and your companions make your way into a massive room at the end of the cave.");
                                        Console.WriteLine("You find massive queen spider, and she attacks.");
                                        Console.WriteLine("Without the help of the second soldier, you are defeated by the Queen Spider and fall in battle.");
                                        gameOver = true;
                                        break;
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("You attempt to take the soldier's gold while mocking his predicament. A giant spider then jumps onto you and you fall to its venom.");
                        gameOver = true;
                        break;
                }
                break;
            case 2:
                Console.WriteLine("You choose to search the right path. Two other soldiers follow you, the rest going down the left path.");
                Console.WriteLine("You become lost in the maze of tunnels, with no way out. You are doomed.");
                gameOver = true;
                break;
        }
    }

    static void runBattle()
    {
        Console.WriteLine("To be continued...");
        gameOver = true;
    }

   
   
   
   
   
   // FUNCTIONS

   
   
   
    // helper function for the prisoner fight in the intro
    static void fightPrisoner() // prisoner fight in the intro calls the fight function
    {
        bool wonFight = fight("Fellow Prisoner", 60);
        if (!wonFight)
        {
            Console.WriteLine("You collapse from your wounds");
            gameOver = true;
        }
    }

    
    
    
    
   
   
   
   
   
   
   
    // helper function for fighting spiders
    static void fightSpiders1()
    {
        bool wonFight = fight("Giant Spider", 40);
        if (!wonFight)
        {
            Console.WriteLine("You collapse from your wounds");
            gameOver = true;
        }
    }

    
    
    
    
    
    
    
    
    
    
    
    
    // function to display player stats
    static void showStats()
    {
        Console.WriteLine($"HP: {playerHealth} | Gold: {playerGold} | Weapon: {playerWeapon} | Soldiers Freed: {soldiersFreed}");
    }

   



   
   
   
    
   
   
   
   
   
    // function w/ array to choose a weapon in the intro
    static void chooseWeapon()
    {
        // two parallel arrays
        string[] weaponNames = { "Battle Axe", "Longbow", "Daggers" };
        int[] weaponDamages = { 30, 20, 15 };
        Console.WriteLine("Choose your new weapon:");
        for (int i = 0; i < weaponNames.Length; i++)
        {
            Console.WriteLine($"{i + 1}. ({weaponNames[i]} - {weaponDamages[i]} damage) "); // i+1 is so the player sees 1-3 and not 0-2
        }

        int choice = getChoice(1, weaponNames.Length);
        playerWeapon = weaponNames[choice - 1]; //subtracts 1 so player choice is converted back into array index
        playerDamage = weaponDamages[choice - 1];
        Console.WriteLine($"You have chosen the {playerWeapon}.");
    }

    
    
    
    
    
    
    
   
   
   
   
   
    // reusable fight function to use throughout the game
    static bool fight(string enemyName, int enemyHealth)
    {
        int fightTurn = 0; // keeps track of the turns during the fight for differing enemy choices.

        while (enemyHealth > 0 && playerHealth > 0)
        {
            fightTurn++; // keeps the fight turn count moving up for each player choice.
            Console.WriteLine($"\n{playerName}: {playerHealth} HP | {enemyName}: {enemyHealth} HP");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Block");

            int combatChoice = getChoice(1,2);
            bool block = false; // this starts a variable to track the player blocks. It starts off false until the player blocks in combat.

            switch (combatChoice)
            {
                case 1:
                    Console.WriteLine($"You swing your {playerWeapon} at the {enemyName}!");
                    enemyHealth -= playerDamage;
                    break;
                case 2:
                    Console.WriteLine($"You raise your {playerWeapon} in preparation for the {enemyName}'s attack.");
                    block = true;
                    break;
            }
            
            // code for enemy turn

            if (enemyHealth <= 0)
            {
                Console.WriteLine($"{enemyName} has been defeated!");
                break;
            }
            int damageTaken = 0;
            string enemyAttack = "";

            // this is the start of the enemy's turn

            if (enemyName == "Giant Spider") // if else statement that ensures spiders do not use human attacks
            {
                enemyAttack = "Venomous Bite";
                damageTaken = 16;
            }
            else
            {
                switch (fightTurn % 2)
                {
                    case 1:
                        enemyAttack = "Light Slash";
                        damageTaken = 20;
                        break;
                    case 0: // has to be case 0 because the % 2 command won't return 2 ever
                        enemyAttack = "Heavy Thrust";
                        damageTaken = 40;
                        break;
                }
            }
            if (block)
            {
                Console.WriteLine($"You block the {enemyName}'s {enemyAttack}! The damage will be reduced.");
                damageTaken /= 2; // Reduce damage by half if blocking
            }
            Console.WriteLine($"The {enemyName} hits {playerName} with a {enemyAttack}! {playerName} took {damageTaken} damage.");
            playerHealth -= damageTaken;
        }
        return playerHealth > 0;   
    }

   
   
   
   
   
   
    
    
    
    
    
    
    
    
    
    
    
    
    // reusable input checker for each choice in-game
    // this function also includes ways to exit the game and check stats
    static int getChoice(int min, int max)
    {
        while (true)
        {
            Console.Write("> ");
            string? input = Console.ReadLine();

            if (input == "Exit")
            {
                Console.WriteLine("Exiting the game...");
                Environment.Exit(0); 
                // This command allows the program to quit immediately without returning something from the getChoice function

            }
            
            if (input == "Stats")
            {
                showStats();
                continue;
            }
            
            if (int.TryParse(input, out int choice))
            {
                if (choice >= min && choice <= max)
                {
                    return choice;
                }
            }

            Console.WriteLine($"Please enter a number from {min} to {max}.");
        }
    }
}