using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Linq;
using Xunit;

namespace Calculations.UnitTests
{
    [Trait(@"Class", @"Calculations.PeopleApplication")]
    public class PeopleApplicationTests : IDisposable
    {
        private readonly Mocks.fakePeopleRepository _fakePeopleRepository;
        private readonly PeopleApplication _peopleApplication;

        public PeopleApplicationTests()
        {
            _fakePeopleRepository = new Mocks.fakePeopleRepository();
            _peopleApplication = new PeopleApplication(_fakePeopleRepository.Object);
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.Add")]
        [Fact(DisplayName = "Add - Added a new person, I expect that the number of people will increase and that the data will be sent to the repository.")]
        public void PeopleApplication_Add_Ok()
        {
            var newPerson = Person.Create("FirtName4", "LastName4", DateTime.Today.AddYears(-20));

            var initialCount = _fakePeopleRepository.Count;
            _peopleApplication.Add(newPerson);

            using (new AssertionScope())
            {                
                _fakePeopleRepository.Count
                    .Should()
                    .BeGreaterThan(initialCount);

                _fakePeopleRepository.Contains(newPerson)
                    .Should()
                    .BeTrue();
            }
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.Add")]
        [Fact(DisplayName = "Add already registered - Added a person with the same identifier, I expect the exception 'ApplicationException' " +
            "to be thrown with the message 'Identifier already registered.'.")]
        public void PeopleApplication_Add_ApplicationException()
        {
            var newPerson1 = Person.Create("FirtName4", "LastName4", DateTime.Today.AddYears(-20));

            var newPerson2 = Person.Create("FirtName5", "LastName5", DateTime.Today.AddYears(-20))
                .WithId(newPerson1.Id);

            _peopleApplication.Add(newPerson1);

            Action act = () => _peopleApplication.Add(newPerson2);

            act.Should()
                .Throw<ApplicationException>()
                .WithMessage("Identifier already registered.");
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.Remove")]
        [Fact(DisplayName = "Remove true - With one person removed, I expect that the number of people will decrease and that the data will no longer exist in the repository.")]
        public void PeopleApplication_Remove_True()
        {
            var removePerson = _fakePeopleRepository.People.First();
            var initialCount = _fakePeopleRepository.Count;

            var result = _peopleApplication.Remove(removePerson);

            result.Should().BeTrue();

            using (new AssertionScope())
            {
                _fakePeopleRepository.Count
                    .Should()
                    .BeLessThan(initialCount);

                _fakePeopleRepository.Contains(removePerson)
                    .Should()
                    .BeFalse();
            }
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.Remove")]
        [Fact(DisplayName = "Remove false - When trying to remove a person that does not exist in the repository, I expect that the number of people will not be changed.")]
        public void PeopleApplication_Remove_False()
        {
            var removePerson = Person.Create("FirtName4", "LastName4", DateTime.Today.AddYears(-20)); ;
            var initialCount = _fakePeopleRepository.Count;

            var result = _peopleApplication.Remove(removePerson);

            result.Should().BeFalse();

            _fakePeopleRepository.Count
                .Should()
                .Be(initialCount);
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.GetById")]
        [Fact(DisplayName = "GetById Exists - Given an identifier, I expect that the 'GetById' method will return an instance of 'Persson' for that identifier.")]
        public void PeopleApplication_GetById_Exists()
        {
            var firstPerson = _fakePeopleRepository.People.First();
            var result = _peopleApplication.GetById(firstPerson.Id);

            result.Should()
                .NotBeNull()
                .And.BeSameAs(firstPerson);
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.GetById")]
        [Fact(DisplayName = "GetById NotExists - Given an identifier that does not exist in the repository, I expect the 'GetById' method to return null.")]
        public void PeopleApplication_GetById_NotExists()
        {
            var result = _peopleApplication.GetById(new Guid("72C9B660-A329-461A-989C-753939D798D2"));

            result.Should()
                .BeNull();
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.ListAll")]
        [Fact(DisplayName = "ListAll - When running the 'ListAll' method, I expect to receive everyone from the repository.")]
        public void PeopleApplication_ListAll()
        {
            var result = _peopleApplication.ListAll();

            result.Should()
                .NotBeNull()
                .And.NotBeEmpty()
                .And.HaveCount(_fakePeopleRepository.Count)
                .And.ContainInOrder(_fakePeopleRepository.People);
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.ListByAgeGreaterOrEqual")]
        [Theory(DisplayName = "ListByAgeGreaterOrEqual - When executing the 'ListByAgeGreaterOrEqual' method, I expect people aged or equal to the specified parameter.")]
        [InlineData(9, 4)]
        [InlineData(15, 3)]
        [InlineData(19, 2)]
        [InlineData(30, 1)]
        [InlineData(31, 0)]
        public void PeopleApplication_ListByAgeGreaterOrEqual(int age, int count)
        {
            var result = _peopleApplication.ListByAgeGreaterOrEqual(age);

            result.Should()
                .NotBeNull()
                .And.HaveCount(count);
        }

        [Trait(@"Method", @"Calculations.PeopleApplication.ListByAgeLessOrEqual")]
        [Theory(DisplayName = "ListByAgeGreaterOrEqual - When executing the 'ListByAgeLessOrEqual' method, I expect people aged or less than the specified parameter.")]
        [InlineData(9, 0)]
        [InlineData(10, 1)]
        [InlineData(15, 2)]
        [InlineData(19, 3)]
        [InlineData(30, 4)]
        [InlineData(33, 4)]
        public async void PeopleApplication_ListByAgeLessOrEqual(int age, int count)
        {
            var result = await _peopleApplication.ListByAgeLessOrEqual(age);

            result.Should()
                .NotBeNull()
                .And.HaveCount(count);
        }

        [Fact]
        public void PeopleApplication_Dispose()
        { 
            var peopleApplication = new PeopleApplication(_fakePeopleRepository.Object);
            
            Action act = () => peopleApplication.Dispose();

            act.Should()
                .NotThrow();

            peopleApplication.disposedValue.Should()
                .BeTrue();

            act.Should()
                .NotThrow();
        }

        #region [IDisposable]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            {
                _peopleApplication.Dispose();
            }
            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [IDisposable]
    }
}
