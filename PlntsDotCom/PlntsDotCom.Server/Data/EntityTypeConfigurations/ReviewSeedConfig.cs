using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlntsDotCom.Server.Data.EntityTypeConfigurations;

public class ReviewSeedConfig : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasData(
            new Review
            {
                Id = 1,
                OneStar = 0,
                TwoStar = 0,
                ThreeStar = 1,
                FourStar = 2,
                FiveStar = 7
            },
            new Review
            {
                Id = 2,
                OneStar = 0,
                TwoStar = 1,
                ThreeStar = 2,
                FourStar = 3,
                FiveStar = 4
            },
            new Review
            {
                Id = 3,
                OneStar = 0,
                TwoStar = 0,
                ThreeStar = 3,
                FourStar = 4,
                FiveStar = 3
            },
            new Review
            {
                Id = 4,
                OneStar = 1,
                TwoStar = 1,
                ThreeStar = 2,
                FourStar = 3,
                FiveStar = 3
            },
            new Review
            {
                Id = 5,
                OneStar = 0,
                TwoStar = 1,
                ThreeStar = 2,
                FourStar = 4,
                FiveStar = 3
            },
            new Review
            {
                Id = 6,
                OneStar = 0,
                TwoStar = 0,
                ThreeStar = 3,
                FourStar = 2,
                FiveStar = 5
            },
            new Review
            {
                Id = 7,
                OneStar = 0,
                TwoStar = 0,
                ThreeStar = 2,
                FourStar = 3,
                FiveStar = 5
            },
            new Review
            {
                Id = 8,
                OneStar = 1,
                TwoStar = 1,
                ThreeStar = 1,
                FourStar = 2,
                FiveStar = 5
            },
            new Review
            {
                Id = 9,
                OneStar = 0,
                TwoStar = 0,
                ThreeStar = 2,
                FourStar = 3,
                FiveStar = 5
            },
            new Review
            {
                Id = 10,
                OneStar = 0,
                TwoStar = 0,
                ThreeStar = 3,
                FourStar = 4,
                FiveStar = 3
            }
        );
    }
}
