using mis321_pa4_njvirgin;
Main();

static void Main(){
    System.Console.WriteLine("Welcome to the Battle of Calypso's Maelstrom! Both players will be asked to enter their names and pick a character");
    Character p1 = new Character();
    Character p2 = new Character();
    p1 = NewPlayer();
    p2 = NewPlayer();
    System.Console.WriteLine($"\nGenerating characters......");
    System.Threading.Thread.Sleep(3000);
    ViewStats(p1, p2);
    int num = FirstGo();
    Game(num, p1, p2);
}

static Character NewPlayer(){
    Character player = new Character();
    System.Console.WriteLine($"\nWelcome player, please enter your name");
    string pName = Console.ReadLine();

    Menu choice = new Menu();
    int charChoice = choice.GetCharacter();
    int mp = Character.GetMaxPower();

    switch(charChoice){
        case 1:
            player = new JackSparrow(){name = pName, charName = "Jack Sparrow", maxPower = mp, health = 100, attackStrength = Character.GetAttackStrength(mp), defensivePower = Character.GetDefensivePower(mp)};
        break;
        case 2: 
            player = new WillTurner(){name = pName, charName = "Will Turner", maxPower = mp, health = 100, attackStrength = Character.GetAttackStrength(mp), defensivePower = Character.GetDefensivePower(mp)};
        break;
        case 3:
            player = new DavyJones(){name = pName, charName = "Davy Jones", maxPower = mp, health = 100, attackStrength = Character.GetAttackStrength(mp), defensivePower = Character.GetDefensivePower(mp)};
        break;
    }
    return player;
    
}

static void ViewStats(Character p1, Character p2){
    System.Console.WriteLine($"\nThe stats are: \n\nPlayer1: {p1.charName} \nHealth: {p1.health} \nMax Power: {p1.maxPower} \nAttack: {p1.attackStrength} \nDefence: {p1.defensivePower}\n\nPlayer2: {p2.charName} \nHealth: {p2.health} \nMax Power: {p2.maxPower} \nAttack: {p2.attackStrength} \nDefence: {p2.defensivePower}");
    System.Threading.Thread.Sleep(5000);
}

static int FirstGo(){
    Random random = new Random();
    int num = random.Next(0, 100);
    if(num < 50){
        System.Console.WriteLine($"\nPlayer 1 will go first");
        return num;
    }else{
        System.Console.WriteLine($"\nPlayer 2 will go first");
        return num;
    }
}

static void Game(int num, Character p1, Character p2){
    while(p1.health > 0 & p2.health > 0){
        if(num < 50){
            p1.attackBehavior.Attack();
            Damage(num, p1, p2);
            num = 55;
        }else{
            p2.attackBehavior.Attack();
            Damage(num, p1, p2);
            num = 45;
        }

        p1.attackStrength = Character.GetAttackStrength(p1.maxPower);
        p2.attackStrength = Character.GetAttackStrength(p2.maxPower);
        p1.defensivePower = Character.GetDefensivePower(p1.maxPower);
        p2.defensivePower = Character.GetDefensivePower(p2.maxPower);
    }
    Winner(p1, p2);
}

static void Winner(Character p1, Character p2){
    if(p1.health > 0){
        System.Console.WriteLine($"\n{p1.name} has won with {p1.charName}!");
    }else{
        System.Console.WriteLine($"\n{p2.name} has won with {p2.charName}!");
    }
    System.Console.WriteLine($"Thank you for playing!");
}

static void Damage(int num, Character p1, Character p2){
    double typeBonus = 1;
    if(num < 50){
        if(p1.charName == "Jack Sparrow" && p2.charName == "Will Turner"){
            System.Console.WriteLine($"\n{p1.charName}'s attack gets a 20% bonus!");
            typeBonus = 1.2;
        }
        if(p1.charName == "Will Turner" && p2.charName == "Davy Jones"){
            System.Console.WriteLine($"\n{p1.charName}'s attack gets a 20% bonus!");
            typeBonus = 1.2;
        }
        if(p1.charName == "Davy Jones" && p2.charName == "Jack Sparrow"){
            System.Console.WriteLine($"\n{p1.charName}'s attack gets a 20% bonus!");
            typeBonus = 1.2;
        }
        System.Threading.Thread.Sleep(3000);
        double damageAmount = ((p1.attackStrength - p2.defensivePower)* typeBonus);
        if(damageAmount > 0){
            p2.health -= damageAmount;
            System.Console.WriteLine($"\n{p1.charName} dealt {p2.charName} {damageAmount} damage!");

        }else{
            System.Console.WriteLine($"\n{p2.charName} deflected the attack!");
        }
        System.Threading.Thread.Sleep(3000);
    }else{
        if(p2.charName == "Jack Sparrow" && p1.charName == "Will Turner"){
            System.Console.WriteLine($"\n{p2.charName}'s attack gets a 20% bonus!");
            typeBonus = 1.2;
        }
        if(p2.charName == "Will Turner" && p1.charName == "Davy Jones"){
            System.Console.WriteLine($"\n{p2.charName}'s attack gets a 20% bonus!");
            typeBonus = 1.2;
        }
        if(p2.charName == "Davy Jones" && p1.charName == "Jack Sparrow"){
            System.Console.WriteLine($"\n{p2.charName}'s attack gets a 20% bonus!");
            typeBonus = 1.2;
        }
        System.Threading.Thread.Sleep(3000);
        double damageAmount = ((p2.attackStrength - p1.defensivePower)* typeBonus);
        if(damageAmount > 0){
            p1.health -= damageAmount;
            System.Console.WriteLine($"\n{p2.charName} dealt {p1.charName} {damageAmount} damage!");

        }else{
            System.Console.WriteLine($"\n{p1.charName} deflected the attack!");
        }
        System.Threading.Thread.Sleep(3000);
    }
    ViewStats(p1, p2);
}