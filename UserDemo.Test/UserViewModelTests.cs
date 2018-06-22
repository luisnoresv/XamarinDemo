using Moq;
using NUnit.Framework;
using System;
using UserDemo.Xamarin.Persistence;
using UserDemo.Xamarin.Services;
using UserDemo.Xamarin.ViewModels;

namespace UserDemo.Test
{
    [TestFixture]
    public class UserViewModelTests
    {
        private UserViewModel _viewModel;
        private Mock<IUserRepository> _repository;
        private UserService _service;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IUserRepository>();
            _viewModel = new UserViewModel(_repository.Object);
        }

        [Test]
        public void Initialize_WhenCalled_TheModelShouldBeShowTheListofUsers()
        {
            var repository = _repository.Object.GetUsersList();
            
        }


    }
}
