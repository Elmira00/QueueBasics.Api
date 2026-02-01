namespace QueueBasics.Api.Services
{
    public interface IQueueService//bu FIFO mentiqi ile ishleyecek 
    {
        Task SendMessageAsync(string message);//burda eslinde queue'nin spesifik adini da vere bilerdik 
        //ki, bilsin ki hansi queue'den oxuyur 
        //cunki queue storage'in icinde bir nece queue ola biler.
        Task<string> ReceiveMessageAsync();
    }
}
