namespace CardonCodingExercise.Migrations
{
    using CardonCodingExercise.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CardonCodingExercise.Models.CandidateDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CardonCodingExercise.Models.CandidateDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Candidates.AddOrUpdate(i => i.FirstName)



            var candidates = new List<Candidate>
            {
            new Candidate{FirstName="Jack",LastName="Nicholson",Email="jack@yahoo.com",PhoneNumber="8324529812",ZipCode="37733"},
            new Candidate{FirstName="Bob",LastName="Alexander",Email="Bob.Alex@outlook.com",PhoneNumber="9218327550",ZipCode="77733"},
            new Candidate{FirstName="Alex",LastName="Reeves",Email="AReeves@gmail.com",PhoneNumber="4448321245",ZipCode="75843"},
            new Candidate{FirstName="Emily",LastName="Paltrow",Email="E.Paltrow@gmail.com",PhoneNumber="8904553563",ZipCode="27733"},
            new Candidate{FirstName="Janice",LastName="Hathaway",Email="JaniceHath@outlook.com",PhoneNumber="7132524644",ZipCode="77733"},
            new Candidate{FirstName="Anna",LastName="Smith",Email="AnnaSmith@gmail.com",PhoneNumber="2234567890",ZipCode="45222"}
            
            };

            candidates.ForEach(s => context.Candidates.Add(s));
            context.SaveChanges();

            var qualifications = new List<Qualification>
            {
                new Qualification{CandidateID=1,Type="Professional Certification",QualificationName="Microsoft",DateStarted=DateTime.Parse("2004-03-02"),DateCompleted=DateTime.Parse("2005-04-09")},
                new Qualification{CandidateID=1,Type="Work Experience",QualificationName="Buffalo Wild Wings",DateStarted=DateTime.Parse("2006-11-12"),DateCompleted=DateTime.Parse("2009-12-19")},
                new Qualification{CandidateID=2,Type="College Degree",QualificationName="Texas Tech University",DateStarted=DateTime.Parse("2000-08-22"),DateCompleted=DateTime.Parse("2005-10-04")},
                new Qualification{CandidateID=4,Type="Professional Certification",QualificationName="Test Certificate",DateStarted=DateTime.Parse("2009-01-13"),DateCompleted=DateTime.Parse("2012-07-01")},
                new Qualification{CandidateID=4,Type="Work Experience",QualificationName="Buffalo Wild Wings",DateStarted=DateTime.Parse("2009-01-13"),DateCompleted=DateTime.Parse("2012-07-01")},
                new Qualification{CandidateID=5,Type="College Degree",QualificationName="Test University",DateStarted=DateTime.Parse("2011-01-13"),DateCompleted=DateTime.Parse("2012-07-01")},
                new Qualification{CandidateID=3,Type="College Degree",QualificationName="Test University",DateStarted=DateTime.Parse("2001-01-13"),DateCompleted=DateTime.Parse("2012-07-01")},
                new Qualification{CandidateID=3,Type="Work Experience",QualificationName="Joe's Crab Shack",DateStarted=DateTime.Parse("2002-01-13"),DateCompleted=DateTime.Parse("2010-07-01")}


            };
            qualifications.ForEach(s => context.Qualifications.Add(s));
            context.SaveChanges();

        } 
    }
}
