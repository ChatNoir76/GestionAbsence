using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Absence.Model.DAO
{

    public sealed class Singleton
    {
        private static Singleton _instance;

        public static Singleton eInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        private SQLiteConnection _connexion;

        public SQLiteConnection Connexion { get => _connexion; }

        private Singleton()
        {
            SQLiteConnectionStringBuilder strBuilder = new SQLiteConnectionStringBuilder();
            strBuilder.DataSource = "source/absence.db3";
            strBuilder.Version = 3;
            strBuilder.ForeignKeys = false;

            _connexion = new SQLiteConnection(strBuilder.ConnectionString, true);
            _connexion.Open();
        }

    }

    
}
