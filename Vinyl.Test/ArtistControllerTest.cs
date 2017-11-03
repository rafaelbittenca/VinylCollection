using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Vinyl.DAL.Contract;
using Vinyl.Models;
using Vinyl.UI.Controllers;

namespace Vinyl.Test
{
	[TestClass]
	public class ArtistControllerTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var artists = new List<Artist>();
			artists.Add(new Artist {
				ID=1,
				Name="John NoName"
			});
			Mock<IUnitOfWork> mockRepo = new Mock<IUnitOfWork>();
			mockRepo.Setup(x => x.Artists.GetAll()).Returns(artists);
			var artistController = new ArtistController(mockRepo.Object);

			//Act
			artistController.TestJsonPostmanReturn();

			//Assert
			artistController.Should().NotBeNull();

		}
	}
}
