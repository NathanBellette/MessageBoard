using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace MessageBoard.Data
{
    public class MessageBoardsConfigurationMigration : DbMigrationsConfiguration<MessageBoardContext>
    {
        public MessageBoardsConfigurationMigration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MessageBoardContext context)
        {
            base.Seed(context);
#if DEBUG
            if (context.Topics.Count() == 0)
            {
                var topic = new Topic()
                {
                    Title = "I love MVC",
                    Created = DateTime.Now,
                    Body = "ASP.NET MVC is great",
                    Replies = new List<Reply>()
                    {
                        new Reply()
                        {
                            Body = "I love it too",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Me too",
                            Created = DateTime.Now
                        },
                        new Reply()
                        {
                            Body = "Not me, I prefer Rails",
                            Created = DateTime.Now
                        }
                    }
                };
                context.Topics.Add(topic);

                var anotherTopic = new Topic()
                {
                    Title = "I like Ruby too",
                    Created = DateTime.Now,
                    Body = "Ruby on Rails is popular"
                };

                context.Topics.Add(anotherTopic);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message; 
                }
            }
#endif
        }
    }
}
