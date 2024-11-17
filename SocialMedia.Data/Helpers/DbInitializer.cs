using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Helpers
{
	public static class DbInitializer
	{
		public static async Task SeedAsync(AppDbContext appDbContext) 
		{
			if (!appDbContext.Users.Any() && !appDbContext.Posts.Any())
			{
				var newUser = new User()
				{
					FullName = "Saleh Sam",
					ProfilePictureUrl = "https://i.pinimg.com/474x/5b/04/d5/5b04d52580685414327e1774a80619f7.jpg"
				};
				await appDbContext.Users.AddAsync(newUser);
				await appDbContext.SaveChangesAsync();

				var newPostWotoutImage = new Post()
				{
					Content = "Test Post For init Test Post For initTest Post For initTest Post For initTest Post For init Test Post For initTest Post For initTest Post For initTest Post For initTest Post For init.",
				    ImageUrl = "",
					NrOfReports = 0,
					DateCreated = DateTime.UtcNow,
					DateUpdated = DateTime.UtcNow,

					UserId = newUser.Id
				};

				var newPostWithImage = new Post()
				{
					Content = "Test Post For init with image Test Post For initTest Post For initTest Post For initTest Post For init Test Post For initTest Post For initTest Post For initTest Post For initTest Post For init.",
					ImageUrl = "https://cmsassets.rgpub.io/sanity/images/dsfx7636/news/06ca5ccb8363f4e2275f67299067938f8580d875-5070x2149.jpg",
					NrOfReports = 0,
					DateCreated = DateTime.UtcNow,
					DateUpdated = DateTime.UtcNow,

					UserId = newUser.Id
				};

				await appDbContext.Posts.AddRangeAsync(newPostWotoutImage , newPostWithImage );
				await appDbContext.SaveChangesAsync();
			}
		}
	}
}
