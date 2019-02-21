

public static class GameStats 
{
    private static int tank1wins, tank2wins;
    public static int Tank1Wins
    {
        get 
        {
            return tank1wins;
        }
        set
        {
            tank1wins =  value;
        }
    }
    public static int Tank2Wins
    {
        get
        {
            return tank2wins;
        }
        set
        {
            tank2wins = value;
        }
    }
}
