using EF_Core_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core_Demo.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure( EntityTypeBuilder<Player> builder )
        {
            builder.HasOne( p => p.Team )
                .WithMany( t => t.Players )
                .HasForeignKey( p => p.TeamId )
                .HasConstraintName( "FK_TeamId" )
                .OnDelete( DeleteBehavior.Cascade );

            builder.Property( p => p.Id )
                .HasColumnName( "PlayerId" );

            builder.Property( p => p.FirstName )
                    .IsRequired()
                    .HasMaxLength( 30 );

            builder.Property( p => p.LastName )
                .IsRequired()
                .HasMaxLength( 30 );

            builder.Property( p => p.Age )
                .IsRequired();
        }
    }
}
