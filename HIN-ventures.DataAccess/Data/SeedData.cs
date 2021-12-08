using System;
using System.Collections.Generic;
using System.Linq;
using HIN_ventures.DataAccess.Entities;

namespace HIN_ventures.DataAccess.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {

            //may not seed unless hooking up foregin keys
            if (!db.Ratings.Any())
            {

                ICollection<Rating> ratings = new List<Rating>();
                for (var i = 0; i < 50; i++)
                {
                    ratings.Add(new Rating()
                    {
                        RatingValue = new Random(i).Next(5), //a rating between 0 and 5
                        //FreelancerId = //new Random(i).Next(db.Freelancers.Count()), //pick a random freelancer
                        //CustomerId = new Random(i).Next(db.Customers.Count()) //pick a random customer
                    });
                }

                db.Ratings.AddRange(ratings);
                db.SaveChanges();
            }


            if (!db.ApplicationUser.Any() && !db.Customers.Any() && !db.Freelancers.Any() && !db.Assignments.Any())
            {
                ApplicationUser user1 = new()
                {
                    FirstName = "Rasputin",
                    Email = "rasputin@mail.com"
                };

                ApplicationUser user2 = new()
                {
                    FirstName = "Megatron",
                    Email = "megatron@mail.com"
                };

                ApplicationUser user3 = new()
                {
                    FirstName = "SuperBrain",
                    Email = "superbrain@mail.com"
                };

                ApplicationUser user4 = new()
                {
                    FirstName = "DeadPool",
                    Email = "deadpool@mail.com"
                };

                Customer customer1 = new()
                {
                    Name = "Quick Applications",
                    FirstName = "Erik",
                    LastName = "Hansen",
                    Email = user1.Email,
                    VAT_number = "ORG956121000",
                    CryptoAddress = "TEST123123123123",
                    SubscriptionType = 1,
                    TotalLinesOfCode = 500,
                    TotalCost = 24000,
                    IdentityId = user1.Id
                };

                Customer customer2 = new()
                {
                    Name = "Brødrene Dahl",
                    FirstName = "Lars",
                    LastName = "Larsen",
                    Email = user2.Email,
                    VAT_number = "ORG956121000",
                    CryptoAddress = "TEST123123123123",
                    SubscriptionType = 1,
                    TotalLinesOfCode = 500,
                    TotalCost = 52240,
                    IdentityId = user2.Id
                };

                Freelancer freelancer1 = new()
                {
                    FirstName = "Anna",
                    LastName = "SuperBrain",
                    Speciality = "Hacking",
                    TotalLinesOfCode = 7722,
                    CryptoAddress = "TEST123123123123",
                    IdentityId = user3.Id,
                    Email = user3.Email,

                };

                Freelancer freelancer2 = new()
                {
                    FirstName = "Anders",
                    LastName = "DeadPool",
                    Speciality = "Machine Learning",
                    TotalLinesOfCode = 11111,
                    CryptoAddress = "TEST123123123123",
                    IdentityId = user4.Id,
                    Email = user4.Email
                };

                //List<Assignment> assignmentsList = new List<Assignment>();

                ICollection<Assignment> assignments = new[]
                {
                    new Assignment
                    {
                        Title = "Api Task",
                        Description =
                            "Connect an application to an api. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                        Category = "FrontEnd/JavaScript",
                        Deadline = DateTime.Now.AddMonths(+2),
                        Freelancer = freelancer1
                    },
                    new Assignment
                    {
                        Title = "Program in Arduino",
                        Description =
                            "Creating a project in Arduino. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = "Electronics and Arduino",
                        Deadline = DateTime.Now.AddMonths(+1),
                        Freelancer = freelancer1
                    },
                    new Assignment
                    {
                        Title = "Write a C# Sharp Application",
                        Description =
                            "Create a simple API for a blog using a C# language.  It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                        Category = "C++ / C# Programming",
                        Deadline = DateTime.Now.AddMonths(+3),
                        Freelancer = freelancer2
                    },
                    new Assignment
                    {
                        Title = "Android E-commerce Application",
                        Description =
                            "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. ",
                        Category = "Kotlin/Android",
                        Deadline = DateTime.Now.AddMonths(+4),
                        Freelancer = freelancer2
                    }
                };

                db.Assignments.AddRange(assignments);

                //foreach (var assignment in assignments)
                //{
                //    assignmentsList.Add(assignment);
                //}

                //freelancer1.Assignments = new List<Assignment> { assignmentsList[0], assignmentsList[1] };
                //freelancer2.Assignments = new List<Assignment> { assignmentsList[2], assignmentsList[3] };

                //var freelancers = new[] { freelancer1, freelancer2 };
                //db.Freelancers.AddRange(freelancers);


                //var customers = new[] { customer1, customer2 };
                //db.Customers.AddRange(customers);



                db.SaveChanges();
            }
        }
    }
}