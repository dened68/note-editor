using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Serialization;

namespace redzam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Note> notes = new List<Note>(2);
        List<GroupBox> nots = new List<GroupBox>();
        XmlSerializer ser = new XmlSerializer(typeof(List<Note>));

        public MainWindow()
        {
            InitializeComponent();

            loadNotes();
            
            nots = Fillnots(notes, nots);
            notelist.ItemsSource = nots;
            


            //notelist.ContextMenu.Items.Add(new[] {DeleteNotes_Click() })
            

        } 

        
        
        public List<GroupBox> Fillnots(List<Note> notes, List<GroupBox> nots)
        {
            for(int i = 0; i < notes.Count(); i++ )
            {
                
                GroupBox not = new GroupBox();
                not.Header = notes[i].GetName() + notes[i].GetCreationDate();
                not.Content = notes[i].GetContent();
                not.Width = 297;
                not.Height = 79;
                not.MouseDoubleClick += GroupBox_MouseDoubleClick;
                nots.Add(not);
               
                
            }
            return (nots);
        }

        public void Deletenote()
        {

        }

        public void Savenotes()
        {
            FileStream file = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            ser.Serialize(file, notes);
            file.Close();
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            notes.Clear();
            throw new NotImplementedException();
            
        }       

        public void loadNotes()
        {
             FileStream file = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
             notes = (List<Note>)ser.Deserialize(file);

             file.Close();
        }

        private void notecreate()
        {
            Note note = new Note();
            note.SetCreationDate(DateTime.Now.ToString());
            notes.Add(note);
            //GroupBox not = new GroupBox();
            //not.Header = note.GetName() + note.GetCreationDate();
            //not.Content = note.GetContent();
            //not.Width = 297;
            //not.Height = 79;
            //nots.Add(not);
            Savenotes();
        }

        

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            notecreate();           
        }

        private void note_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GroupBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit edit = new Edit();
            edit.Show();
            
            
        }
    }
}
