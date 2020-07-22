using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.ExceptionServices;

namespace Ohgottlabels
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = Environment.UserName;
            string Picpath = @"C:\Users\" + uname + @"\Pictures\";
            if (Directory.Exists(Picpath))
            {
                string[] images = Directory.GetFiles(Picpath);
                Random rnd1 = new Random(69);
                Random rnd2 = new Random(rnd1.Next());
                List<string> firsthalf = new List<string>();
                List<string> secondhalf = new List<string>();
                listBox1.Items.AddRange(Directory.GetFiles(Picpath));
                for (int i=0; i<images.Count()-1; i++)
                {
                    string temp = images[i];
                    string empty = "";
                    temp = temp.Replace(".jpg", empty);
                    temp = temp.Replace(".jpeg", empty);
                    temp = temp.Replace(".png", empty);
                    temp = temp.Replace(".PNG", empty);
                    temp = temp.Replace(Picpath, empty);
                    //Console.WriteLine(temp);
                    int tempmiddle = temp.Length /2;
                    //Console.WriteLine(tempmiddle);
                    string half1 = "";
                    string half2 = "";

                    for (int b=0; b<= tempmiddle-1; b++)
                    {   
                        half1 += temp[b];
                        
                    }
                    for (int b = tempmiddle; b < temp.Length; b++)
                    {
                        half2 += temp[b];

                    }
                    //Console.WriteLine(half1 +" "+ half2);
                    firsthalf.Add(half1);
                    secondhalf.Add(half2);

                    //Enable this part only, if you want your files modified !

                    //Console.WriteLine("Image "+i+" was found");
                    //Directory.CreateDirectory(temp);
                    //Console.WriteLine(temp);
                    //File.Copy(images[i], copytopath);
                    //Console.WriteLine(images.Count()-1);
                    
                }
                string[] firstarr = firsthalf.OrderBy(x => rnd1.Next()).ToArray();
                string[] secarr = secondhalf.OrderBy(x => rnd2.Next()).ToArray();
                listBox2.Items.AddRange(firstarr);
                listBox2.Items.AddRange(secarr);
                //listBox3.Items.AddRange(secarr);
                

                for (int i = 0; i < images.Count() - 1; i++)
                {
                    string newname = firstarr[i] + secarr[i];
                    listBox3.Items.Add(newname);
                    if(images[i].EndsWith(".png"))
                    {
                        newname += ".png";
                    }
                    else if (images[i].EndsWith(".PNG"))
                    {
                        newname += ".PNG";
                    }
                    else if (images[i].EndsWith(".jpg"))
                    {
                        newname += ".jpg";
                    }
                    else if (images[i].EndsWith(".jpeg"))
                    {
                        newname += ".jpeg";
                    }
                    else
                    {
                        Console.WriteLine("Ohno");
                        break;
                    }
                    newname = Picpath + newname;
                    Console.WriteLine(images[i] + " would be named " + newname);
                    File.Move(images[i], newname);
                }


            }
            else
            {
                button1.BackColor = Color.FromName("red");
                button1.Text = "U r lucky";
            }
            
        }

    }
}
