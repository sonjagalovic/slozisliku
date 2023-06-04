using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace SloziSliku_29_2019
{
    public partial class Form1 : Form
    {
        private PuzzleDB db;
        private Stopwatch stoperica;
        public int razmakGore, razmakDole, razmakLevo, razmakDesno; //od mreze do ivica forme
        public int debljinaLinije;
        public static int brKolona = 5;
        public static int brRedova = 4;
        public int x, y; //dimenzije polja (slicica)
        public int ukupnoPoteza = 0;
        Color bojaLinije;
        public int granicaGore, granicaDole, granicaLevo, granicaDesno;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        public Image slika;
        public int nasumicno;
        public PictureBox pbDragPocetak;
        public static ListView listViewRezultati;
        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
            ucitajBazu();
            init();
        }
        private void ucitajBazu()
        {
            db = new PuzzleDB();
        }
        private void init()
        {
            razmakLevo = razmakGore = razmakDole = 40;
            razmakDesno = 110;
            debljinaLinije = 1;
            bojaLinije = Color.Black;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblUkupnoPoteza.Text = ukupnoPoteza.ToString(); //pri ucitavanju forme, broj poteza = 0
            btnNovaIgra.Cursor = Cursors.No;
            stoperica = new Stopwatch();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblVreme.Text = string.Format("{0:hh\\:mm\\:ss}", stoperica.Elapsed);
        }

        private void btnUcitaj_Click(object sender, EventArgs e) //ucitavanje slike
        {
            ucitajSliku();
        }
        private void ucitajSliku()
        {
            OpenFileDialog dijalog = new OpenFileDialog();

            dijalog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";

            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                stoperica.Reset();
                btnNovaIgra.Cursor = Cursors.Default;

                if (slika != null) //vec je bilo ucitano nesto, brisi sve tragove
                    ocistiSvaPolja();

                Image image = Image.FromFile(dijalog.FileName);

                slika = skalirajSliku(image, x, y);

                lblNazivSlike.Text = Path.GetFileName(dijalog.FileName);

                podeliSlikuIPrikazi();

                this.Refresh();
            }
        }
        private void ocistiSvaPolja()
        {
            List<Control> kontroleKojeSuPB = new List<Control>();

            foreach (Control control in this.Controls) //od svih kontrola koje Form1 ima, spakuj u listu samo PictureBox-eve
            {
                if (control is PictureBox)
                    kontroleKojeSuPB.Add(control);
            }
            foreach (var kontrola in kontroleKojeSuPB)
            {
                this.Controls.Remove(kontrola); //ukloni iz kontrola one kontrole koje su PictureBox
            }

            pictureBoxes = new List<PictureBox>(); //pravi se nova lista

            this.Refresh();
        }
        public static Bitmap skalirajSliku(Image image, int x, int y)
        {
            var pravougaonik = new Rectangle(0, 0, x * brKolona, y * brRedova); //gde smestamo sliku

            var bitmapa = new Bitmap(x * brKolona, y * brRedova);

            bitmapa.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics graphics = Graphics.FromImage(bitmapa);
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            ImageAttributes atr = new ImageAttributes();
            atr.SetWrapMode(WrapMode.TileFlipXY);

            graphics.DrawImage(image, pravougaonik, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, atr);

            return bitmapa;
        }
        private void podeliSlikuIPrikazi()
        {
            int internoX = 0;
            int internoY = -slika.Height / brRedova;

            int leviPomeraj = razmakLevo + debljinaLinije;
            int gornjiPomeraj = razmakDole + debljinaLinije;

            for (int i = 0; i < brRedova; i++)
            {
                internoX = -slika.Width / brKolona;
                internoY += slika.Height / brRedova;

                for (int j = 0; j < brKolona; j++)
                {
                    internoX += slika.Width / brKolona;

                    int sirinaDelaSlike = 3 + slika.Width - internoX - brKolona * debljinaLinije;
                    int visinaDelaSlike = 3 + slika.Height - internoY - brRedova * debljinaLinije;

                    Bitmap bitmapa = new Bitmap(slika);
                    Bitmap isecenaBitmapa = bitmapa.Clone(new Rectangle(internoX, internoY, sirinaDelaSlike, visinaDelaSlike), bitmapa.PixelFormat);

                    Image deoSlike = isecenaBitmapa;

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = deoSlike;
                    pictureBox.Size = new Size(x - 2 * debljinaLinije, y - 2 * debljinaLinije);
                    pictureBox.Location = new Point(leviPomeraj, gornjiPomeraj);
                    pictureBox.MouseDoubleClick += new MouseEventHandler(PictureBox_MouseDoubleClick);
                    pictureBox.AllowDrop = true;
                    pictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
                    pictureBox.DragEnter += new DragEventHandler(PictureBox_DragEnter);
                    pictureBox.DragDrop += new DragEventHandler(PictureBox_DragDrop);

                    leviPomeraj += x;
                    
                    pictureBoxes.Add(pictureBox);
                    this.Controls.Add(pictureBox);
                }

                leviPomeraj = razmakLevo + debljinaLinije; //vrati ga na pocetak
                gornjiPomeraj += y; //predji u novi red
            }

            this.Refresh();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBoxes.FirstOrDefault(el => el.Image == null) != default(PictureBox))
            {
                if (e.Button == MouseButtons.Left)
                {
                    pbDragPocetak = (PictureBox)sender;
                    if (pbDragPocetak.Image != null)
                        pbDragPocetak.DoDragDrop(pbDragPocetak, DragDropEffects.Move);
                }
            }
        }
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox pbDragKraj = (PictureBox)sender;

            if (pbDragKraj.Image != null)
                return; //necemo da spustimo ako nije na praznu sliku

            int sirinaPB = x;
            int visinaPB = y;

            bool slaganjeUToku = false;
            foreach (var pb in pictureBoxes)
            {
                if (pb.Image == null)
                {
                    slaganjeUToku = true;
                    break;
                }
            }
            if (slaganjeUToku == false)
                return;

            if (pbDragPocetak.Location.X == pbDragKraj.Location.X)
            {
                if (pbDragPocetak.Location.Y == (pbDragKraj.Location.Y + visinaPB) || pbDragPocetak.Location.Y == (pbDragKraj.Location.Y - visinaPB))
                {
                    uvecajBrojPoteza();

                    Point pom = pbDragPocetak.Location;
                    pbDragPocetak.Location = pbDragKraj.Location;
                    pbDragKraj.Location = pom;

                    this.Refresh();

                    daLiJePobeda();
                }
            }
            else if (pbDragPocetak.Location.Y == pbDragKraj.Location.Y)
            {
                if (pbDragPocetak.Location.X == (pbDragKraj.Location.X + sirinaPB) || pbDragPocetak.Location.X == (pbDragKraj.Location.X - sirinaPB))
                {
                    uvecajBrojPoteza();

                    Point pom = pbDragPocetak.Location;
                    pbDragPocetak.Location = pbDragKraj.Location;
                    pbDragKraj.Location = pom;

                    this.Refresh();

                    daLiJePobeda();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(bojaLinije, debljinaLinije);

            Rectangle prozorForme = this.ClientRectangle;
            Graphics graphics = this.CreateGraphics();

            granicaGore = prozorForme.Y + razmakGore;
            granicaDole = prozorForme.Height - razmakDole;

            granicaLevo = prozorForme.X + razmakLevo;
            granicaDesno = prozorForme.Width - razmakDesno;

            x = (granicaDesno - granicaLevo) / brKolona;

            y = (granicaDole - granicaGore) / brRedova;

            granicaDesno = granicaLevo + brKolona * x;
            granicaDole = granicaGore + brRedova * y;

            int br = brRedova;
            if (brRedova < brKolona)
                br = brKolona;

            for (int i = 0; i <= br; i++) // <= br zato sto nam treba i za krajnju donju horizontalnu i krajnju desnu vertikalnu
            {
                // iscrtavanje jedne horizontalne linije matrice:
                e.Graphics.DrawLine(pen, new Point(granicaLevo, granicaGore + i * y), new Point(granicaDesno + debljinaLinije - 1, granicaGore + i * y)); //spaja od gornjeg levog ugla prve celije u redu do gornjeg desnog ugla poslednje celije u redu

                // iscrtavanje jedne vertikalne linije matrice:
                e.Graphics.DrawLine(pen, new Point(granicaLevo + i * x, granicaGore), new Point(granicaLevo + i * x, granicaDole + debljinaLinije - 1)); 
            }
        }

        private void btnBoja_Click(object sender, EventArgs e)
        {
            ColorDialog dijalog = new ColorDialog();

            if (dijalog.ShowDialog() == DialogResult.OK)
            {
                bojaLinije = dijalog.Color;
            }

            this.Refresh();
        }

        private void btnKraj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            if (slika != null) //nova igra moze da pocne tek nakon sto igrac izabere sliku koju ce da slaze
            {
                stoperica.Restart();

                ukupnoPoteza = 0;
                lblUkupnoPoteza.Text = ukupnoPoteza.ToString();

                ocistiSvaPolja();
                podeliSlikuIPrikazi();
                generisiRandomRaspored();
            }
        }
        private void generisiRandomRaspored()
        {
            List<Point> pocetneTacke = new List<Point>(); //lista koja sadrzi koordinate gornjeg levog ugla svakog pictureBoxa (pocetak svakog pba)

            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pocetneTacke.Add(pictureBox.Location); 
            }

            Random random = new Random();
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                int randomBroj = random.Next(0, pocetneTacke.Count); //za mat 3x3 => nasumican broj 0...8

                pictureBoxes[i].Location = pocetneTacke[randomBroj]; //pocetna tacka (gornji levi ugao) i-tog pba uzima vrednost ove random pocetne tacke

                pocetneTacke.RemoveAt(randomBroj); //uklanjamo tu random pocetnu tacku da ne dodje do ponavljanja slicica
            }

            nasumicno = random.Next(0, pictureBoxes.Count);
            pictureBoxes[nasumicno].Image = null;

            this.Refresh();
        }

        private void rbRed3_CheckedChanged(object sender, EventArgs e)
        {
            brRedova = 3;
            if (slika != null) //promenili smo broj vrsta, a slika je vec ucitana
            {
                stoperica.Reset();
                restartujBrojacPoteza(); // = 0
                ocistiSvaPolja();
                podeliSlikuIPrikazi();
            }
        }
        private void restartujBrojacPoteza()
        {
            ukupnoPoteza = 0;
            lblUkupnoPoteza.Text = ukupnoPoteza.ToString();
        }

        private void rbRed4_CheckedChanged(object sender, EventArgs e)
        {
            brRedova = 4;
            if (slika != null)
            {
                stoperica.Reset();
                restartujBrojacPoteza();
                ocistiSvaPolja();
                podeliSlikuIPrikazi();
            }
        }
        private void rbRed5_CheckedChanged(object sender, EventArgs e)
        {
            brRedova = 5;
            if (slika != null)
            {
                stoperica.Reset();
                restartujBrojacPoteza();
                ocistiSvaPolja();
                podeliSlikuIPrikazi();
            }
        }
        private void rbKolona3_CheckedChanged(object sender, EventArgs e)
        {
            brKolona = 3;
            if (slika != null)
            {
                stoperica.Reset();
                restartujBrojacPoteza();
                ocistiSvaPolja();
                podeliSlikuIPrikazi();
            }
        }
        private void rbKolona4_CheckedChanged(object sender, EventArgs e)
        {
            brKolona = 4;
            if (slika != null)
            {
                stoperica.Reset();
                restartujBrojacPoteza();
                ocistiSvaPolja();
                podeliSlikuIPrikazi();
            }
        }
        private void rbKolona5_CheckedChanged(object sender, EventArgs e)
        {
            brKolona = 5;
            if (slika != null)
            {
                stoperica.Reset();
                restartujBrojacPoteza();
                ocistiSvaPolja();
                podeliSlikuIPrikazi();
            }
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox kliknutoPolje = (PictureBox)sender; //polje na koje je duplo kliknuto

            int sirinaPB = x;
            int visinaPB = y;

            bool slaganjeUToku = false;
            foreach (var pb in pictureBoxes)
            {
                if (pb.Image == null)
                {
                    slaganjeUToku = true;
                    break;
                }
            }
            if (slaganjeUToku == false)
                return;

            if (pictureBoxes[nasumicno].Location.X == kliknutoPolje.Location.X)
            {
                if (pictureBoxes[nasumicno].Location.Y == (kliknutoPolje.Location.Y + visinaPB) || pictureBoxes[nasumicno].Location.Y == (kliknutoPolje.Location.Y - visinaPB))
                {
                    uvecajBrojPoteza();

                    Point pom = kliknutoPolje.Location;
                    kliknutoPolje.Location = pictureBoxes[nasumicno].Location;
                    pictureBoxes[nasumicno].Location = pom;

                    this.Refresh();

                    daLiJePobeda();
                }
            }
            else if (pictureBoxes[nasumicno].Location.Y == kliknutoPolje.Location.Y)
            {
                if (pictureBoxes[nasumicno].Location.X == (kliknutoPolje.Location.X + sirinaPB) || pictureBoxes[nasumicno].Location.X == (kliknutoPolje.Location.X - sirinaPB))
                {
                    uvecajBrojPoteza();

                    Point pom = kliknutoPolje.Location;
                    kliknutoPolje.Location = pictureBoxes[nasumicno].Location;
                    pictureBoxes[nasumicno].Location = pom;

                    this.Refresh();

                    daLiJePobeda();
                }
            }
        }
        private void uvecajBrojPoteza()
        {
            ukupnoPoteza++;

            lblUkupnoPoteza.Text = ukupnoPoteza.ToString();
        }
        private void daLiJePobeda()
        {
            for (int i = 0; i < pictureBoxes.Count - 1; i++) //lakse je da proverimo da li nije pobeda
                if (pictureBoxes[i].Location.Y > pictureBoxes[i + 1].Location.Y || (pictureBoxes[i].Location.X > pictureBoxes[i + 1].Location.X && pictureBoxes[i].Location.Y == pictureBoxes[i + 1].Location.Y))
                    return;
            /* 
              * Nije kraj igre ako treba ako:
              * I slucaj:
              *  a) Slike jesu u istom redu, slika koja ima manje i (treba da ide pre) ima vecu Y koordinatu, sto je nemoguce jer Y koordinate treba da budu jednake za obe slike.
              *  b) Slike nisu u istim redovima. Posto Y koordinata treba da raste kako se prelazi u novi red, nije dobro ako ova prva slika ima vece Y.
              *  
              * II slucaj: (jer I nije pokrio sve greske)
              *   Slike se nalaze u istom redu (isto im je Y), sto znaci da ne sme da se desi da X slike koja ide pre bude vece od X slike koja ide posle. (X raste nadesno)
            */

            //pobeda je

            stoperica.Stop();
            TimeSpan stopericaElapsed = stoperica.Elapsed;
            int vremeUSekundama = Convert.ToInt32(stopericaElapsed.TotalSeconds);

            string poruka = "\nCestitamo, slozili ste sliku!\n\n\n\nDa bi rezultat bio sacuvan, unesite svoje ime:";
            string naslov = "Pobeda";
            string difoltIme = "player";

            string ime = Interaction.InputBox(poruka, naslov, difoltIme);

            if (ime.Trim() != "")  //ako je igrac kliknuo Cancel, ime je ""
                db.upisiRezultat(ime, brRedova, brKolona, vremeUSekundama, ukupnoPoteza);

            //a u svakom slucaju:
            stoperica.Reset();
            restartujBrojacPoteza();
            ocistiSvaPolja();
            podeliSlikuIPrikazi();
        }
        
        private void btnRezultati_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<Rezultat> rezultati = db.dajTop10();

            listViewRezultati = new ListView();
            foreach (Rezultat rezultat in rezultati)
            {
                string tipIgre = rezultat.brRedova.ToString() + " x " + rezultat.brKolona.ToString();

                string[] red = { (rezultati.IndexOf(rezultat) + 1).ToString(), rezultat.imeIgraca, tipIgre, rezultat.vremeUSekundama.ToString(), rezultat.ukupnoPoteza.ToString() };
                var item = new ListViewItem(red);
                listViewRezultati.Items.Add(item);
            }

            PopupForm popup = new PopupForm();

            popup.ShowDialog();
            popup.Dispose();
        }
    }
}
