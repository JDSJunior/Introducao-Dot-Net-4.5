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
using System.Xml;

namespace SystemXML_Example
{
    public partial class Form1 : Form
    {
        //caminho do arquivo
        string arquivo = @"C:\Users\junio\Desktop\arquivo.xml";
        //instancia do arquivo xml
        XmlDocument xmlDoc = new XmlDocument();

        public Form1()
        {
            InitializeComponent();

            //verifica e se o arquivo existe
            //se não cria-lo
            if (!File.Exists(arquivo))
            {
                //cria o nó raiz do arquivo xml
                XmlNode nodeRoot = xmlDoc.CreateElement("Contatos");
                //adiciona o nó raiz na instancia do arquivo xml
                xmlDoc.AppendChild(nodeRoot);
                //salva a instancia do arquivo no caminho passado
                xmlDoc.Save(arquivo);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            //carrega o arquivo em memoria
            xmlDoc.Load(arquivo);

            XmlNode nodeContato = xmlDoc.CreateElement("Contato");
            xmlDoc.SelectSingleNode("/Contatos").PrependChild(nodeContato);

            //cria outros dois nós para serem filhos do nó <Contato/>
            XmlNode nodeName = xmlDoc.CreateElement("Nome");
            XmlNode nodeTelefone = xmlDoc.CreateElement("Telefone");
            //insere o valos dos textbox  nos nós
            nodeName.InnerText = txtNome.Text;
            nodeTelefone.InnerText = txtTelefone.Text;

            


            xmlDoc.SelectSingleNode("/Contatos/Contato").AppendChild(nodeName);
            xmlDoc.SelectSingleNode("/Contatos/Contato").AppendChild(nodeTelefone);
            xmlDoc.Save(arquivo);

            MessageBox.Show("Contato Salvo!", "Alerta", MessageBoxButtons.OK);

            ReadAgenda();
            
        }

        private void ReadAgenda()
        {
            xmlDoc.Load(arquivo);
            LblAgenda.Text = "Contatos: \n\n";
            foreach (XmlNode item in xmlDoc.GetElementsByTagName("Contato"))
            {
                LblAgenda.Text += item.ChildNodes[0].InnerText + ": " + item.ChildNodes[1].InnerText + "\n";
            }
        }
    }
}
