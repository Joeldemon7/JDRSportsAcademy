using JDRSportsAcademy.Models;

namespace JDRSportsAcademy.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SportContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="John",LastName="Doe",DOB=DateTime.Parse("2000-01-01"),Gender="Male",Address="123 Main St",ContactNumber="1234567890",MedicalInformation="None",Email="john.doe@example.com"},
                new Student{FirstName="Jane",LastName="Smith",DOB=DateTime.Parse("2001-02-01"),Gender="Female",Address="456 Maple Ave",ContactNumber="0987654321",MedicalInformation="Asthma",Email="jane.smith@example.com"},
                new Student{FirstName="Den",LastName="Ronald",DOB=DateTime.Parse("2003-12-08"),Gender="Male",Address="45 Road Avenue",ContactNumber="0954785887",MedicalInformation="Skinny",Email="den12@gmail.com"},
                new Student{FirstName="Alcy",LastName="Mad",DOB=DateTime.Parse("2004-05-11"),Gender="Female",Address="56 Mandev Street",ContactNumber="01548568478",MedicalInformation="Heat Exhaustion",Email="mad666@gmail.com"},
                new Student{FirstName="Troy",LastName="Diaz",DOB=DateTime.Parse("2002-07-16"),Gender="Male",Address="06 Park Way",ContactNumber="87499473638",MedicalInformation="None",Email="diaz789@gmail.com"},
                new Student{FirstName="Jeston",LastName="Lopez",DOB=DateTime.Parse("2000-08-22"),Gender="Male",Address="16 London Gardens",ContactNumber="8636295011",MedicalInformation="None",Email="lol123@gmail.com"},
                new Student{FirstName="Megan",LastName="Morales",DOB=DateTime.Parse("1999-04-02"),Gender="Female",Address="67 Oxford Road",ContactNumber="0725143290",MedicalInformation="None",Email="megmor247@gmail.com"}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var sports = new Sport[]
            {
                new Sport{SportName="Football"},
                new Sport{SportName="Basketball"},
                new Sport{SportName="Badminton"},
                new Sport{SportName="Hockey"}
            };

            context.Sports.AddRange(sports);
            context.SaveChanges();

            var fixtures = new Fixture[]
            {
                new Fixture{FixtureName="Leauge Match",SportID=1,StudentID=1,Date=DateTime.Parse("2025-08-16"),Time=DateTime.Parse("10:00:00"),Location="Stadium A"},
                new Fixture{FixtureName="Friendly Match",SportID=2,StudentID=2,Date=DateTime.Parse("2024-08-16"),Time=DateTime.Parse("14:00:00"),Location="Arena B"},
                new Fixture{FixtureName="Friendly Match",SportID=2,StudentID=3,Date=DateTime.Parse("2024-08-16"),Time=DateTime.Parse("14:00:00"),Location="Arena B"},
                new Fixture{FixtureName="One V One",SportID=3,StudentID=4,Date=DateTime.Parse("2024-10-07"),Time=DateTime.Parse("15:00:00"),Location="Badminton Court A"},
                new Fixture{FixtureName="One V One",SportID=3,StudentID=5,Date=DateTime.Parse("2024-10-07"),Time=DateTime.Parse("15:00:00"),Location="Badminton Court A"},
                new Fixture{FixtureName="Training Session",SportID=4,StudentID=6,Date=DateTime.Parse("2024-11-10"),Time=DateTime.Parse("07:00:00"),Location="Ground A"},
                new Fixture{FixtureName="Leauge Match",SportID=1,StudentID=7,Date=DateTime.Parse("2025-08-16"),Time=DateTime.Parse("10:00:00"),Location="Stadium A"}
            };

            context.Fixtures.AddRange(fixtures);
            context.SaveChanges();
        }
    }
}