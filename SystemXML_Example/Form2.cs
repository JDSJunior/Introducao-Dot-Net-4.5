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
using System.Xml.Linq;

namespace SystemXML_Example
{
    public partial class Form2 : Form
    {
        //caminho do arquivo
        string arquivo = @"C:\Users\junio\Desktop\arquivo2.xml";

        //cria uma instancia de xml
        XmlDocument xmlDoc = new XmlDocument();

        //cria uma instancia de nó
        XmlNode nodeRoot;

        public Form2()
        {
            InitializeComponent();

            //verifica se o arquivo já existe
            if (!File.Exists(arquivo))
            {
                nodeRoot = xmlDoc.CreateElement("Contatos");
                xmlDoc.AppendChild(nodeRoot);
                xmlDoc.Save(arquivo);
            }


        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {

            Inserir(txtNome.Text, txtTelefone.Text);
            Carregar();
            
        }

        private void Carregar()
        {
            //carrega o arquivo
            xmlDoc.Load(arquivo);

            lblAgenda.Text = "Agenda: \n\n";

            //percorre a lista que foi carregada nos nós dentro da tag contato
            foreach (XmlNode item in xmlDoc.GetElementsByTagName("Contato"))
            {
                lblAgenda.Text += item.Attributes["Nome"].Value + ": " + item.Attributes["Telefone"].Value + "\n";
            }
        }

        private void Inserir(string nome, string telefone)
        {

            //cria um elemento contato
            XElement xElement = new XElement("Contato");

            //adiciona os atributos na tag Contato
            xElement.Add(new XAttribute("Nome", nome));
            xElement.Add(new XAttribute("Telefone", telefone));

            //le o arquivo xml
            XElement xDoc = XElement.Load(arquivo);

            //adiciona o elemento no arquivo xml
            xDoc.Add(xElement);

            //salva o arquivo
            xDoc.Save(arquivo);
           
        }

    }
}
