using GroupeCinema.API;
using GroupeCinema.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupeCinema.Database
{
    
    //public class MySQLManager<TEntity> : DbContext where TEntity : class
    ///public MysqlOrApi(Enum value, TEntity item) where TEntity : class
    public class Crud<TEntity> where TEntity : class
    {

        public Crud()
        {

        }
   
        public async Task<TEntity> Insert(TEntity item)
        {
            if(CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<TEntity> manager = new MySQLManager<TEntity>(DataConnectionResource.LOCALMYQSL);
                    manager.Insert(item);
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<TEntity> manager = new WebServiceManager<TEntity>(DataConnectionResource.LOCALAPI);
                    manager.Post(item);
                });
            }
            return item;
        }
        public async Task<IEnumerable<TEntity>> Insert(IEnumerable<TEntity> items)
        {
            if (CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<IEnumerable<TEntity>> manager5 = new MySQLManager<IEnumerable<TEntity>>(DataConnectionResource.LOCALMYQSL);
                    manager5.Insert(items);
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<IEnumerable<TEntity>> manager = new WebServiceManager<IEnumerable<TEntity>>(DataConnectionResource.LOCALAPI);
                    manager.Post(items);
                });
            }
            return items;
        }


        public async Task<TEntity> Update(TEntity item)
        {
            if (CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<TEntity> manager = new MySQLManager<TEntity>(DataConnectionResource.LOCALMYQSL);
                    manager.Update(item);
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<TEntity> manager = new WebServiceManager<TEntity>(DataConnectionResource.LOCALAPI);
                    manager.Put(item);
                });
            }
            return item;
        }

        public async Task<IEnumerable<TEntity>> Update(IEnumerable<TEntity> items)
        {
            if (CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<IEnumerable<TEntity>> manager = new MySQLManager<IEnumerable<TEntity>>(DataConnectionResource.LOCALMYQSL);
                    manager.Update(items);
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<IEnumerable<TEntity>> manager = new WebServiceManager<IEnumerable<TEntity>>(DataConnectionResource.LOCALAPI);
                    manager.Put(items);
                });
            }
            return items;
        }

        /*public async Task<TEntity> Get(Int32 id)
        {
            TEntity result;
            //if (CheckDB.checkDB_Conn())
            //{
                await Task.Factory.StartNew(()=>
                {
                    MySQLManager<TEntity> manager5 = new MySQLManager<TEntity>(DataConnectionResource.LOCALMYQSL);
                    result = manager5.Get(id).Result;
                    return result;
                });
            /*}
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<TEntity> manager5 = new WebServiceManager<TEntity>(DataConnectionResource.LOCALAPI);
                    result = manager5.Get(id).Result;
                    return result;
                });   
            }*/
            
        //}

        public async Task<List<TEntity>> Get()
        {
            List<TEntity> results = new List<TEntity>();
            if (CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<List<TEntity>> manager5 = new MySQLManager<List<TEntity>>(DataConnectionResource.LOCALMYQSL);
                    results = manager5.Get().Result as List<TEntity>;
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<List<TEntity>> manager5 = new WebServiceManager<List<TEntity>>(DataConnectionResource.LOCALAPI);
                    results = manager5.Get().Result as List<TEntity>;
                });
            }
            return results;
        }

        public async Task<TEntity> Delete(TEntity item)
        {
            if (CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<TEntity> manager = new MySQLManager<TEntity>(DataConnectionResource.LOCALMYQSL);
                    manager.Delete(item);
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<TEntity> manager = new WebServiceManager<TEntity>(DataConnectionResource.LOCALAPI);
                    manager.Delete(item);
                });
            }
            return item;
        }

        public async Task<IEnumerable<TEntity>> Delete(IEnumerable<TEntity> items)
        {
            if (CheckDB.checkDB_Conn())
            {
                await Task.Factory.StartNew(() =>
                {
                    MySQLManager<IEnumerable<TEntity>> manager = new MySQLManager<IEnumerable<TEntity>>(DataConnectionResource.LOCALMYQSL);
                    manager.Delete(items);
                });
            }
            else
            {
                await Task.Factory.StartNew(() =>
                {
                    WebServiceManager<IEnumerable<TEntity>> manager = new WebServiceManager<IEnumerable<TEntity>>(DataConnectionResource.LOCALAPI);
                    manager.Delete(items);
                });
            }
            return items;
        }
    }
        
    
}
