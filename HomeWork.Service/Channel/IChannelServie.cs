namespace HomeWork.Service.Channel
{
    public interface IChannelServie
    {
        void Subscribe();
        void Publish(Entities.Entities.MessageType message,long customerId,int Score);
        void Publish(Entities.Entities.MessageType message);
    }
}