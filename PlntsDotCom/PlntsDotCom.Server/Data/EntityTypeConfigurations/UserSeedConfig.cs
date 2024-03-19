using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class UserSeedConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = 1,
                Username = "user1",
                Email = "user1@example.com",
                Password = "password1",
                Type = UserType.LoggedInUser,
                Address = "123 Main St, City, Country"
            },
            new User
            {
                Id = 2,
                Username = "user2",
                Email = "user2@example.com",
                Password = "password2",
                Type = UserType.LoggedInUser,
                Address = "456 Elm St, City, Country"
            }
        );
    }
}
