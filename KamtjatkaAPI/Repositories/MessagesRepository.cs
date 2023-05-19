using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
    public class MessagesRepository : RepositoryBase<Messages>, IMessagesRepository
    {
        public MessagesRepository(vujeeaxiContext repositoryContext)
          : base(repositoryContext)
        {

        }
    }
}
