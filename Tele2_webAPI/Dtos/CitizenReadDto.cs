namespace Tele2_webAPI.Dtos
{
    public class CitizenReadDto
    {
        public int Index { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; } = 0;
    }
}
