using System.Threading.Tasks;

namespace TestableSignalrApp {
    public interface IClient {
        Task Message(string msg);
        Task PrivateMessage(Message msg);
    }
}