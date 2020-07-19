using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Calculations
{
    public class PeopleApplication : IDisposable
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleApplication(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public void Add(Person person)
        {
            var checkPerson = _peopleRepository.GetById(person.Id);
            if (checkPerson != null)
                throw new ApplicationException("Identifier already registered.");

            _peopleRepository.Add(person);
        }

        public Person GetById(Guid id) => _peopleRepository.GetById(id);

        public ICollection<Person> ListAll() => _peopleRepository.ListAll();

        public ICollection<Person> ListByAgeGreaterOrEqual(int age) => _peopleRepository.ListByAgeGreaterOrEqual(age);

        public ICollection<Person> ListByAgeLessOrEqual(int age) => _peopleRepository.ListByAgeLessOrEqual(age);

        public bool Remove(Person person) => _peopleRepository.Remove(person);

        #region [Disposable]
        internal bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            {
            }

            disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion [Disposable]
    }

    public interface IPeopleRepository
    {
        void Add(Person person);

        bool Remove(Person person);

        ICollection<Person> ListAll();

        ICollection<Person> ListByAgeGreaterOrEqual(int age);

        ICollection<Person> ListByAgeLessOrEqual(int age);

        Person GetById(Guid id);
    }

    ////Essa classe seria uma implementação com acesso a algum banco de dados. está aqui apenas como ilustação
    //internal class PeopleRepository : IDisposable, IPeopleRepository
    //{
    //    private readonly ICollection<Person> _people;

    //    public PeopleRepository()
    //    {
    //        _people = new Collection<Person>();
    //    }

    //    public void Add(Person people) => _people.Add(people);

    //    public Person GetById(Guid id) => _people.FirstOrDefault(p => p.Id.Equals(id));

    //    public ICollection<Person> ListAll() => _people;

    //    public ICollection<Person> ListByAgeGreaterOrEqual(int age) => _people.Where(p => p.Age >= age) as ICollection<Person>;

    //    public ICollection<Person> ListByAgeLessOrEqual(int age) => _people.Where(p => p.Age <= age) as ICollection<Person>;

    //    public ICollection<Person> ListByFirstName(string firstName) => _people.Where(p => p.FirstName.Equals(firstName)).ToList();

    //    public ICollection<Person> ListByFullName(string fullName) => _people.Where(p => p.FullName.Equals(fullName)).ToList();

    //    public ICollection<Person> ListByLastName(string lastName) => _people.Where(p => p.FirstName.Equals(lastName)).ToList();

    //    public bool Remove(Person people) => _people.Remove(people);

    //    #region [Disposable]

    //    private bool disposedValue;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (disposedValue)
    //            return;

    //        if (disposing)
    //        {
    //        }

    //        disposedValue = true;
    //    }

    //    ~PeopleRepository()
    //    {
    //        Dispose(disposing: false);
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(disposing: true);
    //        GC.SuppressFinalize(this);
    //    }

    //    #endregion [Disposable]
    //}
}
