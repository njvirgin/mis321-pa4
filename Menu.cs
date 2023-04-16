namespace mis321_pa4_njvirgin
{
    public class Menu
    {
        public int GetCharacter(){
            System.Console.WriteLine($"\nPlease select which character you would like to use. \n1. Jack Sparrow \n2. Will Turner \n3. Davy Jones");
            int charChoice = int.Parse(Console.ReadLine());
            while(charChoice < 1 || charChoice > 3){
                System.Console.WriteLine($"\nInvalid choice, Please select which character you would like to use. \n1. Jack Sparrow \n2. Will Turner \n3. Davy Jones");
                charChoice = int.Parse(Console.ReadLine());
            }
            return charChoice;
        }
    }
}