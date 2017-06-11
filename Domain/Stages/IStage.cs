namespace NotificatorApp.Domain.Stages
{
    public interface IStage
    {
        ServiceMessage RunStage();
    }
}