using GroupeCinema.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema
{
    class Class1 : EntityBase
    {
        private Int32 id;
        private String name;
        public Int32 Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
                this.OnPropertyChanged("Id");
            }
        }

        public String Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        public new List<Class1> LoadMultipleItems()
        {
            List<Class1> result = new List<Class1>();
            for (int i = 0; i < Faker.Number.RandomNumber(200000, 200001); i++)
            {
                result.Add(LoadSingleItem());
            }
            return result;
        }

        public Class1 LoadSingleItem()
        {
            Class1 result = new Class1();
            result.Id = Faker.Number.RandomNumber();
            result.Name = Faker.Name.FullName();
            return result;
        }
    }
}
