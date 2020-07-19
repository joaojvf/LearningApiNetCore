using FluentAssertions;
using FluentAssertions.Execution;
using System;
using Xunit;

namespace Calculations.UnitTests
{
    [Trait(@"Class", @"Calculations.Person")]
    public class PersonTests
    {
        [Trait(@"Method", @"Calculations.Person.Create")]
        [Fact(DisplayName = "Create - When executing the static 'Create' method of the 'Person' class, I expect to receive an instance of 'Person' with all the properties defined.")]
        public void Create()
        {
            var actFistName = "FistName";
            var actLastName = "LastName";
            var actBirthDate = new DateTime(2020, 1, 1);

            var person = Person.Create(actFistName, actLastName, actBirthDate);

            using (new AssertionScope())
            {
                person.Should()
                    .NotBeNull();

                person.Id.Should()
                    .NotBeEmpty();

                person.FirstName.Should()
                    .NotBeNullOrEmpty()
                    .And.Be(actFistName);

                person.LastName.Should()
                    .NotBeNullOrEmpty()
                    .And.Be(actLastName);

                person.BirthDate.Should()
                    .NotBeBefore(DateTime.MinValue)
                    .And.NotBeAfter(DateTime.Today)
                    .And.Be(actBirthDate);

                person.FullName.Should()
                    .NotBeNullOrEmpty()
                    .And.Be($"{actFistName} {actLastName}");

                person.Age.Should()
                    .BeGreaterThan(-1)
                    .And.Be(0);

            }
        }

        [Trait(@"Method", @"Calculations.Person.Create")]
        [Fact(DisplayName = "Create ArgumentNullException firstName - When executing the static 'Create' method of the 'Person' class, I expect to receive the 'ArgumentNullException' " +
            "exception with the message \"Value cannot be null. (Parameter 'firstName')\" when to pass the empty 'firstName';")]
        public void CreateFirstNameNullOrEmpty()
        {
            Action act = () => Person.Create("", "LastName", new DateTime(2020, 1, 1));
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'firstName')");
        }

        [Trait(@"Method", @"Calculations.Person.Create")]
        [Fact(DisplayName = "Create ArgumentNullException lastName - When executing the static 'Create' method of the 'Person' class, I expect to receive the 'ArgumentNullException' " +
            "exception with the message \"Value cannot be null. (Parameter 'lastName')\" when to pass the empty 'lastName';")]
        public void CreateLastNameNullOrEmpty()
        {
            Action act = () => Person.Create("FirstName", "", new DateTime(2020, 1, 1));
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'lastName')");
        }

        [Trait(@"Method", @"Calculations.Person.Create")]
        [Fact(DisplayName = "Create ArgumentNullException birthDate - When executing the static 'Create' method of the 'Person' class, " +
            "I expect to receive the exception 'ArgumentNullException' with the message \"Value cannot be null. (Parameter 'birthDate')\" " +
            "when passing 'birthDate' out of the valid values;")]
        public void CreateBirthDateInvalid()
        {
            Action actAfter = () => Person.Create("FirstName", "LastName", DateTime.Today.AddDays(1));
            Action actMin = () => Person.Create("FirstName", "LastName", DateTime.MinValue);

            using (new AssertionScope())
            {
                actAfter.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'birthDate')");

                actMin.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'birthDate')");
            }
        }


        [Trait(@"Method", @"Calculations.Person.WithId")]
        [Fact(DisplayName = "Create WithId - When executing the 'With Id' static method of the 'Person' class, " +
            "I expect to receive an instance of 'Person' with all the properties defined and the ID that was provided.")]
        public void CreateWithId()
        {
            var actId = Guid.NewGuid();
            var actFistName = "FistName";
            var actLastName = "LastName";
            var actBirthDate = new DateTime(2010, 1, 1);

            var person = Person
                .Create(actFistName, actLastName, actBirthDate)
                .WithId(actId);

            using (new AssertionScope())
            {
                person.Should()
                    .NotBeNull();

                person.Id.Should()
                    .NotBeEmpty()
                    .And.Be(actId);

                person.FirstName.Should()
                    .NotBeNullOrEmpty()
                    .And.Be(actFistName);

                person.LastName.Should()
                    .NotBeNullOrEmpty()
                    .And.Be(actLastName);

                person.BirthDate.Should()
                    .NotBeBefore(DateTime.MinValue)
                    .And.NotBeAfter(DateTime.Today)
                    .And.Be(actBirthDate);

                person.FullName.Should()
                    .NotBeNullOrEmpty()
                    .And.Be($"{actFistName} {actLastName}");

                person.Age.Should()
                    .BeGreaterThan(-1)
                    .And.Be(10);

            }
        }

        [Trait(@"Method", @"Calculations.Person.WithId")]
        [Fact(DisplayName = "Create WithId ArgumentNullException id - When executing the 'WithId' method of the 'Person' class, " +
            "I expect to receive the exception 'ArgumentNullException' with the message \"Value cannot be null. (Parameter 'id')\" " +
            "when passing 'id' out of the valid values;")]
        public void CreateWithIdInvalid()
        {
            var person = Person
                .Create("FistName", "LastName", new DateTime(2020, 1, 1));                
            
            Action actEmpty = () => person.WithId(Guid.Empty);
            Action actDefault = () => person.WithId(default);

            using (new AssertionScope())
            {
                actEmpty.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'id')");

                actDefault.Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'id')");
            }
        }
    }
}
