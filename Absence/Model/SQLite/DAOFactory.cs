using Absence.Model.SQLite.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model.SQLite
{
    class DAOFactory
    {

        public static DAOPersonne getDAOPersonne()
        {
            return new DAOPersonne();
        }

        public static DAOAbsence getDAOAbsence()
        {
            return new DAOAbsence();
        }

        public static DAOTypeAbsence getDAOTypeAbsence()
        {
            return new DAOTypeAbsence();
        }
    }
}
