using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;
using UserDemo.Xamarin.Persistence;
using UserDemo.Xamarin.ViewModels;

namespace UserDemo.Test1
{
    [TestFixture]
    public class UserViewModelTest
    {
        // TODO: The unit testing project is on Progress

        private UserViewModel _viewModel;
        private Mock<IUserRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IUserRepository>();
            _viewModel = new UserViewModel(_repository.Object);

            var usersList = new List<User>() {
                new User(){ Id =1,UserCode = 1,FirstName = "Luis",LastName ="Nores",AvatarUrl="" },
                new User(){ Id =1,UserCode = 1,FirstName = "Pierina",LastName ="Reategui",AvatarUrl="" },
                new User(){ Id =1,UserCode = 1,FirstName = "Daniel",LastName ="Farfan",AvatarUrl="" },
                new User(){ Id =1,UserCode = 1,FirstName = "Kattia",LastName ="Mendoza",AvatarUrl="" },
            };

            _repository.Setup(u => u.GetUsersList()).ReturnsAsync(usersList);

        }

        [Test]
        public async Task Initialize_WhenCalled_TheViewModelShouldBeShowTheListofUsers()
        {
            await _viewModel.Initialize();
            var userList = _viewModel.UsersList;

            Assert.AreEqual(4, userList.Count);
            Assert.AreSame("Luis", userList[0].FirstName);
        }
    }
}
