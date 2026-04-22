using Moq;
using System;
using NUnit.Framework;
using Problem2.Models;
using Problem2.Repositories;
using Problem2.Interfaces;
using Problem2.Services;

namespace Problem2.Tests
{
    [TestFixture]
    public class Problem2Tests
    {
        // Mock object — a FAKE repository controlled by us
        private Mock<IContactRepository> _mockRepository;

        // The real service — but fed with fake repository
        private IContactService _contactService;

        [SetUp]
        public void Setup()
        {
            // Create the fake repository using Moq
            _mockRepository = new Mock<IContactRepository>();

            // Inject the fake repository into the real service
            // This is Constructor Injection in action
            _contactService = new ContactService(_mockRepository.Object);
        }

        // ─────────────────────────────────────────────────────
        // TEST 1: AddContact — verify repository.Add() was called
        // ─────────────────────────────────────────────────────
        [Test]
        public void AddContact_WhenValidContact_ShouldCallRepositoryAdd()
        {
            // Arrange
            var contact = new Contact { Id = 1, Name = "Alice", Email = "alice@example.com" };

            // Act
            _contactService.AddContact(contact);

            // Assert — Verify that Add() was called exactly once on mock
            // This tests BEHAVIOR, not data
            _mockRepository.Verify(r => r.Add(contact), Times.Once);
        }

        // ─────────────────────────────────────────────────────
        // TEST 2: GetContacts — verify data is returned from repo
        // ─────────────────────────────────────────────────────
        [Test]
        public void GetContacts_WhenCalled_ShouldReturnContactsFromRepository()
        {
            // Arrange — tell the mock WHAT to return when GetAll() is called
            var fakeContacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new Contact { Id = 2, Name = "Bob",   Email = "bob@example.com" }
            };

            // Setup() tells Moq: "when GetAll() is called, return fakeContacts"
            _mockRepository.Setup(r => r.GetAll()).Returns(fakeContacts);

            // Act
            var result = _contactService.GetContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        // ─────────────────────────────────────────────────────
        // TEST 3: RemoveContact — verify returns true on success
        // ─────────────────────────────────────────────────────
        [Test]
        public void RemoveContact_WhenContactExists_ShouldReturnTrue()
        {
            // Arrange — tell mock to return true when Remove(1) is called
            _mockRepository.Setup(r => r.Remove(1)).Returns(true);

            // Act
            bool result = _contactService.RemoveContact(1);

            // Assert
            Assert.IsTrue(result);

            // Also verify Remove() was actually called once
            _mockRepository.Verify(r => r.Remove(1), Times.Once);
        }

        // ─────────────────────────────────────────────────────
        // TEST 4: AddContact — throws exception for empty name
        // ─────────────────────────────────────────────────────
        [Test]
        public void AddContact_WhenNameIsEmpty_ShouldThrowArgumentException()
        {
            // Arrange — contact with empty name (invalid data)
            var invalidContact = new Contact { Id = 2, Name = "", Email = "test@example.com" };

            // Act + Assert — verify exception is thrown
            // Assert.Throws checks that the exact exception type is thrown
            Assert.Throws<ArgumentException>(() => _contactService.AddContact(invalidContact));

            // Also verify repository.Add() was NEVER called
            // Because exception should stop execution before reaching repository
            _mockRepository.Verify(r => r.Add(It.IsAny<Contact>()), Times.Never);
        }
    }
}
