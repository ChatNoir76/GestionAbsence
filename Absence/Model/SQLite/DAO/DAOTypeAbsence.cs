using Absence.Model.DAO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model.SQLite.DAO
{
    class DAOTypeAbsence : AbstractDAO, IDAO_Table<OTypeAbsence>
    {
        private const string R_GETBYID = "select * from TypeAbsence WHERE id_typeabsence=?";
        private const string R_GETBYALL = "select * from TypeAbsence";
        private const string R_DELETE = "DELETE FROM TypeAbsence WHERE id_typeabsence=?";
        private const string R_UPDATE = "UPDATE TypeAbsence SET nom_typeabsence=? WHERE id_typeabsence=?";
        private const string R_INSERT = "INSERT INTO TypeAbsence values (null,?)";

        public bool Delete(OTypeAbsence value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.id;
            int ligne = this.ExecuteNonQuery(R_DELETE, p1);
            return ligne != 0;
        }

        public List<OTypeAbsence> GetAll()
        {
            List<OTypeAbsence> liste = new List<OTypeAbsence>();
            using (SQLiteDataReader reader = this.ExecuteReader(R_GETBYALL))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        liste.Add(GetObjectFromReader(reader));
                    }
                }
                return liste;
            }
        }

        public OTypeAbsence GetById(int id)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = id;
            using (SQLiteDataReader reader = this.ExecuteReader(R_GETBYID, p1))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        return GetObjectFromReader(reader);
                    }
                }
            }
            return null;
        }

        public OTypeAbsence GetObjectFromReader(SQLiteDataReader value)
        {
            return new OTypeAbsence(value.GetString(0), value.GetInt32(1));
        }

        public void Insert(OTypeAbsence value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.typeAbsence;
            this.ExecuteScalar(R_INSERT, p1);
        }

        public void Update(OTypeAbsence value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.typeAbsence;
            SQLiteParameter p2 = new SQLiteParameter();
            p2.Value = value.id;
            this.ExecuteNonQuery(R_UPDATE, p1, p2);
        }
    }
}
