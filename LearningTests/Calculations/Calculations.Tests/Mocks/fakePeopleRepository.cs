using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Calculations.UnitTests.Mocks
{
    public class fakePeopleRepository : IMock<IPeopleRepository>
    {
        private readonly ICollection<Person> _people;
        private readonly Mock<IPeopleRepository> _fakePeopleRepository;
        public int Count => _people.Count;
        public IList<Person> People => _people.ToList();

        public fakePeopleRepository()
        {
            _people = new Collection<Person> {
                Person.Create("FirstName1", "LastName1", DateTime.Today.AddYears(-10)).WithId(new Guid("D71A233A-6D75-473D-9E5F-91EEA570ED17")),
                Person.Create("FirstName2", "LastName1", DateTime.Today.AddYears(-15)).WithId(new Guid("25EAE555-C4F9-4382-B666-62EE44BBD362")),
                Person.Create("FirstName3", "LastName2", DateTime.Today.AddYears(-19)).WithId(new Guid("74982EB2-9D88-463B-9EBA-576DABC43F52")),
                Person.Create("FirstName5", "LastName3", DateTime.Today.AddYears(-30)).WithId(new Guid("BFF41869-0533-4464-A6BE-58ADAC3E272B"))
            };

            _fakePeopleRepository = new Mock<IPeopleRepository>();

            SetupMock();
        }

        public bool Contains(Person person) => _people.Contains(person);

        public IPeopleRepository Object => _fakePeopleRepository.Object;

        public MockBehavior Behavior => _fakePeopleRepository.Behavior;

        public bool CallBase { get => _fakePeopleRepository.CallBase; set => _fakePeopleRepository.CallBase = value; }

        public DefaultValue DefaultValue { get => _fakePeopleRepository.DefaultValue; set => _fakePeopleRepository.DefaultValue = value; }

        private void SetupMock()
        {
            _fakePeopleRepository.Setup(pr => pr.Add(It.IsAny<Person>()))
                .Callback((Person person) => _people.Add(person));

            _fakePeopleRepository
                .Setup(pr => pr.Remove(It.IsAny<Person>()))                
                .Returns((Person person) => _people.Remove(person));

            _fakePeopleRepository
                .Setup(pr => pr.ListAll())
                .Returns(_people);

            _fakePeopleRepository
                .Setup(pr => pr.ListByAgeGreaterOrEqual(It.IsAny<int>()))
                .Returns((int age) => _people.Where(p => p.Age >= age).ToList());

            _fakePeopleRepository
                .Setup(pr => pr.ListByAgeLessOrEqual(It.IsAny<int>()))
                .Returns((int age) => _people.Where(p => p.Age <= age).ToList());

            _fakePeopleRepository
                .Setup(pr => pr.GetById(It.IsAny<Guid>()))
                .Returns((Guid id) => _people.FirstOrDefault(p => p.Id.Equals(id)));
        }
    }
}
