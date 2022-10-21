using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace WindowsFormsApp8
{
    public partial class Auth1 : MetroForm
    {


        public Auth1()
        {
            InitializeComponent();
        }
        //Метод расстановки функционала формы взависимости от роли пользователя, которая передается посредством  поля класса,
        //в которое данное значени в свою очередь попало из запроса
        public void ManagerRole(int role)
        {
            switch (role)
            {
                case 1:
                    label1.Text = "Сотрудник";
                    label1.ForeColor = Color.DeepPink;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = false;
                    break;
                case 2:
                    label1.Text = "Администратор";
                    label1.ForeColor = Color.Green;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    break;
                case 3:
                    label1.Text = "Помошник";
                    label1.ForeColor = Color.Gold;
                    button1.Enabled = true;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
                default:
                    label1.Text = "Неизвестный пользователь";
                    label1.ForeColor = Color.Red;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;


            }




        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Сокрытие текущей формы
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            Auth2 auth2 = new Auth2();
            //Вызов формы в режиме диалога
            auth2.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Auth.auth)
            {
                //Отображаем рабочую форму
                this.Show();
                //Вытаскиваем из класса поля в label'ы
                label2.Text = Auth.auth_id;
                label3.Text = Auth.auth_fio;
                label4.Text = "Лецензированый пользователь";
                //Красим текст в label в зелёный цвет
                label4.ForeColor = Color.Green;
                //Вызываем метод управления ролями
                ManagerRole(Auth.auth_role);
            }
            else
            {
                this.Show();
                label2.Text = "неизвестный пользователь";
                label3.Text = "Отсутствует информация о пользователе";
                label4.Text = "Тебе сдесь не рады! ";
                label4.ForeColor = Color.Red;
                ManagerRole(Auth.auth_role);
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
//WindowsFormsApp8
