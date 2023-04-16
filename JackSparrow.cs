namespace mis321_pa4_njvirgin
{
    public class JackSparrow : Character
    {
        public JackSparrow(){
            attackBehavior = new DistractOpponent();
        }
    }
}