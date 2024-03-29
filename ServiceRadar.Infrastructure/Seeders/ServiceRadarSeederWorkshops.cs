﻿using Microsoft.EntityFrameworkCore;

using ServiceRadar.Infrastructure.Data;
using ServiceRadar.Infrastructure.Seeders.Models;

namespace ServiceRadar.Infrastructure.Seeders;

public static class ServiceRadarSeederWorkshops
{
    private static readonly List<WorkshopSeedData> _workshopSeedDataList = new()
    {
        new WorkshopSeedData
        {
            Name = "Mazda Service Senter",
            Description = "Authorized Mazda service",
            About = "Warranty and post-warranty service. Full service.",
            ContactDetails = new()
            {
                City = "Sandefjord",
                Street = "Gjekstadveien 2",
                PostalCode = "3218",
                PhoneNumber = "+47 33 45 43 00"
            },
            UserName = "user@test.com"
        },
        new WorkshopSeedData
        {
            Name = "Ford Transit Senter",
            Description = "Authorized Ford center",
            About = "Full service.",
            ContactDetails = new()
            {
                City = "Sandefjord",
                Street = "Nygårdsveien 79",
                PostalCode = "3221",
                PhoneNumber = "+47 815 20 500"
            },
            UserName = "user2@test.com"
        },
        new WorkshopSeedData
        {
            Name = "Tesla Senter",
            Description = "Authorized Tesla center",
            About = "Specializing in commercial and heavy-duty vehicles. Ongoing repairs for passenger cars.",
            ContactDetails = new()
            {
                City = "Sandefjord",
                Street = "Fokserødveien 23",
                PostalCode = "3241",
                PhoneNumber = "+47 23 96 02 85"
            },
            UserName = "user@test.com"
        },
    };

    public static async Task Initialize(ServiceRadarDbContext dbContext)
    {
        foreach(var workshop in _workshopSeedDataList)
        {
            workshop.EncodeName();
            workshop.CreateById = await GetUserId(dbContext, workshop.UserName);
            await dbContext.Workshops.AddAsync(workshop);
        }
    }

    private static async Task<string> GetUserId(ServiceRadarDbContext dbContext, string userName)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user!.Id;
    }
}