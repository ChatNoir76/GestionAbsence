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
        ObservableCollection<AbsenceViewer> absences = new ObservableCollection<AbsenceViewer>();
        public ViewPersonne(OPersonne personne)
        {
            InitializeComponent();
            List<OAbsence> lsAbsence = DAOFactory.getDAOAbsence().getAllByReference(personne).ToList();
            lsAbsence.ForEach(delegate (OAbsence abs)
            {
                absences.Add(new AbsenceViewer(abs, DAOFactory.getDAOTypeAbsence().GetById(abs.idTypeAbsence)));
            });

            lvAbsence.ItemsSource = absences;

        }

        private void New_Click_Menu(object sender, RoutedEventArgs e)
        {
            ViewListObject item = (ViewListObject)((ListView)sender).SelectedItem;
            if (item != null)
            {
                MessageBox.Show("Item's Double Click handled!");
            }
        }
    }
    public class AbsenceViewer
    {
        private OAbsence absence;
        private OTypeAbsence typeAbs;

        public string TypeAbs => typeAbs.typeAbsence;
        public string Motif => absence.motif;
        public string DDebut => absence.dateDebut.ToString();
        public string DFin => absence.dateFin.ToString();
        public string Prolongation => absence.prolongation.ToString();

        public AbsenceViewer(OAbsence absence, OTypeAbsence type)
        {
            this.absence = absence;
            this.typeAbs = type;
        }

    }
}
