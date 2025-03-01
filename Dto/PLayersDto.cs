namespace Blazor.Dto
{
  public class PlayersDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Position { get; set; }
    public DateTime Date { get; set; }
    public int TeamId { get; set; }
    public virtual TeamDto Team { get; set; }
  }
}