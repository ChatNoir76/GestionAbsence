using Absence.Core;
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
    /// Logique d'interaction pour NewPersonne.xaml
    /// </summary>
    public partial class NewPersonne : Window
    {
        private ObservableCollection<ViewListObject> usersList;

        public NewPersonne(ObservableCollection<ViewListObject> usersList)
        {
            InitializeComponent();
            this.usersList = usersList;
        }

        private void Ajouter_Button_Click(object sender, RoutedEventArgs e)
        {
            
            OPersonne personne = ObjectFactory.eInstance().createPersonne(TxtNom.Text, TxtPrenom.Text);
            ViewListObject o = ObjectFactory.eInstance().createViewListObject(personne);
            if (!usersList.Contains(o))
            {
                usersList.Add(o);
                DAOFactory.getDAOPersonne().Insert(personne);
            }
            TxtNom.Text = "";
            TxtPrenom.Text = "";
        }
    }
}
