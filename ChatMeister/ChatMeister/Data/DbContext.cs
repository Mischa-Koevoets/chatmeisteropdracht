using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ChatMeister.Data
{
    internal class ChatContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=chatdb", ServerVersion.Parse("8.0.30"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Alice",
                    Email = "alice@example.com"
                },
                new User
                {
                    Id = 2,
                    Name = "Bob",
                    Email = "bob@example.com"

                }

            );

            modelBuilder.Entity<Chat>().HasData(
                new Chat
                {
                    Id = 1,
                    Name = "Chatroom 1"
                },
                new Chat
                {
                    Id = 2,
                    Name = "Chatroom 2"
                }
            );
            modelBuilder.Entity<Message>().HasData(
                new Message
                {
                    Id = 1,
                    ChatId = 1,
                    SenderId = 1,
                    Content = "Hello everyone!",
                    SentAt = DateTime.Parse("2023-06-27 19:15:00")

                },
                new Message
                {
                    Id = 2,
                    ChatId = 1,
                    SenderId = 2,
                    Content = "Hi Alice!",
                    SentAt = DateTime.Parse("2023-06-27 19:17:00")
                },
                new Message
                {
                    Id = 3,
                    ChatId = 2,
                    SenderId = 1,
                    Content = "We're doing great!",
                    SentAt = DateTime.Parse("2023-06-27 10:35:00")
                }

            );


        }





    }
}
