using NUnit.Framework;
using Problem1.Models;
using Problem1.Interfaces;
using Problem1.Services;


namespace Problem1.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        private IContactService _contactService;

        [SetUp]
        public void Setup()
        {
            _contactService = new ContactService();
        }

        [Test]
        public void AddContact_WhenContactIsAdded_ShouldExistInList()
        {
            // Arrange
            var contact = new Contact { Id = 1, Name = "Alice", Email = "alice@example.com" };

            // Act
            _contactService.AddContact(contact);

            // Assert
            var allContacts = _contactService.GetAllContacts();
            Assert.AreEqual(1, allContacts.Count);
        }

        [Test]
        public void GetAllContacts_AfterAddingContacts_ShouldNotBeEmpty()
        {
            // Arrange
            _contactService.AddContact(new Contact { Id = 1, Name = "Alice", Email = "alice@example.com" });
            _contactService.AddContact(new Contact { Id = 2, Name = "Bob", Email = "bob@example.com" });

            // Act
            var result = _contactService.GetAllContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetContactById_WhenIdExists_ShouldReturnCorrectContact()
        {
            // Arrange
            var contact = new Contact { Id = 5, Name = "Charlie", Email = "charlie@example.com" };
            _contactService.AddContact(contact);

            // Act
            var result = _contactService.GetContactById(5);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Id);
            Assert.AreEqual("Charlie", result.Name);
        }

        [Test]
        public void GetContactById_WhenIdDoesNotExist_ShouldReturnNull()
        {
            // Arrange — nothing added

            // Act
            var result = _contactService.GetContactById(999);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void DeleteContact_WhenContactExists_ShouldRemoveItFromList()
        {
            // Arrange
            _contactService.AddContact(new Contact { Id = 10, Name = "Diana", Email = "diana@example.com" });

            // Act
            bool wasDeleted = _contactService.DeleteContact(10);

            // Assert
            Assert.IsTrue(wasDeleted);
            Assert.IsNull(_contactService.GetContactById(10));
        }

        [Test]
        public void DeleteContact_WhenContactDoesNotExist_ShouldReturnFalse()
        {
            // Arrange — nothing added

            // Act
            bool wasDeleted = _contactService.DeleteContact(999);

            // Assert
            Assert.IsFalse(wasDeleted);
        }
    }
}