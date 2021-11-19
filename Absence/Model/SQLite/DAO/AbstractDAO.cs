using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Absence.Model.DAO
{
    abstract class AbstractDAO
    {

        private const int NO_ID = -1;
        private const string LAST_ROW_ID = ";select last_insert_rowid()";
        /// <summary>
        /// Exécute une requête et retourne l'ID d'enregistrement
        /// </summary>
        /// <param name="Request">Requête Create</param>
        /// <param name="ParamList">Liste des paramètres</param>
        /// <returns>ID du nouvel enregistrement</returns>
        protected int ExecuteScalar(string Request, params SQLiteParameter[] ParamList)
        {

            int id = NO_ID;
            using (SQLiteTransaction tr = Singleton.eInstance().Connexion.BeginTransaction())
            {
                using (SQLiteCommand requete = new SQLiteCommand()){
                    try
                    {
                        requete.Transaction = tr;
                        requete.CommandText = Request + LAST_ROW_ID;
                        requete.Parameters.AddRange(ParamList);
                        requete.Prepare();
                        Console.WriteLine(requete.CommandText);
                        id = Convert.ToInt32(requete.ExecuteScalar());
                        tr.Commit();
                        return id;
                    }
                    catch(Exception e)
                    {
                        tr.Rollback();
                        throw new Exception("ExecuteScalar request has failed", e);
                    }
                }
            }
        }
        /// <summary>
        /// Exécute la requête et retour un jeu de résultat
        /// </summary>
        /// <param name="Request">Requête Get/Read </param>
        /// <param name="ParamList">Liste des paramètres</param>
        /// <returns>Le reader du jeu de résultat</returns>
        protected SQLiteDataReader ExecuteReader(string Request, params SQLiteParameter[] ParamList)
        {
            using (SQLiteCommand requete = new SQLiteCommand(Request, Singleton.eInstance().Connexion))
            {
                try
                {
                    if (ParamList.Length > 0) {
                        requete.Parameters.AddRange(ParamList);
                    }
                    requete.Prepare();
                    SQLiteDataReader reader = requete.ExecuteReader();
                    return reader;
                }
                catch (Exception e)
                {
                    throw new Exception("ExecuteReader request has failed", e);
                }
            }
        }
        /// <summary>
        /// Exécution d'une instruction SQL par rapport à un objet de connexion
        /// </summary>
        /// <param name="Request">Requête Update ou Delete</param>
        /// <param name="ParamList">Liste des paramètres</param>
        /// <returns>Le nombre de lignes impactées</returns>
        protected int ExecuteNonQuery(string Request, params SQLiteParameter[] ParamList)
        {
            int lignes = NO_ID;

            using (SQLiteTransaction tr = Singleton.eInstance().Connexion.BeginTransaction())
            {
                using (SQLiteCommand requete = new SQLiteCommand())
                {

                    try
                    {
                        requete.Transaction = tr;
                        requete.CommandText = Request;
                        requete.Parameters.AddRange(ParamList);
                        requete.Prepare();
                        lignes = requete.ExecuteNonQuery();
                        tr.Commit();
                        return lignes;
                    }
                    catch (Exception e)
                    {
                        tr.Rollback();
                        throw new Exception("ExecuteNonQuery request has failed", e);
                    }
                }
            }
        }
    }
}
