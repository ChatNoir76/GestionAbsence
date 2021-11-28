using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Absence.Model;
using Absence.Model.SQLite;

namespace Absence.View
{
    /// <summary>
    /// Logique d'interaction pour VWAbsence.xaml
    /// </summary>
    public partial class VWAbsence : Window
    {
        private ObservableCollection<AbsenceViewer> absences; //list de la list view parent
        private OPersonne personne; //personne ayant des absences
        private AbsenceViewer absViewer; //AbsenceViewer lié à la personne (null si nouvelle absence)
        private List<OTypeAbsence> typeAbsList; //liste des type absence de la bdd
        private bool isNew; //nouvelle absence ou non

        public VWAbsence(OPersonne personne, ObservableCollection<AbsenceViewer> absences, AbsenceViewer absViewer = null)
        {
            InitializeComponent();

            //intialisation des variables
            this.personne = personne;
            this.absences = absences;
            this.absViewer = absViewer;
            this.isNew = absViewer == null;

            

            //initialisation de la combobox type absence
            typeAbsList = DAOFactory.getDAOTypeAbsence().GetAll();
            CBTypeAbsence.ItemsSource = typeAbsList;

            this.remplissageInfoAbsence();

        }
        /// <summary>
        /// Remplissage des infos de l'absence dans les champs du formulaire
        /// </summary>
        private void remplissageInfoAbsence()
        {
            if (absViewer != null)
            {
                this.CBTypeAbsence.SelectedIndex = absViewer.idTypeAbsence - 1;
                this.TxtMotif.Text = absViewer.Motif;
                this.TxtDateDebut.Text = absViewer.DDebut;
                this.TxtDateFin.Text = absViewer.DFin;
                this.CHKProlongation.IsChecked = absViewer.Prolongation;
            }
        }

        private void BT_Enregistrer(object sender, RoutedEventArgs e)
        {
            //index de la combobox type absence
            int index = CBTypeAbsence.SelectedIndex;
            if (isNew)
            {
                //nouvelle absence
                OAbsence abs = new OAbsence(TxtMotif.Text, TxtDateDebut.Text, TxtDateFin.Text, CHKProlongation.IsChecked == true, personne.id, index + 1);
                this.absViewer = new AbsenceViewer(abs, typeAbsList[index]);
                this.isNew = false;
                this.absences.Add(absViewer);
                DAOFactory.getDAOAbsence().Insert(abs);
            }
            else
            {
                //modification absence
                OAbsence abs = new OAbsence(TxtMotif.Text, TxtDateDebut.Text, TxtDateFin.Text, CHKProlongation.IsChecked == true, personne.id, index + 1, this.absViewer.idAbsence);
                this.absViewer = new AbsenceViewer(abs, typeAbsList[index]);
                DAOFactory.getDAOAbsence().Update(abs);
            }
            this.Close();
        }
    }
}
