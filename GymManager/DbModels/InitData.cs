using System;
using System.Collections.Generic;
using System.Linq;
using GymManager.Common;
using GymManager.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DbModels
{
    public static class InitData
    {
        public static void Init(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    UserName = "admin",
                    Password = "21232f297a57a5a743894a0e4a801fc3",
                    FirstName = "Administrator",
                    LastName = "systemu",
                    DateAdded = DateTime.Now,
                    IsAcive = true,
                    IsAdmin = true
                });

            modelBuilder.Entity<DataTrackingOperation>().HasData(
                new DataTrackingOperation
                {
                    DataTrackingOperationID = 1,
                    Name = "DODAWANIE"
                },
                new DataTrackingOperation
                {
                    DataTrackingOperationID = 2,
                    Name = "EDYTOWANIE"
                },
                new DataTrackingOperation
                {
                    DataTrackingOperationID = 3,
                    Name = "USUWANIE"
                });

            modelBuilder.Entity<Tax>().HasData(
                new Tax
                {
                    TaxID = 1,
                    Name = "A",
                    IsAcive = true,
                    Rate = 23,
                    DateAdded = DateTime.Now
                },
                new Tax
                {
                    TaxID = 2,
                    Name = "B",
                    IsAcive = true,
                    Rate = 8,
                    DateAdded = DateTime.Now
                },
                new Tax
                {
                    TaxID = 3,
                    Name = "C",
                    IsAcive = true,
                    Rate = 5,
                    DateAdded = DateTime.Now
                },
                new Tax
                {
                    TaxID = 4,
                    Name = "D",
                    IsAcive = true,
                    Rate = 0,
                    DateAdded = DateTime.Now
                });

            modelBuilder.Entity<PassTime>().HasData(
                new PassTime
                {
                    PassTimeID = 1,
                    Name = "Dzień"
                },
                new PassTime
                {
                    PassTimeID = 2,
                    Name = "Tydzień"
                },
                new PassTime
                {
                    PassTimeID = 3,
                    Name = "Miesiąć"
                },
                new PassTime
                {
                    PassTimeID = 4,
                    Name = "Rok"
                },
                new PassTime
                {
                    PassTimeID = 5,
                    Name = "Nieskonczony"
                },
                new PassTime
                {
                    PassTimeID = 99,
                    Name = "Zdefiniowanych dni"
                }
            );

            modelBuilder.Entity<Pass>().HasData(
                new Pass
                {
                    PassID = 1,
                    Name = "BRAK",
                    Description = "",
                    EntryNetPrice = 0M,
                    EntryPrice = 0M,
                    NetPrice = 0M,
                    Price = 0M,
                    PassTimeID = 5,
                    TaxID = 4,
                    Continuation = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1,
                    IsAcive = true
                },
                new Pass
                {
                    PassID = 2,
                    Name = "OPEN",
                    Description = "Wstpęp wolny na miesiąc",
                    EntryNetPrice = 20.00M,
                    EntryPrice = 18.52M,
                    NetPrice = 100.93M,
                    Price = 109.00M,
                    PassTimeID = 3,
                    TaxID = 2,
                    Continuation = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1,
                    IsAcive = true
                },
                new Pass
                {
                    PassID = 3,
                    Name = "OPEN PORANNY",
                    Description = "Wstpęp wolny w godz. 9-14 na miesiąc",
                    EntryNetPrice = 20.00M,
                    EntryPrice = 18.52M,
                    NetPrice = 73.15M,
                    Price = 79.00M,
                    PassTimeID = 3,
                    TaxID = 2,
                    AccessTimeFrom = new DateTime(2000, 1, 1, 9, 0, 0),
                    AccessTimeTo = new DateTime(2000, 1, 1, 14, 0, 0),
                    Continuation = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1,
                    IsAcive = true
                },
                new Pass
                {
                    PassID = 4,
                    Name = "STUDENT",
                    Description = "Wstpęp wolny dla studentów",
                    EntryNetPrice = 0M,
                    EntryPrice = 0M,
                    NetPrice = 91.67M,
                    Price = 99.00M,
                    PassTimeID = 3,
                    TaxID = 2,
                    Continuation = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1,
                    IsAcive = true
                },
                new Pass
                {
                    PassID = 5,
                    Name = "PROMOCJA LUTY2022",
                    Description = "Wstpęp wolny na miesiąc",
                    EntryNetPrice = 0M,
                    EntryPrice = 0M,
                    NetPrice = 91.67M,
                    Price = 99.00M,
                    PassTimeID = 3,
                    TaxID = 2,
                    Continuation = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1,
                    IsAcive = true
                },
                new Pass
                {
                    PassID = 6,
                    Name = "JEDNORAZOWY",
                    Description = "Wstpęp jednorazowy",
                    EntryNetPrice = 0M,
                    EntryPrice = 0M,
                    NetPrice = 18.52M,
                    Price = 20.00M,
                    PassTimeID = 3,
                    TaxID = 2,
                    Continuation = true,
                    DateAdded = DateTime.Now,
                    AddedBy = 1,
                    IsAcive = true
                });

            modelBuilder.Entity<MediaCarrier>().HasData(
                new MediaCarrier
                {
                    MediaCarrierID = 1,
                    Name = "KARTA RFID",
                    IsAcive = true
                });

            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    GenderID = 1,
                    Name = "NIE PODANO"
                },
                new Gender
                {
                    GenderID = 2,
                    Name = "MĘŻCZYZNA"
                },
                new Gender
                {
                    GenderID = 3,
                    Name = "KOBIETA"
                });

            modelBuilder.Entity<PermissionList>().HasData(GetPermissionLists());
        }

        private static PermissionList[] GetPermissionLists()
        {
            List<PermissionList> list = new();

            foreach(var p in (Permissions[])Enum.GetValues(typeof(Permissions)))
            {
                list.Add(new PermissionList { PermissionListID = (int)p, Name = p.GetDisplayName() });
            }

            return list.OrderBy(p => p.PermissionListID).ToArray();
        }
    }
}