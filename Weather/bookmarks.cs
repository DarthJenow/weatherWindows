using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather
{
    public partial class bookmarks : Form
    {
        public bookmarks()
        {
            InitializeComponent();

            // loads the settings into the listBox
            /*
            foreach (String element in Properties.Settings.Default.cityIDBookmarks)
            {
                listBoxCityIDBookmarks.Items.Add(element);
            }
            */

            for (int i = 0; i < Properties.Settings.Default.cityIDBookmarks.Count; i++)
            {
                listBoxCityIDBookmarks.Items.Add(Properties.Settings.Default.cityIDBookmarks[i]);
            }

            // selects the current active city in the list
            try
            {
                listBoxCityIDBookmarks.SetSelected(listBoxCityIDBookmarks.FindString(Properties.Settings.Default.cityID), true);
            }
            catch (Exception ex)
            {

            }
            
        }

        /// <summary>
        /// Presses the add-city-button if the textbox is focused and enter gets pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCityID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) ConsoleKey.Enter)
            {
                buttonAddCityID_Click(null, null);

                e.Handled = true;
            }
        }

        /// <summary>
        /// If an entry gets doubleclicked, it sets it as the active city for the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCityIDBookmarks_DoubleClick(object sender, EventArgs e)
        {
            Properties.Settings.Default.cityID = listBoxCityIDBookmarks.SelectedItem.ToString();
        }

        /// <summary>
        /// saves the datas if the form gets closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.cityIDBookmarks.Clear();

            foreach (String element in listBoxCityIDBookmarks.Items)
            {
                Properties.Settings.Default.cityIDBookmarks.Add(element);
            }

            Properties.Settings.Default.Save();

            // reloads the data in the main form
            if (System.Windows.Forms.Application.OpenForms["main"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["main"] as main).read();
                (System.Windows.Forms.Application.OpenForms["main"] as main).show();
            }
        }

        /// <summary>
        /// adds the city-it in the textbox to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddCityID_Click(object sender, EventArgs e)
        {
            String newEntry = textBoxName.Text + " (" + textBoxCityID.Text + ")";

            if (!listBoxCityIDBookmarks.Items.Contains(newEntry)) // checks if the entered city-id is already in the list
            {
                listBoxCityIDBookmarks.Items.Add(newEntry);

                listBoxCityIDBookmarks.SetSelected(listBoxCityIDBookmarks.FindString(newEntry), true); // selects the new added city-id
            }

            // clear the textboxes
            textBoxName.Text = "";
            textBoxCityID.Text = "";
        }

        /// <summary>
        /// if executed, it deletes the selected item in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCityIDBookmarks.SelectedItem.ToString() == Properties.Settings.Default.cityID)
            {
                MessageBox.Show("You can't delete the selected location.", "Can't delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                listBoxCityIDBookmarks.Items.RemoveAt(listBoxCityIDBookmarks.SelectedIndex); // deletes the selected item

                listBoxCityIDBookmarks.SetSelected(listBoxCityIDBookmarks.FindString(Properties.Settings.Default.cityID), true); // selects the active city id in the box
            }
        }

         /// <summary>
         /// If enter gets pressed, it sets the selected entry as active (like a doubleklick)
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void listBoxCityIDBookmarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                listBoxCityIDBookmarks_DoubleClick(null, null);

                e.Handled = true; // disable error sound
            }
        }

        /// <summary>
        /// Presses the add-city-button if the textbox is focused and enter gets pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                buttonAddCityID_Click(null, null);

                e.Handled = true;
            }
        }
    }
}
