﻿using Microsoft.EntityFrameworkCore;

namespace BidCalculationTool.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    //Todo: Implement Entity Sets for VehicleType and Fee
}
