namespace BrawlToonsAPI.Models
{
    public class Player
    {
        public int player_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int games_played { get; set; } = 0;
        public int total_wins { get; set; } = 0;
        public int total_losses { get; set; } = 0;

        public Player(string username,string pasword) {
            this.username = username; 
            this.password = pasword; 
            this.games_played = 0;
            this.total_wins = 0;
            this.total_losses = 0;
        }
    }
}
