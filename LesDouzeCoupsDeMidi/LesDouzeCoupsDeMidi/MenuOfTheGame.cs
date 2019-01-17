using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LesDouzeCoupsDeMidi
{
    public partial class MenuOfTheGame : Form
    {
        public MenuOfTheGame()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaordGame bdg = new BaordGame();
            bdg.Play();
            bdg.ShowDialog();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Règles du jeu:\n\nRépondez à la question en cliquant sur une des quatres réponses\n\nSi vous répondez la bonne réponse un partie de l'image se dévoile !\nSinon rien ne se passe et vous passez à la question suivante.\n\nPour gagner entrer le nom de l'image dans le champ texte une fois que vous savez de quoi il s'agit.\nSi vous vous trompez votre vie diminue.\n\nVous avez trois vie. Si vos vie atteigne 0 vous avez perdu.\n\n\nBonne chance !");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Développeur : Esseiva Théo, Hausmann William\n\nTesteur : Favre Zacharie, Mota-Carneiro Rui-Manuel, Decoppet Joris, Golay Maxim, Saraiva Maia Leandro, Hausmann William, Esseiva Théo");
        }
    }
}
