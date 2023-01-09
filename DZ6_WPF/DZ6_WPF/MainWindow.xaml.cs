using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
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

namespace DZ6_WPF
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            weapon.Add(new DesertEagle("Пистолет", "Desert Eagle", "23.000 руб", "20-30 в/м", "7 пт", "2.05 кг"));
            weapon.Add(new Glock17("Пистолет", "Glock17", "19.000 руб", "80-100 в/м", "33 пт", "6.25 кг"));
            weapon.Add(new P90("ПП", "P90", "30.000 руб", "900-1000 в/м", "150 пт", "10 кг"));
            weapon.Add(new GepardM1("Винтовка", "Gepard M1", "75.000 руб", "8-10 в/м", "8 пт", "8.25 кг"));
            weapon.Add(new KelTec("Дробовик", "KelTec", "140.000", "120 в/м", "15 пт", "9 кг"));

            LoadWeapon(weapon);
  
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(animalList.ItemsSource);
            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));


        }
        public List<Weapon> weapon = new List<Weapon>();
       
        public void LoadWeapon(List<Weapon> _weapon)
        {
            weaponlList.Items.Clear();
            for (int i = 0; i < _weapon.Count; i++)
            {
                weaponlList.Items.Add(_weapon[i]);
            }

        }

        private void ActiveFilter(object sender, RoutedEventArgs e)
        {
            List<Weapon> newWeapon = new List<Weapon>();
            newWeapon = weapon;
            if (typeFilter.SelectedIndex == 0)
                newWeapon = weapon.FindAll(x => x.Type == "Пистолет");
            else if (typeFilter.SelectedIndex == 1)
                newWeapon = weapon.FindAll(x => x.Type == "ПП");
            else if (typeFilter.SelectedIndex == 2)
                newWeapon = weapon.FindAll(x => x.Type == "Винтовка");
            else if (typeFilter.SelectedIndex == 3)
                newWeapon = weapon.FindAll(x => x.Type == "Дробовик");
            LoadWeapon(newWeapon);

            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(animalList.ItemsSource);
            //view.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Ascending));
        }     
    }
    public abstract class Weapon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Rof { get; set; }
        public string Ss { get; set; }
        public string Weight { get; set; }


    }
    class Pistols : Weapon { }
    class Pp : Weapon { }
    class Rifle : Weapon { }
    class Shotguns : Weapon { }

    class DesertEagle : Pistols
    {  
       
    public DesertEagle(string _Type, string _Name, string _Rof, string _Price, string _Ss, string _Weight)
        {
            this.Price = _Price; this.Rof = _Rof; this.Ss = _Ss; this.Weight = _Weight; this.Type = _Type; this.Name = _Name; 
        }
    }
    class Glock17 : Pistols
    {
        public Glock17(string _Type, string _Name, string _Rof, string _Price, string _Ss, string _Weight)
        {
            this.Price = _Price; this.Rof = _Rof; this.Ss = _Ss; this.Weight = _Weight; this.Type = _Type; this.Name = _Name;
        }
    }

    class P90 : Pp
    {

        public P90(string _Type, string _Name, string _Rof, string _Price, string _Ss, string _Weight)
        {
            this.Price = _Price; this.Rof = _Rof; this.Ss = _Ss; this.Weight = _Weight; this.Type = _Type; this.Name = _Name;
        }
    }
    class GepardM1 : Rifle
    {
        public GepardM1(string _Type, string _Name, string _Rof, string _Price, string _Ss, string _Weight)
        {
            this.Price = _Price; this.Rof = _Rof; this.Ss = _Ss; this.Weight = _Weight; this.Type = _Type; this.Name = _Name;
        }
    }
    class KelTec : Shotguns
    {
        public KelTec(string _Type, string _Name, string _Rof, string _Price, string _Ss, string _Weight)
        {
            this.Price = _Price; this.Rof = _Rof; this.Ss = _Ss; this.Weight = _Weight; this.Type = _Type; this.Name = _Name;
        }
    }
   

}
