using Absence.Model.DAO;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Model.SQLite.DAO
{
    class DAOAbsence : AbstractDAO, IDAO_Table<OAbsence>
    {
        private const string R_GETBYID = "select * from Absence where id_absence=?";
        private const string R_GETALLBYREF = "select * from Absence where id_personne=?";
        private const string R_GETBYALL = "select * from Absence";
        private const string R_DELETE = "DELETE FROM Absence WHERE id_absence=?";
        private const string R_UPDATE = "UPDATE Absence SET motif_absence=?, date_debut_absence=?, date_fin_absence=?, prolongation_absence=?, id_personne=?, id_typeabsence=? WHERE id_absence=?";
        private const string R_INSERT = "INSERT INTO Absence VALUES (null, ?, ?, ?, ?, ?, ?)";

        public bool Delete(OAbsence value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.id;
            int ligne = this.ExecuteNonQuery(R_DELETE, p1);
            return ligne != 0;
        }

        public List<OAbsence> GetAll()
        {
            List<OAbsence> liste = new List<OAbsence>();
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

        public OAbsence[] getAllByReference(OPersonne valueA)
        {
            List<OAbsence> liste = new List<OAbsence>();
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = valueA.id;
            using (SQLiteDataReader reader = this.ExecuteReader(R_GETALLBYREF, p1))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        liste.Add(GetObjectFromReader(reader));
                    }
                }
            }
            return liste.ToArray();
        }

        public OAbsence GetById(int id)
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

        public OAbsence GetObjectFromReader(SQLiteDataReader value)
        {
            return new OAbsence(value.GetString(1), value.GetDateTime(2), value.GetDateTime(3), value.GetBoolean(4), value.GetInt32(5), value.GetInt32(6), value.GetInt32(0));
        }

        public void Insert(OAbsence value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.motif;
            SQLiteParameter p2 = new SQLiteParameter();
            p2.Value = value.dateDebut.ToString();
            SQLiteParameter p3 = new SQLiteParameter();
            p3.Value = value.dateFin.ToString();
            SQLiteParameter p4 = new SQLiteParameter();
            p4.Value = value.prolongation;
            SQLiteParameter p5 = new SQLiteParameter();
            p5.Value = value.idPersonne;
            SQLiteParameter p6 = new SQLiteParameter();
            p6.Value = value.idAbsence;
            value.id = this.ExecuteScalar(R_INSERT, p1, p2, p3, p4, p5, p6);
        }

        public void Update(OAbsence value)
        {
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = value.motif;
            SQLiteParameter p2 = new SQLiteParameter();
            p2.Value = value.dateDebut.ToString();
            SQLiteParameter p3 = new SQLiteParameter();
            p3.Value = value.dateFin.ToString();
            SQLiteParameter p4 = new SQLiteParameter();
            p4.Value = value.prolongation;
            SQLiteParameter p5 = new SQLiteParameter();
            p5.Value = value.idPersonne;
            SQLiteParameter p6 = new SQLiteParameter();
            p6.Value = value.idAbsence;
            SQLiteParameter p7 = new SQLiteParameter();
            p7.Value = value.id;
            this.ExecuteNonQuery(R_UPDATE, p1, p2, p3, p4, p5, p6, p7);
        }
    }
}
