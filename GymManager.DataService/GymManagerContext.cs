﻿using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.DataModel.Models;
using GymManager.DataService.Common;
using GymManager.DataService.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymManager.DataService
{
    public class GymManagerContext : DbContext
    {
        public static DatabaseTypes DefaultDatabaseType { get; set; }
        private readonly DatabaseTypes _databaseType;
        private static string _connectionString;

        public DbSet<CabinetKey> CabinetKeys { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DataTrackingDefinition> DataTrackingDefinitions { get; set; }
        public DbSet<DataTrackingOperation> DataTrackingOperations { get; set; }
        public DbSet<DataTracking> DataTrackings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EntryRegistry> EntriesRegistry { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GymObject> GymObjects { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }
        public DbSet<MediaCarrier> MediaCarriers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRegistry> MessagesRegistry { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<Pass> Passes { get; set; }
        public DbSet<PassRegistry> PassesRegistry { get; set; }
        public DbSet<PassTime> PassTimes { get; set; }
        public DbSet<PermissionList> PermissionsList { get; set; }
        public DbSet<PermissionUser> PermissionsUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<User> Users { get; set; }

        public GymManagerContext()
        {
            _databaseType = DefaultDatabaseType;
        }

        public GymManagerContext(DatabaseTypes databaseType)
        {
            _databaseType = databaseType;
        }

        public GymManagerContext(DatabaseTypes databaseType,string connectionString)
        {
            _databaseType = databaseType;
            _connectionString = connectionString;
        }
        
        public virtual void Migrate()
        {
            Database.Migrate();
        }

        public void SaveChanges<T>() where T : class
        {
            var tr = new TrackingDatabase();

            Tracking(tr, base.ChangeTracker.Entries<T>());

            base.SaveChanges();

            tr.Save();
        }

        public void SaveChanges<T1, T2>() where T1 : class where T2 : class
        {
            var tr = new TrackingDatabase();

            Tracking(tr, base.ChangeTracker.Entries<T1>());
            Tracking(tr, base.ChangeTracker.Entries<T2>());

            base.SaveChanges();

            tr.Save();
        }

        public void SaveChanges<T1, T2, T3>() where T1 : class where T2 : class where T3 : class
        {
            var tr = new TrackingDatabase();

            Tracking(tr, base.ChangeTracker.Entries<T1>());
            Tracking(tr, base.ChangeTracker.Entries<T2>());
            Tracking(tr, base.ChangeTracker.Entries<T3>());

            base.SaveChanges();

            tr.Save();
        }

        public void SaveChanges<T1, T2, T3, T4>() where T1 : class where T2 : class where T3 : class where T4 : class
        {
            var tr = new TrackingDatabase();

            Tracking(tr, base.ChangeTracker.Entries<T1>());
            Tracking(tr, base.ChangeTracker.Entries<T2>());
            Tracking(tr, base.ChangeTracker.Entries<T3>());
            Tracking(tr, base.ChangeTracker.Entries<T4>());

            base.SaveChanges();

            tr.Save();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = _databaseType switch
            {
                DatabaseTypes.Memory => optionsBuilder.UseInMemoryDatabase(_connectionString),
                DatabaseTypes.SqlServer => optionsBuilder.UseSqlServer(_connectionString),
                DatabaseTypes.Sqlite => optionsBuilder.UseSqlite(_connectionString),
                DatabaseTypes.PostgreSql => optionsBuilder.UseNpgsql(_connectionString),
                DatabaseTypes.MySql => optionsBuilder.UseMySql(_connectionString,
                    new MySqlServerVersion(new Version(10, 4, 17))),
                _ => throw new NotImplementedException()
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitData.Init(modelBuilder);

            modelBuilder.Entity<Member>()
                .Property(t => t.NoPeselNumber)
                .HasDefaultValue(false);
        }

        private TrackingDatabase Tracking<T>(TrackingDatabase tracker, IEnumerable<EntityEntry<T>> entityEntry)
            where T : class
        {
            if (entityEntry is null)
            {
                throw new ArgumentNullException(nameof(entityEntry));
            }

            var entities = from t in base.ChangeTracker.Entries<T>()
                           select t;

            foreach (var entity in entities)
            {
                var trackerOperations = TransalteStatus(entity.State);

                if (trackerOperations.HasValue && trackerOperations.Value != TrackerOperations.Add)
                {
                    tracker.TrackerFromDatabase<T>(entity.CurrentValues, trackerOperations.Value);
                }
            }

            return tracker;
        }

        private TrackerOperations? TransalteStatus(EntityState entityState)
        {
            return entityState switch
            {
                EntityState.Added => TrackerOperations.Add,
                EntityState.Modified => TrackerOperations.Edit,
                EntityState.Deleted => TrackerOperations.Delete,
                EntityState.Detached => null,
                EntityState.Unchanged => null,
                _ => null
            };
        }
    }
}