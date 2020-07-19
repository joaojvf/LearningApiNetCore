using System;

namespace Calculations
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime BirthDate { get; }
        public int Age { get; }
        public string FullName => $"{FirstName} {LastName}";

        internal Person(string firstName, string lastName, DateTime birthDate)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;

            var age = DateTime.Today.Year - BirthDate.Year;
            if (age > 0)
                Age = age - Convert.ToInt32(DateTime.Today.Date < BirthDate.Date.AddYears(age));
        }

        public static Person Create(string firstName, string lastName, DateTime birthDate)
        {
            Helper.CheckParameterNotNullOrEmpty(firstName, "firstName", string.Empty);
            Helper.CheckParameterNotNullOrEmpty(lastName, "lastName", string.Empty);
            if (birthDate.Date <= DateTime.MinValue || birthDate.Date > DateTime.Today.Date)
                throw new ArgumentNullException("birthDate");

            return new Person(firstName, lastName, birthDate);
        }

        public Person WithId(Guid id)
        {
            Helper.CheckParameterNotNull(id, "id", Guid.Empty);

            Id = id;
            return this;
        }

    }
}