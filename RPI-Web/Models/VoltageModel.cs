namespace RPI_Web.Models;

public class VoltageModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public DateTime CreateAt { get; set; }

    public VoltageModel()
    {
        Name = $"#{Id}";
        CreateAt = DateTime.Now;
    }
}