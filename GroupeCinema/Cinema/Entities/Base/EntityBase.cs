using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupeCinema.MyFaker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupeCinema.Cinema
{
    public class EntityBase : INotifyPropertyChanged, IFakerLoader<EntityBase>
    {
        

        private Int32 id;

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
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

        public event PropertyChangedEventHandler PropertyChanged;

        public List<EntityBase> LoadMultipleItems()
        {
            List<EntityBase> result = new List<EntityBase>();
            for(int i = 0; i < Faker.Number.RandomNumber(3, 20); i++)
            {
                result.Add(LoadSingleItem());
            }
            return result;
        }

        private EntityBase LoadSingleItem()
        {
            EntityBase result = new EntityBase();
            result.Id = Faker.Number.RandomNumber();
            return this;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        EntityBase IFakerLoader<EntityBase>.LoadSingleItem()
        {
            throw new NotImplementedException();
        }
    }
}
