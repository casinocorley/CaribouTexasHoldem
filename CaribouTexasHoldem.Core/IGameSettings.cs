namespace CaribouTexasHoldem.Core
{
    public interface IGameSettings
    {
        int NumOfSeats { get; set; }
        int BigBlind { get; set; }
        int LittleBlind { get; }
        int MaxBuyIn { get; set; }
        int MinBuyIn { get; set; }
    }
}