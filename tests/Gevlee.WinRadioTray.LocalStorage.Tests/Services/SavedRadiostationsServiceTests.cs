using System.IO;
using Gevlee.WinRadioTray.LocalStorage.Contract;
using Gevlee.WinRadioTray.LocalStorage.Contract.Serialization;
using Gevlee.WinRadioTray.LocalStorage.Services;
using Moq;
using Xunit;

namespace Gevlee.WinRadioTray.LocalStorage.Tests.Services
{
	public class SavedRadiostationsServiceTests
	{
		private const string Filename = "test.xml";

		private Mock<ISerializer<SavedRadiostations>> serializationMock;

		public SavedRadiostationsServiceTests()
		{
			serializationMock = new Mock<ISerializer<SavedRadiostations>>();
		}

		[Fact]
		public void Should_Create_File_In_Get_Method()
		{
			var service = new SavedRadiostationsService(Filename, serializationMock.Object);
			service.Get();
			Assert.True(File.Exists(Filename));
		}

		[Fact]
		public void Should_Create_File_In_Save_Method()
		{
			var service = new SavedRadiostationsService(Filename, serializationMock.Object);
			service.Save(new SavedRadiostations());
			Assert.True(File.Exists(Filename));
		}

		~SavedRadiostationsServiceTests()
		{
			if (File.Exists(Filename))
			{
				File.Delete(Filename);
			}
		}
	}
}