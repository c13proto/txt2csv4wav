using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txt2csv4wav
{
    public partial class Form1 : Form
    {
        string RAWtxt;
        List<string> DATA=new List<string>();
        List<double> 時間DATA = new List<double>();
        List<double> 気圧DATA = new List<double>();
        List<int> 数値DATA8bit = new List<int>();
        List<int> 数値DATA16bit = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Click開く(object sender, EventArgs e)
        {
            RAWtxt="";
            DATA.Clear();
            時間DATA.Clear();
            気圧DATA.Clear();
            数値DATA8bit.Clear();
            数値DATA16bit.Clear();
            labeldebug.Text = "[debug]" + "\n";
            
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "txtファイル|*.txt;*.csv|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dialog.FileName))
                {
                    labeldebug.Text += "読み込み開始" + "\n";
                    var line = "";//行ごとのデータ
                    while ((line =sr.ReadLine()) != null)
                    {
                        RAWtxt +=line;
                        if (line.IndexOf('#') != 0 && line.Length==33) DATA.Add(line);
                    }
                    labeldebug.Text += "データ数：" + DATA.Count.ToString() + "\n";
                    if(DATA.Count==0) MessageBox.Show("入力ファイルが違うよ！","エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                //Console.Write(RAWtxt);
                for (int i = 0; i < DATA.Count; i++)
                {
                        時間DATA.Add(文字列から数値に変換(DATA[i].Substring(0,16).Trim() ) );
                        気圧DATA.Add(文字列から数値に変換(DATA[i].Substring(17,16).Trim() ) );
                        //Console.WriteLine("{0},{1}", 時間DATA[i], 気圧DATA[i]);
                }
                labeldebug.Text += "読み込み終了" + "\n";
                labeldebug.Text += "1周期" + 時間DATA [時間DATA.Count-1]+ "sec"+"\n";
            }
        }

        double 文字列から数値に変換(string str)
        {
            //strは0.125000031E-04みたいな形式
                var data = str.Split('E');
                data[1] = "001E" + data[1];
                double num = double.Parse(data[0]);
                double exp = double.Parse(data[1], System.Globalization.NumberStyles.AllowExponent);
                return num * exp;
            
        }
        

        private void Click変換開始(object sender, EventArgs e)
        {
            if (気圧DATA.Count > 5) 気圧から数値に変換();

        }
        void 気圧から数値に変換()
        {
            double ave = 気圧DATA.Average();
            double max = 気圧DATA.Max();
            double min = 気圧DATA.Min();

            double diffMax = max - ave;
            if ((ave - min) > diffMax) diffMax = ave - min;//diffMaxを最大振れ幅にする

            double 係数8bit = 127.0 / diffMax;
            double 係数16bit = 32767.0 / diffMax;

            for (int i = 0; i < 気圧DATA.Count; i++)
            {
                if (気圧DATA[i] > ave)
                {
                    数値DATA8bit.Add((int)(Math.Abs(気圧DATA[i] - ave) * 係数8bit));
                    数値DATA16bit.Add((int)(Math.Abs(気圧DATA[i] - ave) * 係数16bit));
                }
                else
                {
                    数値DATA8bit.Add(-(int)(Math.Abs(ave-気圧DATA[i]) * 係数8bit));
                    数値DATA16bit.Add(-(int)(Math.Abs(ave-気圧DATA[i]) * 係数16bit));
                }
                //Console.WriteLine("{0},{1}", 時間DATA[i], 数値DATA8bit[i]);
            }

            labeldebug.Text += "データ変換完了" + "\n";

        }
        

        private void Click保存(object sender, EventArgs e)
        {
            if (数値DATA8bit.Count > 10)
            {
                //System.IO.Directory.CreateDirectory(@"result");//resultフォルダの作成
                SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
                                                          //sfd.FileName = textBox_Gaus.Text + "_" + textBox_Bright.Text + "_" + textBox_Cont.Text;//はじめのファイル名を指定する
                                                          //sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
                sfd.Filter = "csvファイル|*.csv;*.txt|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
                sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
                sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
                sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
                sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

                //ダイアログを表示する
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき
                    //選択されたファイル名を表示する
                    System.Diagnostics.Debug.WriteLine(sfd.FileName);
                    csv保存(sfd.FileName);
                }
            }
        }

        void csv保存(string path)
        {
            //string wave_data = "";
            int loop = int.Parse(textBoxloop.Text);
            progressBar1.Maximum = loop;
            double sample_sec = 時間DATA[時間DATA.Count - 1];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (int n = 0; n < loop; n++)
            {
                for (int i = 0; i < 時間DATA.Count; i++)
                {
                    if (radioButton8bit.Checked)
                    {
                        sb.Append((時間DATA[i] + sample_sec * n).ToString());
                        sb.Append(",");
                        sb.Append(数値DATA8bit[i].ToString());
                        sb.Append("\n");
                    }
                    else
                    {
                        sb.Append((時間DATA[i] + sample_sec * n).ToString());
                        sb.Append(",");
                        sb.Append(数値DATA16bit[i].ToString());
                        sb.Append("\n");
                    }
                }
                progressBar1.Value = n+1;
            }
            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(sb.ToString());
                w.Dispose();

                labeldebug.Text += "保存完了" + "\n";
            }
        }
    }
}
