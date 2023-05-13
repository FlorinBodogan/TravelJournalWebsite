namespace TravelJournalAPI.Server.IServices
{
    public interface IUserService
    {
        public Task<string> GetUsersStatusById(Guid id);

    }
}
