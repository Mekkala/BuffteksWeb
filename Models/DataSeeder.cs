using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Buffteks.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
             using(var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                
                context.Database.EnsureCreated();
                // Member
                if (context.Members.Any())
                {
                   
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="John", LastName="Miler", Major="CIS", 
                                 Email="jmiler@buffs.wtamu.edu", Phone="806-487-751" },
                    new Member { FirstName="William", LastName="Smith", Major="CIS", 
                                 Email="wsmith@buffs.wtamu.edu", Phone="879-458-965" },
                    new Member { FirstName="James", LastName="Brown", Major="CIS", 
                                 Email="jbrown@buffs.wtamu.edu", Phone="575-812-1127" },
                    new Member { FirstName="Thomas", LastName="Davis", Major="CIS", 
                                 Email="tdavis@buffs.wtamu.edu", Phone="806-452-3322" },
                    new Member { FirstName="Henry", LastName="Jones", Major="CIS", 
                                 Email="hjones@buffs.wtamu.edu", Phone="897-421-699" },
                    new Member { FirstName="Jane", LastName="Johnson", Major="CIS", 
                                 Email="jjohnson@buffs.wtamu.edu", Phone="575-693-3665" },
                    new Member { FirstName="Mary", LastName="Clark", Major="CIS", 
                                 Email="mclark@buffs.wtamu.edu", Phone="806-784-2254" },
                    new Member { FirstName="Nancy", LastName="Williams", Major="CIS", 
                                 Email="nwilliams@buffs.wtamu.edu", Phone="806-877-9938" },
                    new Member { FirstName="Sarah", LastName="Garcia", Major="CIS", 
                                 Email="sgarcia@buffs.wtamu.edu", Phone="879-874-521" },
                    new Member { FirstName="Samantha", LastName="Thompson", Major="CIS", 
                                 Email="sthompson@buffs.wtamu.edu", Phone="205-845-1149" },
                    new Member { FirstName="Robert", LastName="Peters", Major="CIS", 
                                 Email="rpeters@buffs.wtamu.edu", Phone="205-789-142" },
                    new Member { FirstName="Amiya", LastName="Lee", Major="CIS", 
                                 Email="alee@buffs.wtamu.edu", Phone="806-874-1154" },                          
                };
                context.AddRange(members);
                context.SaveChanges();

                // CLIENTS
                if (context.Clients.Any())
                {
                    
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Nelson", LastName="Green", CompanyName="ABC Inc.", 
                                 Email="ngreen@abc.com", Phone="872-356-697" },
                    new Client { FirstName="Adam", LastName="Carter", CompanyName="Evergreen Inc.", 
                                 Email="acarter@evg.com", Phone="806-875-123" },
                    new Client { FirstName="Kelly", LastName="Baker", CompanyName="DreamsWork Inc.", 
                                 Email="kbaker@dwork.com", Phone="806-245-987" }
                };
                context.AddRange(clients);
                context.SaveChanges();

                // Project
                 if (context.Projects.Any())
                {
                   
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="BigFoot", Description="Create a website for marketing company." },
                    new Project { ProjectName="X Power", Description="Create web page for wholesales company." },
                    new Project { ProjectName="101 Project", Description="Build web application for local private company." }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //Project Assign participants to Project

                if (context.ProjectAssigns.Any())
                {
                    return;
                }

                //Grab data from database
                var membersFmDb = context.Members.ToList();
                var clientsFmDb = context.Clients.ToList();
                var projectsFmDb = context.Projects.ToList();

                //Assign participant for first project

                var projectoneassign = new List<ProjectAssign>
                {
                    // grab client
                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(0).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(0),
                                        ParticipantID = clientsFmDb.ElementAt(0).ID,
                                        ProjectParticipant = clientsFmDb.ElementAt(0)},
                    // grab first 4 members(1 2 3 & 4)                    
                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(0).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(0),
                                        ParticipantID = membersFmDb.ElementAt(0).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(0)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(0).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(0),
                                        ParticipantID = membersFmDb.ElementAt(1).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(1)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(0).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(0),
                                        ParticipantID = membersFmDb.ElementAt(2).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(2)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(0).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(0),
                                        ParticipantID = membersFmDb.ElementAt(3).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(3)},                                                            
                };
                context.AddRange(projectoneassign);
                context.SaveChanges();

                //Assign participant for second project

                var projecttwoassign = new List<ProjectAssign>
                {
                    // grab client 2
                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(1).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(1),
                                        ParticipantID = clientsFmDb.ElementAt(1).ID,
                                        ProjectParticipant = clientsFmDb.ElementAt(1)},
                    // grab 4 members(5 6 7 & 8)                    
                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(1).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(1),
                                        ParticipantID = membersFmDb.ElementAt(4).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(4)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(1).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(1),
                                        ParticipantID = membersFmDb.ElementAt(5).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(5)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(1).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(1),
                                        ParticipantID = membersFmDb.ElementAt(6).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(6)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(1).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(1),
                                        ParticipantID = membersFmDb.ElementAt(7).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(7)},                                                            
                };
                context.AddRange(projecttwoassign);
                context.SaveChanges();

                //Assign participant for third project

                var projectthreeassign = new List<ProjectAssign>
                {
                    // grab client 3
                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(2).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(2),
                                        ParticipantID = clientsFmDb.ElementAt(2).ID,
                                        ProjectParticipant = clientsFmDb.ElementAt(2)},
                    // grab 4 members(9 10 11 & 12)                    
                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(2).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(2),
                                        ParticipantID = membersFmDb.ElementAt(8).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(8)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(2).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(2),
                                        ParticipantID = membersFmDb.ElementAt(9).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(9)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(2).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(2),
                                        ParticipantID = membersFmDb.ElementAt(10).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(10)},

                    new ProjectAssign { ProjectID = projectsFmDb.ElementAt(2).ID.ToString(),
                                        Project = projectsFmDb.ElementAt(2),
                                        ParticipantID = membersFmDb.ElementAt(11).ID,
                                        ProjectParticipant = membersFmDb.ElementAt(11)},                                                            
                };
                context.AddRange(projectthreeassign);
                context.SaveChanges();


            }

        }
    }

}        