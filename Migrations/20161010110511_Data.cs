using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Timesheets.Models;

namespace Timesheets.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            using (var db = new TimesheetContext()) {
                foreach (var b in new [] {
                    new {code="5H", name="5 hrs", length=300},
                    new {code="HH", name="1/2 hr", length=30},
                    new {code="1H", name="1 hr", length=60},
                    new {code="1.5H", name="1 1/2 hr", length=90},
                    new {code="2H", name="2 hrs", length=120},
                    new {code="15M", name="15 min", length=15},
                    new {code="45M", name="45 min", length=45},
                    new {code="1H15M", name="1 hr 15 min", length=75},
                    new {code="1H45M", name="1 hr 45 min", length=105},
                    new {code="2H15M", name="2 hrs 15 min", length=135},
                    new {code="2H30M", name="2 hrs 30 min", length=150},
                    new {code="2H45M", name="2 hrs 45 min", length=165},
                    new {code="3H0M", name="3 hrs ", length=180},
                    new {code="3H15M", name="3 hrs 15 min", length=195},
                    new {code="3H30M", name="3 hrs 30 min", length=210},
                    new {code="3H45M", name="3 hrs 45 min", length=225},
                    new {code="4H0M", name="4 hrs ", length=240},
                    new {code="4H15M", name="4 hrs 15 min", length=255},
                    new {code="4H30M", name="4 hrs 30 min", length=270},
                    new {code="4H45M", name="4 hrs 45 min", length=285},
                }) db.Breaks.Add(new Break(b.code, b.name, b.length));
                db.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
