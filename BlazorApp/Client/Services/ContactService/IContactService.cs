

namespace BlazorApp.Client.Services.ContactService
{
    public interface IContactService
    {
        List<Contact> Contacts { get; set; }
        List<Category> Categories { get; set; }
        List<SubCategory> SubCategories{ get; set; }

        Task GetContacts();
        Task GetCategories();
        Task GetSubCategories();
        Task<Contact> GetSingleContact(int id);
        Task CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int id);

    }
}
