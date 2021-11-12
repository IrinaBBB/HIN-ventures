using System;
using System.Collections.Generic;
using System.Linq;
using HIN_ventures.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace HIN_ventures.DataAccess.Data
{
    public static class SeedData
    {

        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Freelancers.Any())
            {
                Freelancer freelancer1 = new()
                {
                    Name = "Rasputin",
                    Speciality = "Machine Learning",
                    AverageRating = 45,
                    TotalLinesOfCode = 11111,
                    LinesOfCodeMonth = 2000
                };

                Freelancer freelancer2 = new()
                {
                    Name = "Megatron",
                    Speciality = "Hacking",
                    AverageRating = 71,
                    TotalLinesOfCode = 7722,
                    LinesOfCodeMonth = 1200
                };

                if (!db.Assignments.Any())
                {
                    var assignments = new[]
                    {
                    new Assignment
                    {
                        Title = "Api Task",
                        Description =
                            "Connect an application to an api. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                        Category = "FrontEnd/JavaScript",
                        Deadline = DateTime.Now.AddMonths(+2),
                        Freelancer = freelancer1, FreelancerId = freelancer1.FreelancerId
                    },
                    new Assignment
                    {
                        Title = "Program in Arduino",
                        Description =
                            "Creating a project in Arduino. The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.",
                        Category = "Electronics and Arduino",
                        Deadline = DateTime.Now.AddMonths(+1),
                        Freelancer = freelancer1, FreelancerId = freelancer1.FreelancerId
                    },
                    new Assignment
                    {
                        Title = "Write a C# Sharp Application",
                        Description =
                            "Create a simple API for a blog using a C# language.  It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                        Category = "C++ / C# Programming",
                        Deadline = DateTime.Now.AddMonths(+3),
                        Freelancer = freelancer2, FreelancerId = freelancer2.FreelancerId
                    },
                    new Assignment
                    {
                        Title = "Android E-commerce Application",
                        Description =
                            "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. ",
                        Category = "Kotlin/Android",
                        Deadline = DateTime.Now.AddMonths(+4),
                        Freelancer = freelancer2, FreelancerId = freelancer2.FreelancerId

                    }
                };

                    db.Assignments.AddRange(assignments);
                    db.SaveChanges();


                    freelancer1.Assignments = new List<Assignment> { assignments[0], assignments[1] };
                    freelancer2.Assignments = new List<Assignment> { assignments[2], assignments[3] };

                    var freelancers = new Freelancer[] { freelancer1, freelancer2 };
                    db.Freelancers.AddRange(freelancers);
                    db.SaveChanges();

                    
                }
            }
        }
    }
}