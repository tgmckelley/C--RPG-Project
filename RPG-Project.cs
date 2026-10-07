class rpgGame
{
    // The game state as static fields
    static int playerHealth = 100;
    static int playerGold = 15; 
    static string playerName = "";
    static string playerWeapon = "Weathered Blade";
    static int playerDamage = 20;
    static bool gameOver = false; // creates a game over state to use later
    static int currentScene = 1;
    static int soldiersFreed = 0;
    static int enemyArmyStrength = 1000;
    static int armyStrength = 900;
    static int artilleryCount = 0;
    static int enemyArtilleryCount = 0;
    static List<string> freedSoldiers = new List<string>();
    static bool soldierEventDone = false;
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
        Console.WriteLine("Exiting Game...");
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
                        freedSoldiers.Add("Garen, Enemy Soldier");
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
                                    freedSoldiers.Add("Mordu, Enemy Soldier");
                                    Console.WriteLine("You free the second soldier, who joins your group.");
                                    Console.WriteLine("Another giant spider jumps out at you.");
                                    fightSpiders1();
                                    if (!gameOver)
                                    {
                                        Console.WriteLine("You defeat the spider and move further into the cave with your companions.");
                                        Console.WriteLine("You and your companions make your way into a massive room at the end of the cave.");
                                        Console.WriteLine("You find the massive queen spider, and she attacks.");
                                        Console.WriteLine("With the help of your new companions, you easily defeat the Queen Spider and emerge victorious.");
                                        Console.WriteLine("You befriend the enemy soldiers as you make your way out of the cave and back towards civilization.");
                                        currentScene = 3;
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("You walk past the second soldier, leaving him to his fate.");
                                    Console.WriteLine("Another giant spider jumps out at you, but he goes for the trapped soldier instead.");
                                    if (!gameOver)
                                    {
                                        Console.WriteLine("You avoid the spider and move further into the cave with your companion.");
                                        Console.WriteLine("You and your companion make your way into a massive room at the end of the cave.");
                                        Console.WriteLine("You find the massive queen spider, and she attacks.");
                                        Console.WriteLine("Without the help of the second soldier, you are forced into a tough battle against the Queen Spider!");
                                        fightQueenSpider();
                                        if (!gameOver)
                                        {
                                            Console.WriteLine("You defeat the Queen Spider and emerge victorious.");
                                            Console.WriteLine("You befriend the enemy soldier as you make your way out of the cave and back towards civilization.");
                                            currentScene = 3;
                                        }
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
                Console.WriteLine("You choose to search the right path. The rest go down the left path.");
                Console.WriteLine("You become lost in the maze of tunnels, with no way out. You are doomed.");
                gameOver = true;
                break;
        }
    }

    static void runBattle()
    {
        Console.WriteLine("One year Later...");
        Console.WriteLine("You are now a lieutenant in the army, serving directly under the commander who had once captured you.");
        Console.WriteLine("Over the year that you've served, you have gained much wealth");
        playerGold += 500;
        Console.WriteLine($"500 gold has been added to your inventory.");
        Console.WriteLine($"You now have {playerGold} gold.");
        Console.WriteLine("A new threat awaits on your doorstep. The army you were once a part of has returned, ready for revenge.");
        Console.WriteLine("You must face your former comrades in battle.");
        Console.WriteLine("Rules for the battle:\nThe invading army will start with 1000 health\nThe defending army will start with 900 health\nYour choices will determine who will win.");
        Console.WriteLine("To prepare for the battle, you may either:");
            Console.WriteLine("1. Hire mercenaries with your gold (More overall army but the enemy has more artillery)");
            Console.WriteLine("2. Build artillery for your army (Damage per turn on the enemy army but the enemy has more health)");
            int sixthChoice = getChoice(1, 2);
            switch (sixthChoice)
            {
                case 1:
                    Console.WriteLine("You choose to hire mercenaries with your gold.");
                    playerGold -= 300;
                    Console.WriteLine("You spent 300 gold on mercenaries.");
                    armyStrength += 400;
                    Console.WriteLine($"Current Army Strength: {armyStrength}");
                    enemyArtilleryCount += 3;
                    Console.WriteLine("The enemy has gained more artillery.");
                    Console.WriteLine("The enemy approaches, ready to engage in battle.");
                    Console.WriteLine("The battle begins on an open field.");

                    break;
                case 2:
                    Console.WriteLine("You choose to build artillery for your army.");
                    playerGold -= 500;
                    Console.WriteLine("You spent 500 gold on artillery.");
                    artilleryCount++;
                    Console.WriteLine("Your artillery will now do damage to the enemy each turn.");
                    enemyArmyStrength += 200;
                    Console.WriteLine($"The enemy has gained strength, they now have {enemyArmyStrength} health.");
                    enemyArtilleryCount += 2;
                    Console.WriteLine("The enemy has gained less artillery.");
                    Console.WriteLine("The enemy approaches, ready to engage in battle.");
                    Console.WriteLine("The battle begins on an open field.");
                    break;
            }  
            bool wonBattle = armyFight();
            if (wonBattle)
            {
                Console.WriteLine("You stand in triumph over your former comrades.\nIt is with a heavy heart that you accept the glory of this battle as you protect your new home for many more years to come.");
                Console.WriteLine("You were victorious, thanks for playing!");
                gameOver = true;
            }
            else
            {
                Console.WriteLine("You have been defeated...");
                Console.WriteLine("Game over.");
                gameOver = true;
            }
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



    
    
    
    
    
    
    
    
    
    
    
    
    // helper function for queen spider
    static void fightQueenSpider()
    {
        bool wonFight = fight("Queen Spider", 90);
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

    
    
    








    // event for freed soldiers helping the player during the battle
    static void soldierEvent()
    {
        soldierEventDone = true;
        if (soldiersFreed == 1)
        {
            Console.WriteLine($"\n{freedSoldiers[0]}, the soldier you freed in the cave, appears on the ridge!");
        }
        else
        {
            Console.WriteLine("\nThe soldiers you freed in the cave appear on the ridge!");
        }

        foreach (string soldier in freedSoldiers)
        {
            Console.WriteLine($"{soldier} slips toward the enemy cannons...");
        }

        enemyArtilleryCount = 0;
        Console.WriteLine("The enemy has no artillery left!");

        if (soldiersFreed == 2)
        {
            Console.WriteLine("Together, the two soldiers lead their units to route the enemy army into your ambush!");
            enemyArmyStrength -= 200;
        }
    }






    
    
    
    
   





    // LARGE function for the army fight in scene 3
    static bool armyFight()
    {
        int armyRound = 0;
        while (armyStrength > 0 && enemyArmyStrength > 0)
        {
            armyRound++;

           if(artilleryCount > 0)
            {
                int shellDamage = artilleryCount * 50; // damage per artillery piece
                enemyArmyStrength -= shellDamage;
                Console.WriteLine($"\nYou fire your artillery at the enemy army! They take {shellDamage} damage!");
            }
            
            if(armyRound == 4 && soldiersFreed > 0 && enemyArtilleryCount > 0)
            {
                soldierEvent();

                if (enemyArmyStrength <= 0)
                {
                    Console.WriteLine("The ambush shatters the enemy army!");
                    break;
                }
            }
            
            if(enemyArmyStrength <= 0)
            {
                Console.WriteLine("Your artillery has destroyed the enemy army.");
                break;
            }
        

            bool defending = false;
            bool canRaid = enemyArtilleryCount > 0;

            Console.WriteLine($"\nRound {armyRound} | Your army: {armyStrength} Power | Enemy army: {enemyArmyStrength} Power");
            Console.WriteLine($"Artillery: Your army has {artilleryCount} | The enemy has {enemyArtilleryCount}");
            Console.WriteLine("1. Attempt a direct cavalry charge");
            Console.WriteLine("2. Hold your ground");
            Console.WriteLine("3. Attempt to place archers on the hills above the battlefield");
            Console.WriteLine("4. Attempt to flank the enemy from either direction");
            if (canRaid)
            {
                Console.WriteLine("5. Attempt to destroy the enemy artillery");
            }
            int maxChoice = 4;
            if (canRaid)
            {
                maxChoice = 5;
            }
            int armyChoice = getChoice(1, maxChoice);
            switch (armyChoice)
            {
                case 1:
                    Console.WriteLine("You charge the enemy with your cavalry.");
                    enemyArmyStrength -= 200;
                    armyStrength -= 120;
                    Console.WriteLine("The enemy takes 200 damage");
                    Console.WriteLine("You take 120 damage");
                    break;
                case 2:
                    Console.WriteLine("You hold your ground against the enemy assault.");
                    enemyArmyStrength -= 50;
                    defending = true;
                    Console.WriteLine("The enemy takes 50 damage");
                    Console.WriteLine("You take no damage");
                    break;
                case 3:
                    Console.WriteLine("You position your archers on the hills, raining arrows down on the enemy.");
                    enemyArmyStrength -= 120;
                    armyStrength -= 40;
                    Console.WriteLine("The enemy takes 120 damage");
                    Console.WriteLine("You take 40 damage");
                    break;
                case 4:
                    Console.WriteLine("You attempt to flank the enemy.");
                    if (soldierEventDone)
                    {
                        Console.WriteLine("The enemy is still confused after the sabotage!\nThey take extra damage this turn");
                        enemyArmyStrength -= 250;
                        armyStrength -= 50;
                        Console.WriteLine("The enemy takes 250 damage");
                        Console.WriteLine("You take 50 damage");
                    }
                    else
                    {
                        Console.WriteLine("You flank the enemy with mild success.");
                        enemyArmyStrength -= 150;
                        armyStrength -= 100;
                        Console.WriteLine("The enemy takes 150 damage");
                        Console.WriteLine("You take 100 damage");
                    }
                    break;
                case 5:
                    Console.WriteLine("You target the enemy artillery!");
                    if (armyStrength >= 700)
                    {
                        Console.WriteLine("You have enough strength to destroy one of the enemy's artillery weapons!");
                        enemyArtilleryCount--;
                        armyStrength -= 50;
                        Console.WriteLine("The enemy loses an artillery piece");
                        Console.WriteLine("You take 50 damage");
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough strength to destroy the enemy's artillery weapons.");
                        armyStrength -= 120;
                        Console.WriteLine("The enemy takes no damage");
                        Console.WriteLine("You take 120 damage");
                    }
                    break;
            }

            if (enemyArmyStrength <= 0)
            {
                Console.WriteLine("The enemy has been defeated!");
                break;
            }

            int enemyShells = enemyArtilleryCount * 40;
            int enemyAttack = 50;

            if (defending)
            {
                enemyShells /= 2;
                enemyAttack /= 2;
                Console.WriteLine("The enemy's attacks are weakened by your defensive stance");
            }

            if (enemyShells > 0)
            {
                armyStrength -= enemyShells;
                Console.WriteLine($"The enemy's artillery strikes your army for {enemyShells} damage");
            }
            if (armyStrength <= 0)
            {
                Console.WriteLine("Your army has been defeated by the enemy's artillery");
                break;
            }

            armyStrength -= enemyAttack;
            Console.WriteLine($"The enemy attacks you and you lose {enemyAttack} power");
            if (armyStrength <= 0)
            {
                Console.WriteLine("Your army has been defeated by the enemy's attacks");
                break;
            }
        }

        return armyStrength > 0;
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

            if (enemyName == "Queen Spider")
            {
                switch (fightTurn % 2)
                {
                    case 1:
                        enemyAttack = "Venomous Bite";
                        damageTaken = 30;
                        break;
                    case 0:
                        enemyAttack = "Web Shot";
                        damageTaken = 18;
                        break;
                }
            }
            else if (enemyName == "Giant Spider") // if else statement that ensures spiders do not use human attacks
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