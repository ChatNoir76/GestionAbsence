using Absence.Model;
using Absence.Model.SQLite;
using Absence.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Absence
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ViewListObject> usersList = new ObservableCollection<ViewListObject>();

        public MainWindow()
        {
            InitializeComponent();

            DAOFactory.getDAOPersonne().GetAll().ForEach(p =>
            {
                usersList.Add(new ViewListObject(p, DAOFactory.getDAOAbsence().getAllByReference(p).ToList()));
            });

            lvPersonne.ItemsSource = usersList;


        }

        private void New_Click_Menu(object sender, RoutedEventArgs e)
        {
            NewPersonne fenetre = new View.NewPersonne(usersList);
            fenetre.ShowDialog();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ViewListObject item = (ViewListObject) ((ListView) sender).SelectedItem;
            if (item != null)
            {
                ViewPersonne fenetre = new ViewPersonne(item.personne);
                fenetre.ShowDialog();
            }
        }
    }

    /// <summary>
    /// Classe permettant l'affichage des données dans la viewlist
    /// </summary>
    public class ViewListObject
    {
        public OPersonne personne;
        public List<OAbsence> absences;

        public string Nom => personne.nom;
        public string Prenom => personne.prenom;
        public int AbsenceNombre => absences.Count;

        public ViewListObject(OPersonne personne, List<OAbsence> absences)
        {
            this.personne = personne;
            this.absences = absences;
        }

        public ViewListObject(OPersonne personne)
        {
            this.personne = personne;
            this.absences = new List<OAbsence>();
        }

        public override bool Equals(object obj)
        {
            return obj is ViewListObject @object &&
                   Nom == @object.Nom &&
                   Prenom == @object.Prenom;
        }

        public override int GetHashCode()
        {
            int hashCode = 1399261157;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Prenom);
            return hashCode;
        }
    }
}
