using Absence.Model;
using Absence.Model.SQLite;
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

namespace Absence.View
{
    /// <summary>
    /// Logique d'interaction pour ViewPersonne.xaml
    /// </summary>
    public partial class ViewPersonne : Window
    {
        private OPersonne personne;

        ObservableCollection<AbsenceViewer> absences = new ObservableCollection<AbsenceViewer>();
        public ViewPersonne(OPersonne personne)
        {
            InitializeComponent();
            this.personne = personne;
            this.TxtNom.Text = this.personne.nom;
            this.TxtPrenom.Text = this.personne.prenom;

            List<OAbsence> lsAbsence = DAOFactory.getDAOAbsence().getAllByReference(personne).ToList();
            lsAbsence.ForEach(delegate (OAbsence abs)
            {
                absences.Add(new AbsenceViewer(abs, DAOFactory.getDAOTypeAbsence().GetById(abs.idTypeAbsence)));
            });

            lvAbsence.ItemsSource = absences;

        }

        private void New_Click_Menu(object sender, RoutedEventArgs e)
        {
            VWAbsence fenetre = new VWAbsence(this.personne, this.absences);
            fenetre.ShowDialog();
        }

        private void open_absence_click(object sender, MouseButtonEventArgs e)
        {
            AbsenceViewer item = (AbsenceViewer)((ListView)sender).SelectedItem;
            if (item != null)
            {
                VWAbsence fenetre = new VWAbsence(this.personne, this.absences, item);
                fenetre.ShowDialog();
            }
        }
    }
    public class AbsenceViewer
    {
        private OAbsence absence;
        private OTypeAbsence typeAbs;

        public int idAbsence => absence.id;
        public string TypeAbs => typeAbs.typeAbsence;
        public string Motif => absence.motif;
        public string DDebut => absence.dateDebut.ToString();
        public string DFin => absence.dateFin.ToString();
        public bool Prolongation => absence.prolongation;

        public AbsenceViewer(OAbsence absence, OTypeAbsence type)
        {
            this.absence = absence;
            this.typeAbs = type;
        }

    }
}
