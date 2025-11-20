namespace ZullaWpfDomain.Commands;

public class UpdateDanceClassCommand
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string DanceStyle { get; set; } = string.Empty;
    public string Instructor { get; set; } = string.Empty;
    public string Schedule { get; set; } = string.Empty;
}
