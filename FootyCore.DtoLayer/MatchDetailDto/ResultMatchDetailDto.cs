namespace FootyCore.DtoLayer.MatchDetailDto
{
    public class ResultMatchDetailDto
    {
        public int MatchDetailId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public int Minute { get; set; }
    }
}
