using System.Windows.Input;
using Bogus;
using PropertyChanged;
using TruthOrDrinkApp.MVVM.Models;

namespace TruthOrDrinkApp.MVVM.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public class MainPageViewModel
	{
		public List<User>? Users { get; set; }
		public User? CurrentUser { get; set; }
		public ICommand? AddOrUpdateCommand { get; set; }
		public ICommand? DeleteCommand { get; set; }


		public MainPageViewModel() 
		{
			Refresh();
			GenerateNewUser();
			AddOrUpdateCommand = new Command(async () =>
			{
				App.UserRepo.AddOrUpdate(CurrentUser);
				Console.WriteLine(App.UserRepo.statusMessage);
				GenerateNewUser();
				Refresh();
			});

			DeleteCommand = new Command(() =>
			{
				App.UserRepo.Delete(CurrentUser.Id);
				Refresh();
				GenerateNewUser();
			});

		}

		private void GenerateNewUser()
		{
			CurrentUser = new Faker<User>()
				.RuleFor(x => x.Name, f => f.Person.FullName)
				.RuleFor(x => x.Email, f => f.Person.Email)
				.Generate();
		}

		private void Refresh()
		{
			Users = App.UserRepo.GetAll();
		}
	}
}
