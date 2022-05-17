using System.Diagnostics;
using System.IO;
using MaterialSkin;
using MintPlayer.PlatformBrowser;

namespace PCleaner
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public string[] defaultSettings = { "tutorial = false", "more settings coming soon" };
        public string[] loadedSettings;

        public bool clearCache = true;
        public Form1()
        {

            var browsers = PlatformBrowser.GetInstalledBrowsers();
            foreach (var browser in browsers)
            {
                string brwsrName = browser.Name;
                string brwsrExec = browser.ExecutablePath;
                string brwsrIcPath = browser.IconPath;
                string brwsrIcIndex = browser.IconIndex.ToString();
                Directory.CreateDirectory(Environment.CurrentDirectory + "/temp/");
                File.Create(Environment.CurrentDirectory + "/temp/" + browser.Name + ".txt").Close();
                File.WriteAllText(Environment.CurrentDirectory + "/temp/" + browser.Name + ".txt", brwsrName + "\n" + brwsrExec + "\n" + brwsrIcPath + "\n" + brwsrIcIndex);
            }
            InitializeComponent();

            if (!File.Exists(@Environment.CurrentDirectory + "/settings.txt"))
            {
                File.Create(@Environment.CurrentDirectory + "/settings.txt").Close();
                File.WriteAllLines(@Environment.CurrentDirectory + "/settings.txt", defaultSettings);
                loadedSettings = File.ReadAllLines(@Environment.CurrentDirectory + "/settings.txt");
            }
            else
            {
                loadedSettings = File.ReadAllLines(@Environment.CurrentDirectory + "/settings.txt");
            }

            // tutorial thing coming sometime when i have the main functions done
            //
            // if (loadedSettings[0] == "tutorial = false")
            // {
            //     Tutorial tutorial = new Tutorial();
            //     tutorial.Show();
            // } else if(loadedSettings[0] == "tutorial = true")
            // {
            //
            //}


        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            CleanPC();
        }

        public void CleanPC()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }
        }

        private void stuffLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mmgproxy/PCleaner");
        }
    }
}