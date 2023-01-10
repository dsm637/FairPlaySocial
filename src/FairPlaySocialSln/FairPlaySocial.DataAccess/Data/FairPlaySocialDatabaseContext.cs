﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using FairPlaySocial.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FairPlaySocial.DataAccess.Data;

public partial class FairPlaySocialDatabaseContext : DbContext
{
    public FairPlaySocialDatabaseContext(DbContextOptions<FairPlaySocialDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationRole> ApplicationRole { get; set; }

    public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

    public virtual DbSet<ApplicationUserFollow> ApplicationUserFollow { get; set; }

    public virtual DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

    public virtual DbSet<ClientSideErrorLog> ClientSideErrorLog { get; set; }

    public virtual DbSet<Culture> Culture { get; set; }

    public virtual DbSet<DislikedPost> DislikedPost { get; set; }

    public virtual DbSet<ErrorLog> ErrorLog { get; set; }

    public virtual DbSet<ForbiddenUrl> ForbiddenUrl { get; set; }

    public virtual DbSet<Group> Group { get; set; }

    public virtual DbSet<GroupMember> GroupMember { get; set; }

    public virtual DbSet<GroupModerator> GroupModerator { get; set; }

    public virtual DbSet<LikedPost> LikedPost { get; set; }

    public virtual DbSet<Photo> Photo { get; set; }

    public virtual DbSet<Post> Post { get; set; }

    public virtual DbSet<PostKeyPhrase> PostKeyPhrase { get; set; }

    public virtual DbSet<PostReach> PostReach { get; set; }

    public virtual DbSet<PostTag> PostTag { get; set; }

    public virtual DbSet<PostType> PostType { get; set; }

    public virtual DbSet<PostUrl> PostUrl { get; set; }

    public virtual DbSet<PostVisibility> PostVisibility { get; set; }

    public virtual DbSet<Resource> Resource { get; set; }

    public virtual DbSet<UserPreference> UserPreference { get; set; }

    public virtual DbSet<UserProfile> UserProfile { get; set; }

    public virtual DbSet<VisitorTracking> VisitorTracking { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=FairPlaySocial.Database;Integrated Security=true");

        modelBuilder.Entity<ApplicationRole>(entity =>
        {
            entity.HasKey(e => e.ApplicationRoleId).HasName("PK_Application");
        });

        modelBuilder.Entity<ApplicationUserFollow>(entity =>
        {
            entity.HasOne(d => d.FollowedApplicationUser).WithMany(p => p.ApplicationUserFollowFollowedApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUserFollow_FollowedApplicationUser");

            entity.HasOne(d => d.FollowerApplicationUser).WithMany(p => p.ApplicationUserFollowFollowerApplicationUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUserFollow_FollowerApplicationUser");
        });

        modelBuilder.Entity<ApplicationUserRole>(entity =>
        {
            entity.HasOne(d => d.ApplicationRole).WithMany(p => p.ApplicationUserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUserRole_ApplicationRole");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.ApplicationUserRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApplicationUserRole_ApplicationUser");
        });

        modelBuilder.Entity<DislikedPost>(entity =>
        {
            entity.HasOne(d => d.DislikingApplicationUser).WithMany(p => p.DislikedPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DislikedPost_ApplicationUser");

            entity.HasOne(d => d.Post).WithMany(p => p.DislikedPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DislikedPost_Post");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasOne(d => d.OwnerApplicationUser).WithMany(p => p.Group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_ApplicationUser");
        });

        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasOne(d => d.Group).WithMany(p => p.GroupMember)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupMember_Group");

            entity.HasOne(d => d.MemberApplicationUser).WithMany(p => p.GroupMember)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupMember_ApplicationUser");
        });

        modelBuilder.Entity<GroupModerator>(entity =>
        {
            entity.HasOne(d => d.Group).WithMany(p => p.GroupModerator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupModerator_Group");

            entity.HasOne(d => d.ModeratorApplicationUser).WithMany(p => p.GroupModerator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupModerator_ApplicationUser");
        });

        modelBuilder.Entity<LikedPost>(entity =>
        {
            entity.HasOne(d => d.LikingApplicationUser).WithMany(p => p.LikedPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LikedPost_ApplicationUser");

            entity.HasOne(d => d.Post).WithMany(p => p.LikedPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LikedPost_Post");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.Property(e => e.PostTypeId).HasDefaultValueSql("1");
            entity.Property(e => e.PostVisibilityId).HasDefaultValueSql("1");

            entity.HasOne(d => d.CreatedFromPost).WithMany(p => p.InverseCreatedFromPost).HasConstraintName("FK_Post_Post");

            entity.HasOne(d => d.Group).WithMany(p => p.Post).HasConstraintName("FK_Post_Group");

            entity.HasOne(d => d.OwnerApplicationUser).WithMany(p => p.Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_ApplicationUser");

            entity.HasOne(d => d.Photo).WithMany(p => p.Post).HasConstraintName("FK_Post_Photo");

            entity.HasOne(d => d.PostType).WithMany(p => p.Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_PostType");

            entity.HasOne(d => d.PostVisibility).WithMany(p => p.Post)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_PostVisibility");

            entity.HasOne(d => d.RootPost).WithMany(p => p.InverseRootPost).HasConstraintName("FK_Post_Post_RootPost");
        });

        modelBuilder.Entity<PostKeyPhrase>(entity =>
        {
            entity.HasOne(d => d.Post).WithMany(p => p.PostKeyPhrase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostKeyPhrase_Post");
        });

        modelBuilder.Entity<PostReach>(entity =>
        {
            entity.HasOne(d => d.Post).WithMany(p => p.PostReach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostReach_Post");

            entity.HasOne(d => d.ReachedByApplicationUser).WithMany(p => p.PostReach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostReach_ApplicationUser");
        });

        modelBuilder.Entity<PostTag>(entity =>
        {
            entity.HasOne(d => d.Post).WithMany(p => p.PostTag)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostTag_Post");
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.Property(e => e.PostTypeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PostUrl>(entity =>
        {
            entity.HasOne(d => d.Post).WithMany(p => p.PostUrl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostUrl_Post");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasOne(d => d.Culture).WithMany(p => p.Resource)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resource_Culture");
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.HasOne(d => d.ApplicationUser).WithOne(p => p.UserPreference)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPreference_ApplicationUser");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasOne(d => d.ApplicationUser).WithOne(p => p.UserProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserProfile_ApplicationUser");
        });

        modelBuilder.Entity<VisitorTracking>(entity =>
        {
            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.VisitorTracking).HasConstraintName("FK_VisitorTracking_ApplicationUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}