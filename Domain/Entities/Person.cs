using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Person:Entity
    {
        protected Person(){ }

        public Person(string docoment, string name, string profilePicUrl, DateTime birthDate, User user)
        {
            Docoment = docoment;
            Name = name;
            ProfilePicUrl = profilePicUrl;
            BirthDate = birthDate;
            User = user;
        }

        public string Docoment { get; private set; }
        public string Name { get; private set; }
        public string ProfilePicUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public User User { get; private set; }
        public Guid UserId { get; private set; }

    }
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithOne(e => e.Person)
                .HasForeignKey<Person>(e => e.UserId);
        }
    }
}
