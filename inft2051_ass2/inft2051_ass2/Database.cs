using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Linq;


namespace inft2051_ass2
{
    //creat database class
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //creat two table, city and attraction
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<city>().Wait();
            _database.CreateTableAsync<Attraction>().Wait();
        }

        //read city
        public Task<List<city>> GetCityAsync()
        {
            return _database.Table<city>().ToListAsync();
        }

        //write city
        public Task<int> SaveCityAsync(city city)
        {
            return _database.InsertAsync(city);
        }

        //read attraction
        public Task<List<Attraction>> GetAttractionAsync(int city_id)
        {
            return _database.Table<Attraction>().Where(o => o.belong_to_city.Equals(city_id)).ToListAsync();
        }

        //write attraction
        public Task<int> SaveAttractionAsync(Attraction attraction)
        {
            return _database.InsertAsync(attraction);
        }
    }
}

