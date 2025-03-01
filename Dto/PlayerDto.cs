namespace Blazor.Dto
{
  public class PlayersDto
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Slug { get; set; }
    public string Posicion { get; set; }
    public DateTime Fecha { get; set; }
    public int EquipoId { get; set; }
    public virtual TeamDto Equipo { get; set; }
  }
}