using AspNetCore3WebApi.Service;

namespace AspNetCore3WebApi.Data.Entities
{
  public class Talk
  {
    public string Abstract { get; set; }
    public Camp Camp { get; set; }
    public int Level { get; set; }
    public Speaker Speaker { get; set; }
    public string TalkId { get; set; }
    public string Title { get; set; }
  }
}