namespace mis321_pa4_njvirgin
{
    public class Character
    {
        public string name {get; set;}
        public string charName {get; set;}
        public int maxPower {get; set;}
        public double health {get; set;}
        public int attackStrength {get; set;}
        public int defensivePower {get; set;}

        public IAttack attackBehavior {get; set;}

        public Character(){

        }
        public static int GetMaxPower(){
            Random random = new Random();
            int randomMaxPower = random.Next(1,100);
            return randomMaxPower;
        }

        public static int GetAttackStrength(int maxPower){
            Random random = new Random();
            int randomAttackStrength = random.Next(1, maxPower);
            return randomAttackStrength;
        }

        public static int GetDefensivePower(int maxPower){
            Random random = new Random();
            int randomDefensivePower = random.Next(1, maxPower);
            return randomDefensivePower;
        }
    }
}