using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Cinema
{
    public abstract class Provider : User
    {
        #region Attributes
        private String companyName;
        #endregion

        #region Properties
        public String CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                this.OnPropertyChanged("CompanyName");
            }
        }
        #endregion

        #region Constructor
        public Provider()
        {

        }
        #endregion

        #region Methods
        #endregion
    }
}
