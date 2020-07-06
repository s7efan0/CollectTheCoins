using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ProZad
{
    public partial class MainMenu : Form
    {
        public Dictionary<int, Button> levelUnlock;
        public List<int> levelCompldeted;
        String saveName = null;

        public MainMenu()
        {
            InitializeComponent();
            levelUnlock = new Dictionary<int, Button>();
            levelCompldeted = new List<int>();
            levelUnlock.Add(0, button2);
            levelUnlock.Add(1, null);
        }

        private void updateLevel()
        {
            foreach(int i in levelCompldeted)
            {
                Button btn;
                if (levelUnlock.TryGetValue(i, out btn))
                {
                    if (btn != null && !btn.Enabled)
                    {
                        btn.Enabled = true;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this, 0);
            f.Show();
            this.Hide();
        }

        public void goBackToMainMenu(Form f, bool completed, int lvl)
        {
            this.Show();
            f.Dispose();
            f.Close();
            if (completed && !levelCompldeted.Contains(lvl))
            {
                levelCompldeted.Add(lvl);
                updateLevel();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(this, 1);
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (saveName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Game file (*.game)|*.game";
                saveFileDialog.Title = "Save Game";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveName = saveFileDialog.FileName;
                }
            }
            if (saveName != null)
            {
                IFormatter formatter = new BinaryFormatter();
                FileStream fileStream = new FileStream(saveName, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(fileStream, levelCompldeted);
                fileStream.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Game file (*.game)|*.game";
            openFileDialog.Title = "Save Game";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    saveName = openFileDialog.FileName;
                    FileStream fileStream = new FileStream(saveName, FileMode.Open, FileAccess.Read, FileShare.None);
                    clearLevels();
                    levelCompldeted = (List<int>)formatter.Deserialize(fileStream);
                    fileStream.Close();
                    this.updateLevel();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    saveName = null;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clearLevels();
            saveName = null;
        }

        private void clearLevels()
        {
            levelCompldeted.Clear();
            levelUnlock.Values.ToList().ForEach(btn => { if (btn != null) { btn.Enabled = false; } });
        }
    }
}
