using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Win7_Plus_StackBy
{
    public partial class StackbyGen : Form
    {

        public StackbyGen(string path = null)
        {
            InitializeComponent();
            List<Property> prop = PropertyReciver.RecivePropertys(PropertyReciver.PROPDESC_ENUMFILTER.PDEF_VIEWABLE);
            prop.Where(p => p.IsVisible && p.IsStackable).ToList();
            comboBoxPropertys.DataSource = prop;

            if (!string.IsNullOrEmpty(path))
            {
                textBoxSelectedFolder.Text = path;
                textBoxSelectedFolder.ReadOnly = true;
                buttonSelectFolder.Enabled = false;
            }

            else
            {
                textBoxSelectedFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }




        }

        private void textBoxSelectedFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                dialog.Title = "Select a folder";
                dialog.InitialDirectory = textBoxSelectedFolder.Text;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    textBoxSelectedFolder.Text = dialog.FileName;

                }
            }

        }

        private void buttonGenerateSearchMS_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBoxSelectedFolder.Text))
            {


                saveFileDialog1.Filter = "Saved Search (*.search-ms)|*.search-ms|XML Files (*.xml)|*.xml|All files (*.*)|*.*";
                saveFileDialog1.InitialDirectory = textBoxSelectedFolder.Text;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        SearchQuerySaver sq = new SearchQuerySaver(Path.GetDirectoryName(saveFileDialog1.FileName), (Property)comboBoxPropertys.SelectedItem);
                        if (!File.Exists(saveFileDialog1.FileName))
                            File.Create(saveFileDialog1.FileName).Close();

                        File.WriteAllText(saveFileDialog1.FileName, sq.ToString());

                        Application.Exit();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }

                else if (String.IsNullOrEmpty(textBoxSelectedFolder.Text))
                {
                    MessageBox.Show("No Path selected");
                }

                else
                {
                    MessageBox.Show("Path does not exist");
                }
            }
        }

    }
}
